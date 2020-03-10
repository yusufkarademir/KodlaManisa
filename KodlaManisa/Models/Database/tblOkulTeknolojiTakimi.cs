using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOkulTeknolojiTakimi
    {
        public int ID { get; set; }
        public string TakimAdi { get; set; }
        public int OgrenciSayisi { get; set; }
        public string KatildigiYarismaAdi { get; set; }

        public virtual tblOgretmenler Ogretmen { get; set; }

        public virtual tblOkullar Okul { get; set; }
    }
}