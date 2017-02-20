using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Access.DbContexts
{
    public class ArtezireDbContextFactory : IDbContextFactory<ArtezireDbContext>
    {

        private IConfiguration _config;

        public ArtezireDbContextFactory(IConfiguration _config)
        {
            this._config = _config;
        }

        public ArtezireDbContext Create()
        {
            return new ArtezireDbContext(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
