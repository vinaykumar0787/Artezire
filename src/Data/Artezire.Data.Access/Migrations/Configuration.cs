namespace Artezire.Data.Access.Migrations
{
    using Entities;
    using Entities.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Artezire.Data.Access.ArtezireDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Artezire.Data.Access.ArtezireDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            
        }
    }
}
