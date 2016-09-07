//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace UsingEFInAzureSQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lodging
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lodging()
        {
            this.Events = new HashSet<Event>();
        }
    
        public int LodgingID { get; set; }
        public string LodgingName { get; set; }
        public int ContactID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public bool Resort { get; set; }
        public string ResortChainOwner { get; set; }
        public bool LuxuryResort { get; set; }
    
        public virtual Contact Contact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
        public virtual Location Location { get; set; }
    }
}
