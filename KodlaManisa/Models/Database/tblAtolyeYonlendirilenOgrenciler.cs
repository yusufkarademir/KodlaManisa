using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblAtolyeYonlendirilenOgrenciler
    {
        public int ID { get; set; }

        [Required]
        public virtual tblOgrenciler Ogrenci { get; set; }

        public virtual tblAtolyeler Atolye { get; set; }

        public bool OgrenciOnay { get; set; }
    }
}