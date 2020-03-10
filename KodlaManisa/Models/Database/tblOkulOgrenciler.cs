using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOkulOgrenciler
    {
        public int ID { get; set; }

        public virtual tblOkullar Okul { get; set; }

        public virtual tblOgrenciler Ogrenci { get; set; }
    }
}