using System;
using TimeWatchApp.Enums;

namespace TimeWatchApp.Logic
{
    public static class DayTypeFactory
    {
        public static string Get(eDayType i_DayType)
        {
            if (i_DayType == eDayType.Holiday) return "Holiday";
            if (i_DayType == eDayType.HalfDay) return "Half Holiday";
            if (i_DayType == eDayType.WorkDay) return "Work Day";
            if (i_DayType == eDayType.PersonalVacation) return "Personal vacation";
            if (i_DayType == eDayType.SickDay) return "Sick day";

            throw new Exception("Bad eDayType parmeter input");
        }
    }
}
