using Artezire.Data.Entities;
using System.Data.Entity;

namespace Artezire.Data.Access
{
    public class ArtezireDbContext : DbContext
    {

        //DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBlob> ProductBlobs { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<BlobType> BlobTypes { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserProductView> UserProductViews { get; set; }
        public DbSet<UserProductXref> UserProductXrefs { get; set; }

        public ArtezireDbContext(string connString) : base(connString)
        {

        }
    }
}
