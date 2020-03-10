using KodlaManisa.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.ViewModels
{

    public class AtolyeDetayViewModel
    {
        public AtolyeDataViewModel Atolye { get; set; }
        public AtolyeFotograflariViewModel Fotograflar { get; set; }
        public IEnumerable<tblAtolyeMalzemeler> Malzemeler { get; set; }
        public IEnumerable<tblAtolyeKurslar> Kurslar { get; set; }
        public IEnumerable<tblAtolyeKursOgrencileri> KursOgrencileri { get; set; }
        


        public class AtolyeDataViewModel
        {
            public string Adi { get; set; }

            public string CalismaSaati { get; set; }

            public string Adres { get; set; }

            public string OgretmenAdi { get; set; }

            public string OgretmenSoyadi { get; set; }
        }

        public class AtolyeFotograflariViewModel
        {
            public int ID { get; set; }

            public string FotografLink { get; set; }

            public int Atolye_ID { get; set; }


        }
    }
}