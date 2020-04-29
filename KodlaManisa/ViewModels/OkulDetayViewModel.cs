using KodlaManisa.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.ViewModels
{
    public class OkulDetayViewModel
    {
        public OkulDataViewModel Okul { get; set; }
        public TTakimiViewModel TTakimi { get; set; }
        public OkulProjeEkibiViewModel OkulEkibi { get; set; }
        //public IEnumerable<tblOkullar> Okullar {get;set;}
        public IEnumerable<tblOkulMalzemeler> Malzemeler { get; set; }
        public IEnumerable<tblSorular> Sorular {get; set;}
        //public SorularViewModel Sorular { get; set; }
       

    }

    public class OkulDataViewModel
    {
        public int OkulID { get; set; }
        public string OkulIlceAdi { get; set; }
        public string OkulAdi { get; set; }
        public string OkulTuru { get; set; }
        public string OkulMuduru { get; set; }
        public string OkulAdresi { get; set; }
        public string Eposta { get; set; }
        public string OkulTel { get; set; }
        public string OkulFax { get; set; }
        public string BTSayisi { get; set; }
    }

    public class TTakimiViewModel
    {
        public int ID { get; set; }
        public int Okul_ID { get; set; }
        public string TakimAdi { get; set; }
        public int Ogretmen_ID { get; set; }
        public int OgrenciSayisi { get; set; }
        public string KatildigiYarismaAdi { get; set; }
        public string OgretmenAdi { get; internal set; }
    }

    public class OkulProjeEkibiViewModel
    {
        public int EkipID { get; set; }
        public int OkulID { get; set; }
        public string Yonetici { get; set; }
        public string Ogretmen1 { get; set; }
        public string Ogretmen2 { get; set; }
    }

    //public class SorularViewModel
    //{
    //    public int ID { get; set; }
    //    public string Soru { get; set; }
    //    public int OkulTuru_ID { get; set;}

    //}

}