using System;
using System.Drawing;

namespace Calendar.UserControl.HolidayEvents
{
    public class MemorialDay : ICalendarEvent
    {
        public MemorialDay()
        {
            EventId = Guid.NewGuid().ToString();
        }

        public bool ShouldRender(DateTime calendarDate)
        {
            if (calendarDate.Month != 5 || calendarDate.DayOfWeek != DayOfWeek.Monday) return false;

            return calendarDate.AddDays(7).Month != 5;
        }

        public Color BackgroundColor => Color.FromArgb(110, 200, 250);
        public Color TextColor => Color.Black;
        public Font Font => new Font("Arial", 10, FontStyle.Regular);
        public string EventName => "Memorial Day";
        public string EventId { get; }
        public int EventHeight => 15;
        public bool ShowIcon => false;
        public Bitmap Icon => null;
    }
}
