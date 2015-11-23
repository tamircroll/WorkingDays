using System;
using TimeWatchApp.Enums;

namespace TimeWatchApp.Logic
{
    public static class DayTypeFactory
    {
        public static string Get(eDayType i_DayType)
        {
            if (i_DayType == eDayType.Holiday) return "Holiday";
            if (i_DayType == eDayType.HalfWorkDay) return "Half Work Day";
            if (i_DayType == eDayType.WorkDay) return "Work Day";
            if (i_DayType == eDayType.PersonalVacation) return "Personal vacation";
            if (i_DayType == eDayType.SickDay) return "Sick day";

            throw new Exception("Bad eDayType parmeter input");
        }

        public static eDayType Get(string i_DayType)
        {
            if (i_DayType == Get(eDayType.Holiday)) return eDayType.Holiday;
            if (i_DayType == Get(eDayType.HalfWorkDay)) return eDayType.HalfWorkDay;
            if (i_DayType == Get(eDayType.WorkDay)) return eDayType.WorkDay;
            if (i_DayType == Get(eDayType.PersonalVacation)) return eDayType.PersonalVacation;
            if (i_DayType == Get(eDayType.SickDay)) return eDayType.SickDay;

            throw new Exception("Bad string parmeter input");
        }
    }
}
