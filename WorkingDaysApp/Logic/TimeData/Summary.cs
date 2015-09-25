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
            TimeData total = new TimeData("00:00:00");
            foreach (DayData day in m_MonthData.AllDays)
            {
                if (!String.IsNullOrEmpty(day.TotalHoursStr()))
                    total = new TimeData(total.Add(new TimeData(day.TotalHoursStr())));
            }

            return total.ToString();
        }

        public float TotalHours()
        {
            float total = 0;
            foreach (DayData day in m_MonthData.AllDays)
            {
                if (!String.IsNullOrEmpty(day.TotalHoursStr()))
                {
                    TimeData hours = new TimeData(day.TotalHoursStr());
                    int? hourInt = hours.HourInt();
                    int? minutesInt = hours.MinutesInt();
                    if (hourInt != null) total += (float)hourInt;
                    if (minutesInt != null) total += (((float)minutesInt)/60);
                }
            }

            return total;
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
            int? hourInt = new TimeData(TotalHoursStr()).HourInt();

            if (hourInt == null || hourInt == 0) return String.Format("{0:0.00}", 0);
            if (TotalHours() == 0) return String.Format("{0:0.00}", 0);

            float time = TotalHours() / AllWorkingDays();
            int minutes = (int)((time - (int)time) * 100);

            minutes = minutes * 60 / 100;

            string timeStr = time.ToString();
            string hours = timeStr.Split('.')[0];

            return String.Format("{0}:{1}", hours, minutes);
        }
    }
}
