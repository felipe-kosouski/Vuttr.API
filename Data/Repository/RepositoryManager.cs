using Vuttr.API.Data.Context;
using Vuttr.API.Domain.Repository;

namespace Vuttr.API.Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _context;
        public IToolRepository _toolRepository;
        public ITagRepository _tagRepository;
        
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

        public ITagRepository Tag
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new TagRepository(_context);
                }

                return _tagRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}