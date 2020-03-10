using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOkulProjeEkibi
    {
        public int ID { get; set; }
        public string Yonetici { get; set; }
        public string Ogretmen1 { get; set; }
        public string Ogretmen2 { get; set; }

        public virtual tblOkullar Okul { get; set; }
    }
}