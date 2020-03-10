using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOkulMalzemeler
    {
        public int ID { get; set; }
        public string MalzemeAdi { get; set; }
        public int MalzemeAdedi { get; set; }
        public bool MalzemeDurumu { get; set; }
        public string MalzemeTeminSekli { get; set; }
        public DateTime TeminTarihi { get; set; }

        public virtual tblOkullar Okul { get; set; }
    }
}