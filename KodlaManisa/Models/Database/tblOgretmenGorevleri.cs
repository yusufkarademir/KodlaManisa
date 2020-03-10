using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOgretmenGorevleri
    {
        public int ID { get; set; }

        public virtual tblOgretmenGorevlendirmeTuru GorevTuru { get; set; }

        public virtual tblOgretmenler Ogretmen { get; set; }

        public DateTime BaslamaTarihi { get; set; }

        public DateTime? BitisTarihi { get; set; }
    }
}