using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOkulSoruCevaplar
    {
        public int ID { get; set; }

        [Required]
        public virtual tblSorular Soru { get; set; }

        public int Cevap { get; set; }

        public virtual tblOkullar Okul { get; set; }
    }
}