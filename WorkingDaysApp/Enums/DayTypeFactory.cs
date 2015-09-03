using System;
using WorkingDaysApp.Enums;

namespace WorkingDaysApp.Logic
{
    public static class DayTypeFactory
    {
        public static string Get(eDayType dayType)
        {
            if (dayType == eDayType.DayOff) return "Day Off";
            if (dayType == eDayType.HalfDay) return "Half Day";
            if (dayType == eDayType.WorkDay) return "Work Day";

            throw new Exception("Bad eDayType parmeter input");
        }
    }
}
