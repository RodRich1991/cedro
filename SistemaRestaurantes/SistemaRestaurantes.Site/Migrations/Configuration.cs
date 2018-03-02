namespace SistemaRestaurantes.Site.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SistemaRestaurantes.Site.Models.SistemaRestaurantesSiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SistemaRestaurantes.Site.Models.SistemaRestaurantesSiteContext";
        }

        protected override void Seed(SistemaRestaurantes.Site.Models.SistemaRestaurantesSiteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
