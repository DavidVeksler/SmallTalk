using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallTalk.Web.Models
{

    public class Availability
    {
        public int ProfileId { get; set; }
        public List<AvailabilityDay> Days { get; set; }
    }

    public class AvailabilityDay
    {
        public bool Morning;
        public bool Afternoon;
        public bool Evening;
    }

    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednsday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public enum TimeOfDay
    {
        Morning,
        Afternoon,
        Evening
    }
}