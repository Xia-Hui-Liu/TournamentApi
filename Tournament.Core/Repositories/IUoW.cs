
namespace Tournament.Core.Repositories
{
    public interface IUoW
    {
        IGameRepository GameRepository { get; }
        ITourRepository TourRepository { get; }
        Task CompleteAsync();
    }
}
