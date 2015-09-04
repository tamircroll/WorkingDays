using System;
using WorkingDaysApp.Enums;

namespace WorkingDaysApp.Logic
{
    public static class DayTypeFactory
    {
        public static string Get(eDayType dayType)
        {
            if (dayType == eDayType.Holiday) return "Holiday";
            if (dayType == eDayType.HalfDay) return "Half Holiday";
            if (dayType == eDayType.WorkDay) return "Work Day";
            if (dayType == eDayType.PersonalVacation) return "Personal vacation";
            if (dayType == eDayType.SickDay) return "Sick day";

            throw new Exception("Bad eDayType parmeter input");
        }
    }
}
