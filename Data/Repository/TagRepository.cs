using Vuttr.API.Data.Context;
using Vuttr.API.Domain.Models;
using Vuttr.API.Domain.Repository;

namespace Vuttr.API.Data.Repository
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}