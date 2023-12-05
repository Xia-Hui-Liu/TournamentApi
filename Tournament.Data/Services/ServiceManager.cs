
using Tournament.Core.Services;

namespace Tournament.Data.Services
{
    public class ServiceManager : IServiceManager
    {
        // Declare a private readonly Lazy<ITourService> field named _tourService.
        private readonly Lazy<ITourService> _tourService;

        // Declare a private readonly Lazy<IGameService> field named _gameService.
        private readonly Lazy<IGameService> _gameService;

        // Declare a public property named TourService, which exposes the Value property of _tourService.
        public ITourService TourService => _tourService.Value;

        // Declare a public property named GameService, which exposes the Value property of _gameService.
        public IGameService GameService => _gameService.Value;

        // Constructor for the ServiceManager class, which takes Lazy<ITourService> and Lazy<IGameService> as parameters.
        public ServiceManager(Lazy<ITourService> tourService, Lazy<IGameService> gameService)
        {
            // Assign the provided Lazy<ITourService> to the private _tourService field.
            _tourService = tourService;

            // Assign the provided Lazy<IGameService> to the private _gameService field.
            _gameService = gameService;
        }
    }


}
