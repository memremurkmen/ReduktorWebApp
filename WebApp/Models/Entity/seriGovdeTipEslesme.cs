//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class seriGovdeTipEslesme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public seriGovdeTipEslesme()
        {
            this.reduktor = new HashSet<reduktor>();
        }
    
        public int id { get; set; }
        public Nullable<int> seriId { get; set; }
        public Nullable<int> govdeId { get; set; }
        public Nullable<int> tipId { get; set; }
        public string reduktorTipAdi { get; set; }
        public Nullable<int> timestampId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reduktor> reduktor { get; set; }
        public virtual reduktorGovde reduktorGovde { get; set; }
        public virtual reduktorSeri reduktorSeri { get; set; }
        public virtual reduktorTip reduktorTip { get; set; }
        public virtual timestamp timestamp { get; set; }
    }
}
