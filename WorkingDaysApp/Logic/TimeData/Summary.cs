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

        public string TotalHoursStr()
        {
            float hourInt = TotalHours();
            if (hourInt == 0) return "0:00";

            return timeFloatToString(TotalHours());
        }

        public float TotalHours()
        {
            float total = 0;
            foreach (DayData day in m_MonthData.AllDays)
            {
                if (!String.IsNullOrEmpty(day.TotalHoursStr()))
                {
                    total += day.TotalSecondsStr();
                }
            }

            return total / 3600;
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

        public string AverageHours()
        {
            float hourInt = TotalHours();
            if (hourInt == 0 || AllWorkingDays() == 0) return "0:00";

            float time = TotalHours() / AllWorkingDays();

            return timeFloatToString(time);
        }

        private string timeFloatToString(float time)
        {
            int minutes = (int) ((time - (int) time) * 100);
            minutes = minutes * 60 / 100;

            string timeStr = time.ToString();
            string hours = timeStr.Split('.')[0];

            string zero = (minutes <= 9) ? "0" : "";

            return String.Format("{0}:{1}{2}", hours, zero, minutes);
        }
    }
}
