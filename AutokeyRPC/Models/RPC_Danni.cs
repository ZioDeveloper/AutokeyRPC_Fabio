//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutokeyRPC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RPC_Danni
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RPC_Danni()
        {
            this.RPC_DanniXTelaio = new HashSet<RPC_DanniXTelaio>();
        }
    
        public int ID { get; set; }
        public string Descr { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RPC_DanniXTelaio> RPC_DanniXTelaio { get; set; }
    }
}
