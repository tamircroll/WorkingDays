using System;

namespace WorkingDaysApp.Logic.TimeData
{
    public class HourData
    {
        private string m_Time = "";

        public HourData(string i_Time)
        {
            if (isTimeValid(i_Time))
            {
                m_Time = i_Time;
            }
        }

        public HourData()
        {
            m_Time = "";
        }

        public HourData(DateTime i_Time)
        {
            if (m_Time != null)
                Time = string.Format("{0}:{1}:{2}", i_Time.Hour, i_Time.Minute, i_Time.Second);
        }

        public string Time
        {
            get { return m_Time; }
            set
            {
                if (isTimeValid(value))
                    m_Time = value;
            }
        }

        public string HourStr()
        {
            return isTimeSet() ? Time.Split(':')[0] : "";
        }

        public string MinuteStr()
        {
            return isTimeSet() ? Time.Split(':')[1] : "";
        }

        public string SecondsStr()
        {
            return isTimeSet() ? Time.Split(':')[2] : "";
        }

        public int? HourInt()
        {
            int hour;
            return int.TryParse(HourStr(), out hour) ? hour : (int?) null;
        }

        public int? MinutesInt()
        {
            int minute;
            return int.TryParse(MinuteStr(), out minute) ? minute : (int?)null;
        }

        public int? SecondsInt()
        {
            int seconds;
            return int.TryParse(SecondsStr(), out seconds) ? seconds : (int?) null;
        }

        public DateTime? AsDateTime()
        {
            return isTimeSet() ? (DateTime?) null : DateTime.Parse(m_Time);
        }

        public string Subtract(HourData i_ToSubtract)
        {
            if (isTimeSet() && i_ToSubtract != null && i_ToSubtract.isTimeSet())
            {
                TimeSpan? time = AsTimeSpan() - i_ToSubtract.AsTimeSpan();
                return time.ToString().Replace(TimeWatch2.sr_RowSeparatorStr, TimeWatch2.sr_DashReplacer);
            }

            return "";
        }

        public string Add(HourData i_ToAdd)
        {
            if (isTimeSet() && i_ToAdd != null && i_ToAdd.isTimeSet())
            {
                TimeSpan? time = AsTimeSpan() + i_ToAdd.AsTimeSpan();
                return time.ToString().Replace(TimeWatch2.sr_RowSeparatorStr, TimeWatch2.sr_DashReplacer);
            }

            return "";
        }

        public TimeSpan? AsTimeSpan()
        {
            int? hourInt = HourInt(), minutesInt = MinutesInt(), secondsInt = SecondsInt();

            if (hourInt != null && minutesInt != null && secondsInt != null)
                return new TimeSpan((int) hourInt, (int) minutesInt, (int) secondsInt);

            return null;
        }

        public bool isTimeSet()
        {
            return !string.IsNullOrEmpty(m_Time);
        }

        private bool isTimeValid(string i_Time)
        {
            int hour, minutes, seconds;
            string[] timeArr = i_Time.Split(':');

            if (timeArr.Length != 3) return false;

            if (!int.TryParse(timeArr[0], out hour) ||
                !int.TryParse(timeArr[1], out minutes) ||
                !int.TryParse(timeArr[2], out seconds))
                return false;

            if (hour < 0 || hour >= 24 ||
                minutes < 0 || minutes >= 60 ||
                seconds < 0 || seconds >= 60)
                return false;

            return true;
        }

        public override string ToString()
        {
            return isTimeSet() ? Time : "";
        }

        public override bool Equals(object i_Other)
        {
            HourData other = i_Other as HourData;
            return other != null && Time == other.Time;
        }
    }
}
