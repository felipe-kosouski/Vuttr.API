namespace Vuttr.API.Domain.Repository
{
    public interface IRepositoryManager
    {
        IToolRepository Tool { get; }
        ITagRepository Tag { get; }
        void Save();
    }
}