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
        public IEnumerable<tblOkulOgretmenler> OgretmenOkul { get; set; }
        public IEnumerable<tblOkulOgrenciler> OgrenciOkul { get; set; }
        public List<tblAtolyeKursOgrencileri> Ogrenciler { get; internal set; }
        public string AtolyeAdi { get; internal set; }
        public string KursAdi { get; internal set; }

        public class AtolyeDataViewModel
        {
            public int ID { get; set; }
            public string Adi { get; set; }

            public string CalismaSaati { get; set; }

            public string Adres { get; set; }

            public string AtolyeFacebook { get; set; }
            public string AtolyeInstagram { get; set; }
            public string AtolyeTwitter { get; set; }
            public string AtolyeYoutube { get; set; }

            public string OgretmenAdi { get; set; }

            public string OgretmenSoyadi { get; set; }
            public dynamic AtolyeAdi { get; internal set; }
            public dynamic KursAdi { get; internal set; }
        }

        public class AtolyeFotograflariViewModel
        {
            public int ID { get; set; }

            public string FotografLink { get; set; }

            public int Atolye_ID { get; set; }


        }


 
      
    }
}