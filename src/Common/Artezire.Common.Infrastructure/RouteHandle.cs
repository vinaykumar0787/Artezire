using Microsoft.AspNetCore.Builder;

namespace Artezire.Common.Infrastructure
{
    /// <summary>
    /// Registers API Routes
    /// </summary>
    public class RouteHandle
    {
        public RouteHandle()
        { }

        /// <summary>
        /// Resolves IOC dependencies by registring Interfaces with implementations
        /// </summary>
        /// <param name="services">IServiceCollection services</param>
        /// <returns></returns>
        public static void RegisterRoutes(IApplicationBuilder app)
        {

        }
    }
}
