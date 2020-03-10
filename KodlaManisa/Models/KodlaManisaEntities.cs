using KodlaManisa.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models
{
    public class KodlaManisaEntities : DbContext
    {
        public virtual DbSet<tblAtolyeFotograf> tblAtolyeFotograf { get; set; }
        public virtual DbSet<tblAtolyeGelenZiyaretci> tblAtolyeGelenZiyaretci { get; set; }
        public virtual DbSet<tblAtolyeKurslar> tblAtolyeKurslar { get; set; }
        public virtual DbSet<tblAtolyeKursOgrencileri> tblAtolyeKursOgrencileri { get; set; }
        public virtual DbSet<tblAtolyeler> tblAtolyeler { get; set; }
        public virtual DbSet<tblAtolyeMalzemeler> tblAtolyeMalzemeler { get; set; }
        public virtual DbSet<tblAtolyeOduncVerme> tblAtolyeOduncVerme { get; set; }
        public virtual DbSet<tblAtolyeTuru> tblAtolyeTuru { get; set; }
        public virtual DbSet<tblAtolyeYaptigiZiyaretler> tblAtolyeYaptigiZiyaretler { get; set; }
        public virtual DbSet<tblIlceler> tblIlceler { get; set; }
        public virtual DbSet<tblOgrenciler> tblOgrenciler { get; set; }
        public virtual DbSet<tblOgretmenDYKBilgileri> tblOgretmenDYKBilgileri { get; set; }
        public virtual DbSet<tblOgretmenGorevlendirmeTuru> tblOgretmenGorevlendirmeTuru { get; set; }
        public virtual DbSet<tblOgretmenGorevleri> tblOgretmenGorevleri { get; set; }
        public virtual DbSet<tblOgretmenler> tblOgretmenler { get; set; }
        public virtual DbSet<tblOkullar> tblOkullar { get; set; }
        public virtual DbSet<tblOkulMalzemeler> tblOkulMalzemeler { get; set; }
        public virtual DbSet<tblOkulOgrenciler> tblOkulOgrenciler { get; set; }
        public virtual DbSet<tblOkulOgretmenler> TblOkulOgretmenler { get; set; }
        public virtual DbSet<tblOkulProjeEkibi> tblOkulProjeEkibi { get; set; }
        public virtual DbSet<tblOkulSiniflar> tblOkulSiniflar { get; set; }
        public virtual DbSet<tblOkulSoruCevaplar> tblOkulSoruCevaplar { get; set; }
        public virtual DbSet<tblOkulTeknolojiTakimi> tblOkulTeknolojiTakimi { get; set; }
        public virtual DbSet<tblOkulTuru> tblOkulTuru { get; set; }
        public virtual DbSet<tblSorular> tblSorular { get; set; }
    }
}