//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmallTalk.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProfileLessonAvailability
    {
        public int id { get; set; }
        public int ProfileId { get; set; }
        public int DayOfWeek { get; set; }
        public int TimeOfDay { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual Profile Profile { get; set; }
    }
}
