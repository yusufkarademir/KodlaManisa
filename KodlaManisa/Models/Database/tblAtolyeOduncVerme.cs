using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblAtolyeOduncVerme
    {
        public int ID { get; set; }

        public int MalzemeSayisi { get; set; }
        public DateTime VerilisTarihi { get; set; }
        public int Sure { get; set; }
        public DateTime? TeslimTarihi { get; set; }

        /// <summary>
        /// Kodlarken sayfadaki yoruma bakılsın.
        /// </summary>
        public int? OgretmenID { get; set; }
        /// <summary>
        /// Kodlarken sayfadaki yoruma bakılsın.
        /// </summary>
        public string OgretmenAdi { get; set; }
        /// <summary>
        /// Kodlarken sayfadaki yoruma bakılsın.
        /// </summary>
        public int? OkulId{ get; set; }
        /*
         Eğer sistemden bir öğretmen ise, ÖğretmenId değeri atanıp diğerleri boş bırakılır.
         Eğer sistemden değilse ogretmenId null olup diğer 2 bilgi girilir.
             */

        public virtual tblAtolyeMalzemeler AtolyeMalzeme { get; set; }
    }
}