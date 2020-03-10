using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOkullar
    {
        public tblOkullar()
        {
            this.tblOgretmenDYKBilgileri = new HashSet<tblOgretmenDYKBilgileri>();
            this.tblOkulMalzemeler = new HashSet<tblOkulMalzemeler>();
            this.tblOkulProjeEkibi = new HashSet<tblOkulProjeEkibi>();
            this.tblOkulTeknolojiTakimi = new HashSet<tblOkulTeknolojiTakimi>();
            this.tblOkulSoruCevaplar = new HashSet<tblOkulSoruCevaplar>();
            this.tblOkulOgrenciler = new HashSet<tblOkulOgrenciler>();
            this.tblOkulOgretmenler = new HashSet<tblOkulOgretmenler>();
        }

        public int ID { get; set; }
        public string OkulAdi { get; set; }
        public string OkulMuduru { get; set; }
        public int BTOgretmenSayisi { get; set; }
        public string OkulAdres { get; set; }
        public string OkulEposta { get; set; }
        public string OkulTel { get; set; }
        public string OkulFax { get; set; }

        public virtual tblOkulTuru tblOkulTuru { get; set; }
        public virtual tblIlceler tblIlceler { get; set; }

        [InverseProperty("Okul")]
        public virtual ICollection<tblOkulSoruCevaplar> tblOkulSoruCevaplar { get; set; }
        [InverseProperty("Okul")]
        public virtual ICollection<tblOkulOgrenciler> tblOkulOgrenciler { get; set; }
        [InverseProperty("Okul")]
        public virtual ICollection<tblOkulOgretmenler> tblOkulOgretmenler { get; set; }
        [InverseProperty("Okul")]
        public virtual ICollection<tblOgretmenDYKBilgileri> tblOgretmenDYKBilgileri { get; set; }
        [InverseProperty("Okul")]
        public virtual ICollection<tblOkulMalzemeler> tblOkulMalzemeler { get; set; }
        [InverseProperty("Okul")]
        public virtual ICollection<tblOkulProjeEkibi> tblOkulProjeEkibi { get; set; }
        [InverseProperty("Okul")]
        public virtual ICollection<tblOkulTeknolojiTakimi> tblOkulTeknolojiTakimi { get; set; }
    }
}