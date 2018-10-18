using System;
using System.Drawing;

namespace Calendar.UserControl.HolidayEvents
{
    public class IndependenceDay : ICalendarEvent
    {
        public IndependenceDay()
        {
            EventId = Guid.NewGuid().ToString();
        }

        public bool ShouldRender(DateTime calendarDate)
        {
            return calendarDate.Month == 7 && calendarDate.Day == 4;
        }

        public Color BackgroundColor => Color.FromArgb(250, 90, 90);
        public Color TextColor => Color.Black;
        public Font Font => new Font("Arial", 10, FontStyle.Regular);
        public string EventName => "Independence Day";
        public string EventId { get; }
        public int EventHeight => 15;
        public bool ShowIcon => false;
        public Bitmap Icon => null;
    }
}
