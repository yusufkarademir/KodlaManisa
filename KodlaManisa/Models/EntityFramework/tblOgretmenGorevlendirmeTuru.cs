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
    
    public partial class tblOgretmenGorevlendirmeTuru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOgretmenGorevlendirmeTuru()
        {
            this.tblOgretmenler = new HashSet<tblOgretmenler>();
        }
    
        public int GorevlendirmeID { get; set; }
        public string GorevAdi { get; set; }
        public Nullable<System.DateTime> BaslamaTarihi { get; set; }
        public Nullable<System.DateTime> BitisTarihi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOgretmenler> tblOgretmenler { get; set; }
    }
}
