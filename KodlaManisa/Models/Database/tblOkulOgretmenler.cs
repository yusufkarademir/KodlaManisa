using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOkulOgretmenler
    {
        public int ID { get; set; }

        public virtual tblOkullar Okul { get; set; }

        public virtual tblOgretmenler Ogretmen { get; set; }

        public bool AktifCalistigi { get; set; }

        public string Sinif { get; set; }

        public int DersSaati { get; set; }

        public int OgrenciSayisi { get; set; }
    }
}