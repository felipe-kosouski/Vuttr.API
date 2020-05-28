using System.Threading.Tasks;
using Vuttr.API.Data.Context;
using Vuttr.API.Domain.Repository;

namespace Vuttr.API.Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _context;
        public IToolRepository _toolRepository;

        public RepositoryManager(AppDbContext context)
        {
            _context = context;
        }

        public IToolRepository Tool
        {
            get
            {
                if (_toolRepository == null)
                {
                    _toolRepository = new ToolRepository(_context);
                }

                return _toolRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}