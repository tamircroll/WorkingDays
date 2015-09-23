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
            return isTimeSet() ? Time.Split(':')[0] : "";
        }

        public string SecondsStr()
        {
            return isTimeSet() ? Time.Split(':')[1] : "";
        }

        public int? HourInt()
        {
            int hour;
            return int.TryParse(HourStr(), out hour) ? hour : (int?) null;
        }

        public int? MinutesInt()
        {
            int hour;
            return int.TryParse(MinuteStr(), out hour) ? hour : (int?) null;
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

        public string Subtract(HourData toSubtract)
        {
            if (isTimeSet() && toSubtract != null && toSubtract.isTimeSet())
            {
                TimeSpan firsTimeSpan = new TimeSpan((int) HourInt(), (int) MinutesInt(), (int) SecondsInt());
                TimeSpan secondTimeSpan = new TimeSpan((int) toSubtract.HourInt(), (int) toSubtract.MinutesInt(),
                    (int) toSubtract.SecondsInt());
                TimeSpan time = firsTimeSpan - secondTimeSpan;
                return time.ToString().Contains("-") ? "" : time.ToString();
            }

            return "";
        }

        public string Add(HourData toSubtract)
        {
            if (isTimeSet() && toSubtract != null && toSubtract.isTimeSet())
            {
                TimeSpan firsTimeSpan = new TimeSpan((int) HourInt(), (int) MinutesInt(), (int) SecondsInt());
                TimeSpan secondTimeSpan = new TimeSpan((int) toSubtract.HourInt(), (int) toSubtract.MinutesInt(),
                    (int) toSubtract.SecondsInt());
                TimeSpan time = firsTimeSpan + secondTimeSpan;
                return time.ToString().Contains("-") ? "" : time.ToString();
            }

            return "";
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
