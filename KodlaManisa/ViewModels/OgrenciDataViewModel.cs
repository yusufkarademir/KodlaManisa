using KodlaManisa.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodlaManisa.ViewModels
{
    public class OgrenciDataViewModel
    {
        public IEnumerable<tblOgrenciler> Ogrenci { get; set; }

        public OkulOgretmenleriViewModel Okul { get; set; }
        

    }

    public class OkulOgretmenleriViewModel
    {
        public int ID { get; set; }

        public Boolean AktifCalistigi { get; set; }

        public string Sinif { get; set; }

        public int OgrenciSayisi { get; set; }

        public int Okul_ID { get; set; }

        public string OkulAdi { get; set; }

        public int Ogretmen_ID { get; set; }
    }

}