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

        public ArtezireDbContextFactory()
        {
            
        }

        

        public ArtezireDbContext Create()
        {
            return new ArtezireDbContext("Server = (localdb)\\mssqllocaldb; Database = ArtezireDb; Trusted_Connection = True; ");
        }
    }
}
