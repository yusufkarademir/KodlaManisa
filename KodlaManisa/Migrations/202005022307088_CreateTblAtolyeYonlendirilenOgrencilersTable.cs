namespace KodlaManisa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTblAtolyeYonlendirilenOgrencilersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAtolyeYonlendirilenOgrencilers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ogrenci_ID = c.Int(nullable: false),
                        Atolye_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOgrencilers", t => t.Ogrenci_ID, cascadeDelete: true)
                .ForeignKey("dbo.tblAtolyelers", t => t.Atolye_ID)
                .Index(t => t.Ogrenci_ID)
                .Index(t => t.Atolye_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblAtolyeYonlendirilenOgrencilers", "Atolye_ID", "dbo.tblAtolyelers");
            DropForeignKey("dbo.tblAtolyeYonlendirilenOgrencilers", "Ogrenci_ID", "dbo.tblOgrencilers");
            DropIndex("dbo.tblAtolyeYonlendirilenOgrencilers", new[] { "Atolye_ID" });
            DropIndex("dbo.tblAtolyeYonlendirilenOgrencilers", new[] { "Ogrenci_ID" });
            DropTable("dbo.tblAtolyeYonlendirilenOgrencilers");
        }
    }
}
