namespace KodlaManisa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOgrenciOnayColumnInTblAtolyeYonlendirilenOgrencilersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblAtolyeYonlendirilenOgrencilers", "OgrenciOnay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblAtolyeYonlendirilenOgrencilers", "OgrenciOnay");
        }
    }
}
