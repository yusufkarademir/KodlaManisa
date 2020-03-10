using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOgretmenDYKBilgileri
    {
        public int ID { get; set; }

        public virtual tblOkulSiniflar Sinif { get; set; }
        public int DersSaati { get; set; }
        public int OgrenciSayisi { get; set; }

        public virtual tblOgretmenler Ogretmen { get; set; }
        public virtual tblOkullar Okul{ get; set; }
    }
}