using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOgretmenGorevlendirmeTuru
    {
        public int ID { get; set; }

        public string GorevAdi { get; set; }

        [InverseProperty("GorevTuru")]
        public ICollection<tblOgretmenGorevleri> Ogretmenler { get; set; }
    }
}