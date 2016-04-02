using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallTalk.Web.Models
{

    public class Availability
    {
        public AvailabilityTime TimeOfDay { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }

    public enum AvailabilityTime
    {
        Morning,
        Afternoon,
        Evening
    }

    //public enum DayOfWeek
    //{
    //    Monday,
    //    Tuesday,
    //    Wednsday,
    //    Thursday,
    //    Friday,
    //    Saturday,
    //    Sunday
    //}

    public enum TimeOfDay
    {
        Morning,
        Afternoon,
        Evening
    }
}