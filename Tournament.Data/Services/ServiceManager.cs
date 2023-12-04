using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Services;

namespace Tournament.Data.Services
{
    public class ServiceManager
    {
        // Declare a private readonly Lazy<ITourService> field named _tourService.
        // Lazy<T> is a class in .NET that provides lazy initialization of objects,
        // meaning the object is created only when it is first accessed.
        private readonly Lazy<ITourService> _tourService;

        // Declare a public property named TourService, which exposes the Value property of _tourService.
        // The Value property of Lazy<T> ensures that the underlying object is created if it hasn't been created yet.
        public ITourService TourService => _tourService.Value;

        // Constructor for the ServiceManager class, which takes a Lazy<ITourService> as a parameter.
        public ServiceManager(Lazy<ITourService> tourService)
        {
            // Assign the provided Lazy<ITourService> to the private _tourService field.
            _tourService = tourService;
        }
    }

}
