//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KodlaManisa.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrtaokulSorular
    {
        public int SoruID { get; set; }
        public Nullable<int> OkulID { get; set; }
        public string Sorular { get; set; }
        public Nullable<short> Cevaplar { get; set; }
    
        public virtual tblOkullar tblOkullar { get; set; }
    }
}
