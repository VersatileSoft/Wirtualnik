﻿using System.Threading.Tasks;
using Wirtualnik.Data.Models;

namespace Wirtualnik.Service.Interfaces.Base
{
    public interface IServiceBase
    {
        Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        Task<TEntity> FindAsync<TEntity>(long id) where TEntity : EntityBase;
        Task<TEntity> RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        Task<int> SaveChangesAsync();
        Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
    }
}