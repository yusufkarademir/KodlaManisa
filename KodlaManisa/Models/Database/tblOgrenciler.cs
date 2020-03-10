using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOgrenciler
    {
        public tblOgrenciler()
        {
            this.Ogrenciler = new HashSet<tblOkulOgrenciler>();
            this.AtolyeKurslari = new HashSet<tblAtolyeKursOgrencileri>();
        }

        public int ID { get; set; }
        public string OgrenciNo { get; set; }
        public string OgrenciTC { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        public string OgenciTelefon { get; set; }
        public string OgrenciEposta { get; set; }
        public string OgrenciVeli { get; set; }
        public string OgrenciVeliTelefon { get; set; }
        public string OgrenciVeliEposta { get; set; }
        public string OkulOgretmeniGorus { get; set; }
        public string AtolyeOgretmeniGorus { get; set; }
        public bool OgrenciDurumu { get; set; }

        public virtual tblOgretmenler Ogretmen { get; set; }
        public virtual tblOkulSiniflar OkulSinif { get; set; }

        [InverseProperty("Ogrenci")]
        public virtual ICollection<tblOkulOgrenciler> Ogrenciler { get; set; }
        [InverseProperty("Ogrenci")]
        public virtual ICollection<tblAtolyeKursOgrencileri> AtolyeKurslari { get; set; }
    }
}