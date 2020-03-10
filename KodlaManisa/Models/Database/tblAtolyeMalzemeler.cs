using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblAtolyeMalzemeler
    {
        public tblAtolyeMalzemeler()
        {
            this.tblAtolyeOduncVerme = new HashSet<tblAtolyeOduncVerme>();
        }

        public int ID { get; set; }
        public string MalzemeAdi { get; set; }
        public int MalzemeAdedi { get; set; }
        public bool MalzemeDurumu { get; set; }
        public string MalzemeTeminSekli { get; set; }
        public DateTime TeminTarihi { get; set; }

        public virtual tblAtolyeler Atolye { get; set; }
        [InverseProperty("AtolyeMalzeme")]
        public virtual ICollection<tblAtolyeOduncVerme> tblAtolyeOduncVerme { get; set; }
    }
}