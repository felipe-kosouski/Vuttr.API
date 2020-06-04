using System.Threading.Tasks;

namespace Vuttr.API.Domain.Repository
{
    public interface IRepositoryManager
    {
        IToolRepository Tool { get; }
        Task SaveAsync();
    }
}