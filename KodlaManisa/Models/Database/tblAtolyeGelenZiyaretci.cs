using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblAtolyeGelenZiyaretci
    {
        public int ID { get; set; }
        public string ZiyaretciAdi { get; set; }
        public int ZiyaretciSayisi { get; set; }
        public DateTime ZiyaretTarihi { get; set; }

        [Required]
        public virtual tblOkullar Okul { get; set; }

        public virtual tblAtolyeler Atolye { get; set; }
    }
}