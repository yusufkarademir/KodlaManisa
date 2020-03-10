using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.Models.Database
{
    public class tblAtolyeFotograf
    {
        public int ID { get; set; }
        public string FotografLink { get; set; }

        public virtual tblAtolyeler Atolye { get; set; }
    }
}