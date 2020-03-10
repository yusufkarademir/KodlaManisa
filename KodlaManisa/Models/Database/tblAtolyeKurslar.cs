using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblAtolyeKurslar
    {
        public tblAtolyeKurslar()
        {
            this.tblAtolyeKursOgrencileri = new HashSet<tblAtolyeKursOgrencileri>();
        }

        public int ID { get; set; }
        public string KursYili { get; set; }
        public string KursDönemi { get; set; }
        public string KursTuru { get; set; }
        public string KursSeviyesi { get; set; }
        public string KursGrubu { get; set; }
        public string GrupGunu { get; set; }
        public string GrupSaati { get; set; }

        [Required]
        public virtual tblOgretmenler Ogretmen { get; set; }

        public virtual tblAtolyeler Atolye { get; set; }

        [InverseProperty("AtolyeKurs")]
        public virtual ICollection<tblAtolyeKursOgrencileri> tblAtolyeKursOgrencileri { get; set; }
    }
}