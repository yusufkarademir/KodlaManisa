using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblAtolyeler
    {
        public tblAtolyeler()
        {
            this.tblAtolyeFotograf = new HashSet<tblAtolyeFotograf>();
            this.tblAtolyeGelenZiyaretci = new HashSet<tblAtolyeGelenZiyaretci>();
            this.tblAtolyeKurslar = new HashSet<tblAtolyeKurslar>();
            this.tblAtolyeMalzemeler = new HashSet<tblAtolyeMalzemeler>();
            this.tblAtolyeYaptigiZiyaretler = new List<tblAtolyeYaptigiZiyaretler>();
        }

        public int ID { get; set; }
        public string AtolyeAdi { get; set; }
        public string AtolyeAdres { get; set; }
        public string AtolyeTel { get; set; }
        public string AtolyeCalismaSaati { get; set; }
        public string AtolyeFacebook { get; set; }
        public string AtolyeInstagram { get; set; }
        public string AtolyeTwitter { get; set; }
        public string AtolyeYoutube { get; set; }

        public virtual tblIlceler Ilce { get; set; }
        public virtual tblAtolyeTuru AtolyeTuru { get; set; }
        public virtual tblOgretmenler Ogretmen { get; set; }

        [InverseProperty("Atolye")]
        public virtual ICollection<tblAtolyeFotograf> tblAtolyeFotograf { get; set; }
        [InverseProperty("Atolye")]
        public virtual ICollection<tblAtolyeGelenZiyaretci> tblAtolyeGelenZiyaretci { get; set; }
        [InverseProperty("Atolye")]
        public virtual ICollection<tblAtolyeKurslar> tblAtolyeKurslar { get; set; }
        [InverseProperty("Atolye")]
        public virtual ICollection<tblAtolyeMalzemeler> tblAtolyeMalzemeler { get; set; }
        [InverseProperty("Atolye")]
        public virtual ICollection<tblAtolyeYaptigiZiyaretler> tblAtolyeYaptigiZiyaretler { get; set; }

        public static implicit operator int(tblAtolyeler v)
        {
            throw new NotImplementedException();
        }
    }
}