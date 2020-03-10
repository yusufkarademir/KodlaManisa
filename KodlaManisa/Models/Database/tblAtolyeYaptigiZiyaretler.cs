using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblAtolyeYaptigiZiyaretler
    {
        public int ID { get; set; }
        public string ZiyaretciAdi { get; set; }
        public DateTime ZiyaretTarihi { get; set; }

        [Required]
        public virtual tblOkullar Okul { get; set; }
        [Required]
        public virtual tblOkulSiniflar OkulSinif { get; set; }

        public virtual tblAtolyeler Atolye { get; set; }
    }
}