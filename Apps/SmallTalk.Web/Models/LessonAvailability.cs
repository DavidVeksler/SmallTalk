using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallTalk.Web.Models
{

    public class Availability
    {
        public AvailabilityTime Time { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }

    public class AvailabilityTime
{
        public bool Morning;
        public bool Afternoon;
        public bool Evening;
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