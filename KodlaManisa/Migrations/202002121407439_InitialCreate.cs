namespace KodlaManisa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAtolyeFotografs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FotografLink = c.String(),
                        Atolye_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblAtolyelers", t => t.Atolye_ID)
                .Index(t => t.Atolye_ID);
            
            CreateTable(
                "dbo.tblAtolyelers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AtolyeAdi = c.String(),
                        AtolyeAdres = c.String(),
                        AtolyeTel = c.String(),
                        AtolyeCalismaSaati = c.String(),
                        AtolyeFacebook = c.String(),
                        AtolyeInstagram = c.String(),
                        AtolyeTwitter = c.String(),
                        AtolyeYoutube = c.String(),
                        AtolyeTuru_ID = c.Int(),
                        Ilce_ID = c.Int(),
                        Ogretmen_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblAtolyeTurus", t => t.AtolyeTuru_ID)
                .ForeignKey("dbo.tblIlcelers", t => t.Ilce_ID)
                .ForeignKey("dbo.tblOgretmenlers", t => t.Ogretmen_ID)
                .Index(t => t.AtolyeTuru_ID)
                .Index(t => t.Ilce_ID)
                .Index(t => t.Ogretmen_ID);
            
            CreateTable(
                "dbo.tblAtolyeTurus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AtolyeTurAdi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblIlcelers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IlceAdi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblOgretmenlers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OgretmenTC = c.String(),
                        OgretmenAdi = c.String(),
                        OgretmenSoyadi = c.String(),
                        OgretmenBrans = c.String(),
                        OgretmenMezuniyet = c.String(),
                        OgretmenAdres = c.String(),
                        OgretmenEposta = c.String(),
                        OgretmenTel = c.String(),
                        OgretmenDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblOgretmenGorevleris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BaslamaTarihi = c.DateTime(nullable: false),
                        BitisTarihi = c.DateTime(),
                        GorevTuru_ID = c.Int(),
                        Ogretmen_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOgretmenGorevlendirmeTurus", t => t.GorevTuru_ID)
                .ForeignKey("dbo.tblOgretmenlers", t => t.Ogretmen_ID)
                .Index(t => t.GorevTuru_ID)
                .Index(t => t.Ogretmen_ID);
            
            CreateTable(
                "dbo.tblOgretmenGorevlendirmeTurus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GorevAdi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblOgretmenDYKBilgileris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DersSaati = c.Int(nullable: false),
                        OgrenciSayisi = c.Int(nullable: false),
                        Okul_ID = c.Int(),
                        Sinif_ID = c.Int(),
                        Ogretmen_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOkullars", t => t.Okul_ID)
                .ForeignKey("dbo.tblOkulSiniflars", t => t.Sinif_ID)
                .ForeignKey("dbo.tblOgretmenlers", t => t.Ogretmen_ID)
                .Index(t => t.Okul_ID)
                .Index(t => t.Sinif_ID)
                .Index(t => t.Ogretmen_ID);
            
            CreateTable(
                "dbo.tblOkullars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OkulAdi = c.String(),
                        OkulMuduru = c.String(),
                        BTOgretmenSayisi = c.Int(nullable: false),
                        OkulAdres = c.String(),
                        OkulEposta = c.String(),
                        OkulTel = c.String(),
                        OkulFax = c.String(),
                        tblIlceler_ID = c.Int(),
                        tblOkulTuru_ID = c.Byte(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblIlcelers", t => t.tblIlceler_ID)
                .ForeignKey("dbo.tblOkulTurus", t => t.tblOkulTuru_ID)
                .Index(t => t.tblIlceler_ID)
                .Index(t => t.tblOkulTuru_ID);
            
            CreateTable(
                "dbo.tblOkulMalzemelers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MalzemeAdi = c.String(),
                        MalzemeAdedi = c.Int(nullable: false),
                        MalzemeDurumu = c.Boolean(nullable: false),
                        MalzemeTeminSekli = c.String(),
                        TeminTarihi = c.DateTime(nullable: false),
                        Okul_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOkullars", t => t.Okul_ID)
                .Index(t => t.Okul_ID);
            
            CreateTable(
                "dbo.tblOkulOgrencilers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ogrenci_ID = c.Int(),
                        Okul_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOgrencilers", t => t.Ogrenci_ID)
                .ForeignKey("dbo.tblOkullars", t => t.Okul_ID)
                .Index(t => t.Ogrenci_ID)
                .Index(t => t.Okul_ID);
            
            CreateTable(
                "dbo.tblOgrencilers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OgrenciNo = c.String(),
                        OgrenciTC = c.String(),
                        OgrenciAdi = c.String(),
                        OgrenciSoyadi = c.String(),
                        OgenciTelefon = c.String(),
                        OgrenciEposta = c.String(),
                        OgrenciVeli = c.String(),
                        OgrenciVeliTelefon = c.String(),
                        OgrenciVeliEposta = c.String(),
                        OkulOgretmeniGorus = c.String(),
                        AtolyeOgretmeniGorus = c.String(),
                        OgrenciDurumu = c.Boolean(nullable: false),
                        Ogretmen_ID = c.Int(),
                        OkulSinif_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOgretmenlers", t => t.Ogretmen_ID)
                .ForeignKey("dbo.tblOkulSiniflars", t => t.OkulSinif_ID)
                .Index(t => t.Ogretmen_ID)
                .Index(t => t.OkulSinif_ID);
            
            CreateTable(
                "dbo.tblAtolyeKursOgrencileris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DevamDurumu = c.String(),
                        OgrenciNot = c.Int(nullable: false),
                        OgretmenGorusu = c.String(),
                        AtolyeKurs_ID = c.Int(),
                        Ogrenci_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblAtolyeKurslars", t => t.AtolyeKurs_ID)
                .ForeignKey("dbo.tblOgrencilers", t => t.Ogrenci_ID, cascadeDelete: true)
                .Index(t => t.AtolyeKurs_ID)
                .Index(t => t.Ogrenci_ID);
            
            CreateTable(
                "dbo.tblAtolyeKurslars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KursYili = c.String(),
                        KursDönemi = c.String(),
                        KursTuru = c.String(),
                        KursSeviyesi = c.String(),
                        KursGrubu = c.String(),
                        GrupGunu = c.String(),
                        GrupSaati = c.String(),
                        Ogretmen_ID = c.Int(nullable: false),
                        Atolye_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOgretmenlers", t => t.Ogretmen_ID, cascadeDelete: true)
                .ForeignKey("dbo.tblAtolyelers", t => t.Atolye_ID)
                .Index(t => t.Ogretmen_ID)
                .Index(t => t.Atolye_ID);
            
            CreateTable(
                "dbo.tblOkulSiniflars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SinifAdi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblOkulOgretmenlers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AktifCalistigi = c.Boolean(nullable: false),
                        Sinif = c.String(),
                        DersSaati = c.Int(nullable: false),
                        OgrenciSayisi = c.Int(nullable: false),
                        Okul_ID = c.Int(),
                        Ogretmen_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOkullars", t => t.Okul_ID)
                .ForeignKey("dbo.tblOgretmenlers", t => t.Ogretmen_ID)
                .Index(t => t.Okul_ID)
                .Index(t => t.Ogretmen_ID);
            
            CreateTable(
                "dbo.tblOkulProjeEkibis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Yonetici = c.String(),
                        Ogretmen1 = c.String(),
                        Ogretmen2 = c.String(),
                        Okul_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOkullars", t => t.Okul_ID)
                .Index(t => t.Okul_ID);
            
            CreateTable(
                "dbo.tblOkulSoruCevaplars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cevap = c.Int(nullable: false),
                        Soru_ID = c.Int(nullable: false),
                        Okul_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblSorulars", t => t.Soru_ID, cascadeDelete: true)
                .ForeignKey("dbo.tblOkullars", t => t.Okul_ID)
                .Index(t => t.Soru_ID)
                .Index(t => t.Okul_ID);
            
            CreateTable(
                "dbo.tblSorulars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Soru = c.String(),
                        OkulTuru_ID = c.Byte(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOkulTurus", t => t.OkulTuru_ID)
                .Index(t => t.OkulTuru_ID);
            
            CreateTable(
                "dbo.tblOkulTurus",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        OkulTuru = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblOkulTeknolojiTakimis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TakimAdi = c.String(),
                        OgrenciSayisi = c.Int(nullable: false),
                        KatildigiYarismaAdi = c.String(),
                        Okul_ID = c.Int(),
                        Ogretmen_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOkullars", t => t.Okul_ID)
                .ForeignKey("dbo.tblOgretmenlers", t => t.Ogretmen_ID)
                .Index(t => t.Okul_ID)
                .Index(t => t.Ogretmen_ID);
            
            CreateTable(
                "dbo.tblAtolyeGelenZiyaretcis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ZiyaretciAdi = c.String(),
                        ZiyaretciSayisi = c.Int(nullable: false),
                        ZiyaretTarihi = c.DateTime(nullable: false),
                        Okul_ID = c.Int(nullable: false),
                        Atolye_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOkullars", t => t.Okul_ID, cascadeDelete: true)
                .ForeignKey("dbo.tblAtolyelers", t => t.Atolye_ID)
                .Index(t => t.Okul_ID)
                .Index(t => t.Atolye_ID);
            
            CreateTable(
                "dbo.tblAtolyeMalzemelers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MalzemeAdi = c.String(),
                        MalzemeAdedi = c.Int(nullable: false),
                        MalzemeDurumu = c.Boolean(nullable: false),
                        MalzemeTeminSekli = c.String(),
                        TeminTarihi = c.DateTime(nullable: false),
                        Atolye_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblAtolyelers", t => t.Atolye_ID)
                .Index(t => t.Atolye_ID);
            
            CreateTable(
                "dbo.tblAtolyeOduncVermes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MalzemeSayisi = c.Int(nullable: false),
                        VerilisTarihi = c.DateTime(nullable: false),
                        Sure = c.Int(nullable: false),
                        TeslimTarihi = c.DateTime(),
                        OgretmenID = c.Int(),
                        OgretmenAdi = c.String(),
                        OkulId = c.Int(),
                        AtolyeMalzeme_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblAtolyeMalzemelers", t => t.AtolyeMalzeme_ID)
                .Index(t => t.AtolyeMalzeme_ID);
            
            CreateTable(
                "dbo.tblAtolyeYaptigiZiyaretlers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ZiyaretciAdi = c.String(),
                        ZiyaretTarihi = c.DateTime(nullable: false),
                        Okul_ID = c.Int(nullable: false),
                        OkulSinif_ID = c.Int(nullable: false),
                        Atolye_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblOkullars", t => t.Okul_ID, cascadeDelete: true)
                .ForeignKey("dbo.tblOkulSiniflars", t => t.OkulSinif_ID, cascadeDelete: true)
                .ForeignKey("dbo.tblAtolyelers", t => t.Atolye_ID)
                .Index(t => t.Okul_ID)
                .Index(t => t.OkulSinif_ID)
                .Index(t => t.Atolye_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblAtolyeYaptigiZiyaretlers", "Atolye_ID", "dbo.tblAtolyelers");
            DropForeignKey("dbo.tblAtolyeYaptigiZiyaretlers", "OkulSinif_ID", "dbo.tblOkulSiniflars");
            DropForeignKey("dbo.tblAtolyeYaptigiZiyaretlers", "Okul_ID", "dbo.tblOkullars");
            DropForeignKey("dbo.tblAtolyeMalzemelers", "Atolye_ID", "dbo.tblAtolyelers");
            DropForeignKey("dbo.tblAtolyeOduncVermes", "AtolyeMalzeme_ID", "dbo.tblAtolyeMalzemelers");
            DropForeignKey("dbo.tblAtolyeKurslars", "Atolye_ID", "dbo.tblAtolyelers");
            DropForeignKey("dbo.tblAtolyeGelenZiyaretcis", "Atolye_ID", "dbo.tblAtolyelers");
            DropForeignKey("dbo.tblAtolyeGelenZiyaretcis", "Okul_ID", "dbo.tblOkullars");
            DropForeignKey("dbo.tblAtolyeFotografs", "Atolye_ID", "dbo.tblAtolyelers");
            DropForeignKey("dbo.tblAtolyelers", "Ogretmen_ID", "dbo.tblOgretmenlers");
            DropForeignKey("dbo.tblOkulTeknolojiTakimis", "Ogretmen_ID", "dbo.tblOgretmenlers");
            DropForeignKey("dbo.tblOkulOgretmenlers", "Ogretmen_ID", "dbo.tblOgretmenlers");
            DropForeignKey("dbo.tblOgretmenDYKBilgileris", "Ogretmen_ID", "dbo.tblOgretmenlers");
            DropForeignKey("dbo.tblOgretmenDYKBilgileris", "Sinif_ID", "dbo.tblOkulSiniflars");
            DropForeignKey("dbo.tblOkullars", "tblOkulTuru_ID", "dbo.tblOkulTurus");
            DropForeignKey("dbo.tblOkulTeknolojiTakimis", "Okul_ID", "dbo.tblOkullars");
            DropForeignKey("dbo.tblOkulSoruCevaplars", "Okul_ID", "dbo.tblOkullars");
            DropForeignKey("dbo.tblOkulSoruCevaplars", "Soru_ID", "dbo.tblSorulars");
            DropForeignKey("dbo.tblSorulars", "OkulTuru_ID", "dbo.tblOkulTurus");
            DropForeignKey("dbo.tblOkulProjeEkibis", "Okul_ID", "dbo.tblOkullars");
            DropForeignKey("dbo.tblOkulOgretmenlers", "Okul_ID", "dbo.tblOkullars");
            DropForeignKey("dbo.tblOkulOgrencilers", "Okul_ID", "dbo.tblOkullars");
            DropForeignKey("dbo.tblOgrencilers", "OkulSinif_ID", "dbo.tblOkulSiniflars");
            DropForeignKey("dbo.tblOgrencilers", "Ogretmen_ID", "dbo.tblOgretmenlers");
            DropForeignKey("dbo.tblOkulOgrencilers", "Ogrenci_ID", "dbo.tblOgrencilers");
            DropForeignKey("dbo.tblAtolyeKursOgrencileris", "Ogrenci_ID", "dbo.tblOgrencilers");
            DropForeignKey("dbo.tblAtolyeKursOgrencileris", "AtolyeKurs_ID", "dbo.tblAtolyeKurslars");
            DropForeignKey("dbo.tblAtolyeKurslars", "Ogretmen_ID", "dbo.tblOgretmenlers");
            DropForeignKey("dbo.tblOkulMalzemelers", "Okul_ID", "dbo.tblOkullars");
            DropForeignKey("dbo.tblOgretmenDYKBilgileris", "Okul_ID", "dbo.tblOkullars");
            DropForeignKey("dbo.tblOkullars", "tblIlceler_ID", "dbo.tblIlcelers");
            DropForeignKey("dbo.tblOgretmenGorevleris", "Ogretmen_ID", "dbo.tblOgretmenlers");
            DropForeignKey("dbo.tblOgretmenGorevleris", "GorevTuru_ID", "dbo.tblOgretmenGorevlendirmeTurus");
            DropForeignKey("dbo.tblAtolyelers", "Ilce_ID", "dbo.tblIlcelers");
            DropForeignKey("dbo.tblAtolyelers", "AtolyeTuru_ID", "dbo.tblAtolyeTurus");
            DropIndex("dbo.tblAtolyeYaptigiZiyaretlers", new[] { "Atolye_ID" });
            DropIndex("dbo.tblAtolyeYaptigiZiyaretlers", new[] { "OkulSinif_ID" });
            DropIndex("dbo.tblAtolyeYaptigiZiyaretlers", new[] { "Okul_ID" });
            DropIndex("dbo.tblAtolyeOduncVermes", new[] { "AtolyeMalzeme_ID" });
            DropIndex("dbo.tblAtolyeMalzemelers", new[] { "Atolye_ID" });
            DropIndex("dbo.tblAtolyeGelenZiyaretcis", new[] { "Atolye_ID" });
            DropIndex("dbo.tblAtolyeGelenZiyaretcis", new[] { "Okul_ID" });
            DropIndex("dbo.tblOkulTeknolojiTakimis", new[] { "Ogretmen_ID" });
            DropIndex("dbo.tblOkulTeknolojiTakimis", new[] { "Okul_ID" });
            DropIndex("dbo.tblSorulars", new[] { "OkulTuru_ID" });
            DropIndex("dbo.tblOkulSoruCevaplars", new[] { "Okul_ID" });
            DropIndex("dbo.tblOkulSoruCevaplars", new[] { "Soru_ID" });
            DropIndex("dbo.tblOkulProjeEkibis", new[] { "Okul_ID" });
            DropIndex("dbo.tblOkulOgretmenlers", new[] { "Ogretmen_ID" });
            DropIndex("dbo.tblOkulOgretmenlers", new[] { "Okul_ID" });
            DropIndex("dbo.tblAtolyeKurslars", new[] { "Atolye_ID" });
            DropIndex("dbo.tblAtolyeKurslars", new[] { "Ogretmen_ID" });
            DropIndex("dbo.tblAtolyeKursOgrencileris", new[] { "Ogrenci_ID" });
            DropIndex("dbo.tblAtolyeKursOgrencileris", new[] { "AtolyeKurs_ID" });
            DropIndex("dbo.tblOgrencilers", new[] { "OkulSinif_ID" });
            DropIndex("dbo.tblOgrencilers", new[] { "Ogretmen_ID" });
            DropIndex("dbo.tblOkulOgrencilers", new[] { "Okul_ID" });
            DropIndex("dbo.tblOkulOgrencilers", new[] { "Ogrenci_ID" });
            DropIndex("dbo.tblOkulMalzemelers", new[] { "Okul_ID" });
            DropIndex("dbo.tblOkullars", new[] { "tblOkulTuru_ID" });
            DropIndex("dbo.tblOkullars", new[] { "tblIlceler_ID" });
            DropIndex("dbo.tblOgretmenDYKBilgileris", new[] { "Ogretmen_ID" });
            DropIndex("dbo.tblOgretmenDYKBilgileris", new[] { "Sinif_ID" });
            DropIndex("dbo.tblOgretmenDYKBilgileris", new[] { "Okul_ID" });
            DropIndex("dbo.tblOgretmenGorevleris", new[] { "Ogretmen_ID" });
            DropIndex("dbo.tblOgretmenGorevleris", new[] { "GorevTuru_ID" });
            DropIndex("dbo.tblAtolyelers", new[] { "Ogretmen_ID" });
            DropIndex("dbo.tblAtolyelers", new[] { "Ilce_ID" });
            DropIndex("dbo.tblAtolyelers", new[] { "AtolyeTuru_ID" });
            DropIndex("dbo.tblAtolyeFotografs", new[] { "Atolye_ID" });
            DropTable("dbo.tblAtolyeYaptigiZiyaretlers");
            DropTable("dbo.tblAtolyeOduncVermes");
            DropTable("dbo.tblAtolyeMalzemelers");
            DropTable("dbo.tblAtolyeGelenZiyaretcis");
            DropTable("dbo.tblOkulTeknolojiTakimis");
            DropTable("dbo.tblOkulTurus");
            DropTable("dbo.tblSorulars");
            DropTable("dbo.tblOkulSoruCevaplars");
            DropTable("dbo.tblOkulProjeEkibis");
            DropTable("dbo.tblOkulOgretmenlers");
            DropTable("dbo.tblOkulSiniflars");
            DropTable("dbo.tblAtolyeKurslars");
            DropTable("dbo.tblAtolyeKursOgrencileris");
            DropTable("dbo.tblOgrencilers");
            DropTable("dbo.tblOkulOgrencilers");
            DropTable("dbo.tblOkulMalzemelers");
            DropTable("dbo.tblOkullars");
            DropTable("dbo.tblOgretmenDYKBilgileris");
            DropTable("dbo.tblOgretmenGorevlendirmeTurus");
            DropTable("dbo.tblOgretmenGorevleris");
            DropTable("dbo.tblOgretmenlers");
            DropTable("dbo.tblIlcelers");
            DropTable("dbo.tblAtolyeTurus");
            DropTable("dbo.tblAtolyelers");
            DropTable("dbo.tblAtolyeFotografs");
        }
    }
}
