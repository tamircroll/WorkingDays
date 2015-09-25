using System;
using TimeWatchApp.Enums;

namespace WorkingDaysApp.Logic.TimeData
{
    public class Summary
    {
        private readonly MonthData m_MonthData;

        public Summary(MonthData i_MonthData)
        {
            m_MonthData = i_MonthData;
        }

        public float TotalVacationsDay()
        {
            float sum = 0;
            foreach (DayData day in m_MonthData.AllDays)
            {
                if (day.DayType == eDayType.PersonalVacation)
                    sum++;
            }

            return sum;
        }

        public int TotalSickDays()
        {
            int sum = 0;
            foreach (DayData day in m_MonthData.AllDays)
            {
                if (day.DayType == eDayType.SickDay)
                    sum++;
            }

            return sum;
        }

        public float TotalHolidays()
        {
            float sum = 0;
            foreach (DayData day in m_MonthData.AllDays)
            {
                if (day.DayType == eDayType.Holiday) sum++;
                else if (day.DayType == eDayType.HalfHoliday) sum += 0.5f;
            }

            return sum;
        }

        public string TotalHours()
        {
            HourData total = new HourData("00:00:00");
            foreach (DayData day in m_MonthData.AllDays)
            {
                if (!String.IsNullOrEmpty(day.TotalHoursStr()))
                    total = new HourData(total.Add(new HourData(day.TotalHoursStr())));
            }

            return total.ToString();
        }

        public float AllWorkingDays()
        {
            float sum = 0;
            foreach (DayData day in m_MonthData.AllDays)
            {
                sum += dayWorkScope(day);
            }

            return sum;
        }

        private static float dayWorkScope(DayData i_DayArr)
        {
            int minutes = i_DayArr.TotalMinutesStr();

            if (minutes >= TimeWatch.FULL_DAY_MINUTES) return 1.0f;
            if (minutes >= TimeWatch.HALF_DAY_MINUTES) return 0.5f;
            return 0.0f;
        }
    }
}
