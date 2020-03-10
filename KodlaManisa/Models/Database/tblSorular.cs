using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblSorular
    {
        public int ID { get; set; }

        public string Soru { get; set; }

        public virtual tblOkulTuru OkulTuru { get; set; }
    }
}