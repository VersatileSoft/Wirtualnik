using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models.Base;
using Wirtualnik.Repository.Interfaces.Base;

namespace Wirtualnik.Repository.Repositories.Base
{
    public abstract class RepositoryBase<EntityType> : IRepositoryBase<EntityType> where EntityType : EntityBase, new()
    {
        protected readonly WirtualnikDbContext DbContext;

        protected RepositoryBase(WirtualnikDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task CreateAsync(EntityType value)
        {
            await DbContext.Set<EntityType>().AddAsync(value).ConfigureAwait(false);
            await DbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(EntityType entity)
        {
            DbContext.Set<EntityType>().Remove(entity);
            await DbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task<EntityType> ByIdAsync(int id)
        {
            return DbContext.Set<EntityType>().SingleAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<EntityType>> AllAsync()
        {
            return await DbContext.Set<EntityType>().ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(EntityType value)
        {
            DbContext.Set<EntityType>().Update(value);
            await DbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        //public Task<bool> Transaction(Func<Task> action)
        //{
        //    var executionStrategy = DbContext.Database.CreateExecutionStrategy();
        //    return executionStrategy.Execute(async () =>
        //    {
        //        using var transaction = DbContext.Database.BeginTransaction();
        //        try
        //        {
        //            await action().ConfigureAwait(false);
        //            transaction.Commit();
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            transaction.Rollback();
        //        }
        //        return false;
        //    });
        //}
    }
}
