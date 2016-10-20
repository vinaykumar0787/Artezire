using Artezire.Data.Access;
using Microsoft.Extensions.DependencyInjection;

namespace Artezire.Common.Infrastructure
{
    /// <summary>
    /// Resolves IOC dependencies
    /// </summary>
    public class IOCHandle
    {
        public IOCHandle()
        {
        }

        /// <summary>
        /// Resolves IOC dependencies by registring Interfaces with implementations
        /// </summary>
        /// <param name="services">IServiceCollection services</param>
        /// <returns></returns>
        public static void RegisterIOC(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
