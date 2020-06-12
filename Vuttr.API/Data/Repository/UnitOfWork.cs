using System.Threading.Tasks;
using Vuttr.API.Data.Context;
using Vuttr.API.Domain.Repository;

namespace Vuttr.API.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}