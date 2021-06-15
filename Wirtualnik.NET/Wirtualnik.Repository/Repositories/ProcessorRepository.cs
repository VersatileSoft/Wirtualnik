using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Repository.Interfaces;
using Wirtualnik.Repository.Repositories.Base;

namespace Wirtualnik.Repository.Repositories
{
    public class ProcessorRepository : RepositoryBase<Processor>, IProcessorRepository
    {
        public ProcessorRepository(WirtualnikDbContext dbContext) : base(dbContext)
        {
        }
    }
}
