
namespace Tournament.Core.Services
{
    public interface IServiceManager
    {
        ITourService TourService { get; }
        IGameService GameService { get; }
    }
}
