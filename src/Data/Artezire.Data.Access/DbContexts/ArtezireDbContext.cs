using Artezire.Data.Entities;
using System.Data.Entity;

namespace Artezire.Data.Access
{
    public class ArtezireDbContext : DbContext
    {

        //DbSets
        public DbSet<Product> Products { get; set; }

        public ArtezireDbContext(string connString) : base(connString)
        {

        }
    }
}
