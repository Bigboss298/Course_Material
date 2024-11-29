


using Course_Material.Data;
using Course_Material.Interface.Repositories;

namespace Course_Material.Implementation.Repositories
{
    internal sealed class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
