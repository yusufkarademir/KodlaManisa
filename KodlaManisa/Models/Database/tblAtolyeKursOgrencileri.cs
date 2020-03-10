using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblAtolyeKursOgrencileri
    {
        public int ID { get; set; }
        public string DevamDurumu { get; set; }
        public int OgrenciNot { get; set; }
        public string OgretmenGorusu { get; set; }

        [Required]
        public virtual tblOgrenciler Ogrenci { get; set; }

        public virtual tblAtolyeKurslar AtolyeKurs { get; set; }
    }
}