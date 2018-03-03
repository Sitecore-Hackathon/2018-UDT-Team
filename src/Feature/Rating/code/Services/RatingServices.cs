using Hackathon.Boilerplate.Feature.Rating.Controllers;
using Hackathon.Boilerplate.Feature.Rating.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Hackathon.Boilerplate.Feature.Rating.Services
{
    /// <summary>
    /// Service for Rating repository
    /// </summary>
    public class RatingServices : IServicesConfigurator
    {
        /// <summary>
        /// Registering the controller and respository in Sitecore IoC collection
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<RatingController>();
            serviceCollection.AddTransient<IRatingRepository, RatingRepository>();
        }
    }
}