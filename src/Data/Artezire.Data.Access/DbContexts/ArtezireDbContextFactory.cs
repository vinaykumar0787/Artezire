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

        public ArtezireDbContext Create()
        {
            return new ArtezireDbContext("");
        }
    }
}
