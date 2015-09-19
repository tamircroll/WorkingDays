using System;
using TimeWatchApp.Enums;

namespace TimeWatchApp.Logic
{
    public static class DayTypeFactory
    {
        public static string Get(eDayType i_DayType)
        {
            if (i_DayType == eDayType.Holiday) return "Holiday";
            if (i_DayType == eDayType.HalfHoliday) return "Half Holiday";
            if (i_DayType == eDayType.WorkDay) return "Work Day";
            if (i_DayType == eDayType.PersonalVacation) return "Personal vacation";
            if (i_DayType == eDayType.SickDay) return "Sick day";

            throw new Exception("Bad eDayType parmeter input");
        }

        public static eDayType Get(string i_DayType)
        {
            if (i_DayType == "Holiday") return eDayType.Holiday;
            if (i_DayType == "Half Holiday") return eDayType.HalfHoliday;
            if (i_DayType == "Work Day") return eDayType.WorkDay;
            if (i_DayType == "Personal vacation") return eDayType.PersonalVacation;
            if (i_DayType == "Sick day") return eDayType.SickDay;

            throw new Exception("Bad string parmeter input");
        }
    }
}
