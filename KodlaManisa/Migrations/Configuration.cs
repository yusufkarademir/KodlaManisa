namespace KodlaManisa.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KodlaManisa.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<KodlaManisa.Models.KodlaManisaEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "KodlaManisa.Models.KodlaManisaEntities";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KodlaManisaEntities context)
        {
            base.Seed(context);
        }
    }
}
