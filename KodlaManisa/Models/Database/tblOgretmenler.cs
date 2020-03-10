using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOgretmenler
    {
        public tblOgretmenler()
        {
            this.OkulOgretmenler = new HashSet<tblOkulOgretmenler>();
            this.OgretmenDYKBilgileri = new HashSet<tblOgretmenDYKBilgileri>();
            this.TeknolojiTakimlari = new HashSet<tblOkulTeknolojiTakimi>();
            this.Gorevleri = new HashSet<tblOgretmenGorevleri>();
        }
        
        public int ID { get; set; }
        public string OgretmenTC { get; set; }
        public string OgretmenAdi { get; set; }
        public string OgretmenSoyadi { get; set; }
        public string OgretmenBrans { get; set; }
        public string OgretmenMezuniyet { get; set; }
        public string OgretmenAdres { get; set; }
        public string OgretmenEposta { get; set; }
        public string OgretmenTel { get; set; }
        public bool OgretmenDurumu { get; set; }


        [InverseProperty("Ogretmen")]
        public virtual ICollection<tblOkulOgretmenler> OkulOgretmenler { get; set; }
        [InverseProperty("Ogretmen")]
        public virtual ICollection<tblOgretmenDYKBilgileri> OgretmenDYKBilgileri { get; set; }
        [InverseProperty("Ogretmen")]
        public virtual ICollection<tblOkulTeknolojiTakimi> TeknolojiTakimlari { get; set; }
        [InverseProperty("Ogretmen")]
        public virtual ICollection<tblOgretmenGorevleri> Gorevleri{ get; set; }




        public virtual ICollection<tblOgrenciler> tblOgrenciler { get; set; }
    }
}