using System;
using System.Drawing;

namespace Calendar.UserControl.HolidayEvents
{
    public class ColumbusDay : ICalendarEvent
    {
        public ColumbusDay()
        {
            EventId = Guid.NewGuid().ToString();
        }

        public bool ShouldRender(DateTime calendarDate)
        {
            if (calendarDate.Month != 10 || calendarDate.DayOfWeek != DayOfWeek.Monday) return false;

            var dt = new DateTime(calendarDate.Year, calendarDate.Month, 1);
            int mondays = 0;
            while (dt.Day < 31)
            {
                if (dt.DayOfWeek == DayOfWeek.Monday) mondays++;
                if (mondays == 2 && dt.Day == calendarDate.Day) return true;
                dt = dt.AddDays(1);
            }
            return false;
        }

        public Color BackgroundColor => Color.FromArgb(110, 200, 250);
        public Color TextColor => Color.Black;
        public Font Font => new Font("Arial", 10, FontStyle.Regular);
        public string EventName => "Columbus Day";
        public string EventId { get; }
        public int EventHeight => 15;
        public bool ShowIcon => false;
        public Bitmap Icon => null;
    }
}
