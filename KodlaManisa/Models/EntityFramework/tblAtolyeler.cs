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
    
    public partial class tblAtolyeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAtolyeler()
        {
            this.tblAtolyeFotograf = new HashSet<tblAtolyeFotograf>();
            this.tblAtolyeGelenZiyaretci = new HashSet<tblAtolyeGelenZiyaretci>();
            this.tblAtolyeKurslar = new HashSet<tblAtolyeKurslar>();
            this.tblAtolyeMalzemeler = new HashSet<tblAtolyeMalzemeler>();
            this.tblAtolyeOduncVerme = new HashSet<tblAtolyeOduncVerme>();
            this.tblAtolyeYapilanZiyaretler = new HashSet<tblAtolyeYapilanZiyaretler>();
        }
    
        public int AtolyeID { get; set; }
        public Nullable<int> AtolyeIlcesi { get; set; }
        public Nullable<int> AtolyeTuru { get; set; }
        public string AtolyeAdi { get; set; }
        public Nullable<int> OgretmenID { get; set; }
        public string AtolyeAdres { get; set; }
        public string AtolyeTel { get; set; }
        public string AtolyeCalismaSaati { get; set; }
        public string AtolyeFacebook { get; set; }
        public string AtolyeInstagram { get; set; }
        public string AtolyeTwitter { get; set; }
        public string AtolyeYoutube { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAtolyeFotograf> tblAtolyeFotograf { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAtolyeGelenZiyaretci> tblAtolyeGelenZiyaretci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAtolyeKurslar> tblAtolyeKurslar { get; set; }
        public virtual tblAtolyeTuru tblAtolyeTuru { get; set; }
        public virtual tblIlceler tblIlceler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAtolyeMalzemeler> tblAtolyeMalzemeler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAtolyeOduncVerme> tblAtolyeOduncVerme { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAtolyeYapilanZiyaretler> tblAtolyeYapilanZiyaretler { get; set; }
    }
}
