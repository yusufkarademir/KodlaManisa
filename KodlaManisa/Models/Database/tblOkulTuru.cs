using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblOkulTuru
    {
        public tblOkulTuru()
        {
            this.Sorular = new List<tblSorular>();
        }

        public byte ID { get; set; }

        public string OkulTuru { get; set; }

        [InverseProperty("OkulTuru")]
        public virtual List<tblSorular> Sorular { get; set; }
    }
}