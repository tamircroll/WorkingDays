using System;
using WorkingDaysApp.Enums;

namespace WorkingDaysApp.Logic
{
    public static class DayTypeFactory
    {
        public static string Get(eDayType dayType)
        {
            if (dayType == eDayType.Holyday) return "Holiday";
            if (dayType == eDayType.HalfDay) return "Half Vaction Day";
            if (dayType == eDayType.WorkDay) return "Work Day";
            if (dayType == eDayType.Vacation) return "Vacation";
            if (dayType == eDayType.SickDay) return "Sick day";

            throw new Exception("Bad eDayType parmeter input");
        }
    }
}
