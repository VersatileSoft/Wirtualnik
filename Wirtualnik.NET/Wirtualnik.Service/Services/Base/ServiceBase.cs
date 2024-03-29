﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.Base;

namespace Wirtualnik.Service.Services.Base
{
    public abstract class ServiceBase : IServiceBase
    {
        protected WirtualnikDbContext Context { get; }
        protected IMapper Mapper { get; }

        protected ServiceBase(WirtualnikDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual async Task<TEntity> FindAsync<TEntity>(int id) where TEntity : EntityBase
        {
            return await Context.FindAsync<TEntity>(id);
        }

        public virtual async Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await Context.AddAsync<TEntity>(entity);
            await SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity is null)
                throw new System.Exception();

            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Update(entity);
            }

            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity is null)
                throw new System.Exception();
            Context.Remove(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> RemoveAsync<TEntity>(IEnumerable<TEntity> entities)
        {
            if (entities?.Any() != true)
                throw new System.ArgumentNullException(nameof(entities));
            Context.RemoveRange(entities);
            await SaveChangesAsync();
            return entities;
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> AllAsync<TEntity>() where TEntity : EntityBase
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}