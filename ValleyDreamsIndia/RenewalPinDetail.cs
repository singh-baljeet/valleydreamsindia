//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ValleyDreamsIndia
{
    using System;
    using System.Collections.Generic;
    
    public partial class RenewalPinDetail
    {
        public int Id { get; set; }
        public Nullable<int> SponsoredId { get; set; }
        public Nullable<int> RecipientId { get; set; }
        public Nullable<int> IsPinUsed { get; set; }
        public Nullable<System.DateTime> PinCreatedOn { get; set; }
        public Nullable<int> Deleted { get; set; }
    
        public virtual UsersDetail UsersDetail { get; set; }
        public virtual UsersDetail UsersDetail1 { get; set; }
    }
}
