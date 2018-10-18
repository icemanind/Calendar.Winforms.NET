using System;
using System.Drawing;

namespace Calendar.UserControl.HolidayEvents
{
    public class NewYears : ICalendarEvent
    {
        public NewYears()
        {
            EventId = Guid.NewGuid().ToString();
        }

        public bool ShouldRender(DateTime calendarDate)
        {
            return calendarDate.Month == 1 && calendarDate.Day == 1;
        }

        public Color BackgroundColor => Color.FromArgb(110, 200, 250);
        public Color TextColor => Color.Black;
        public Font Font => new Font("Arial", 10, FontStyle.Regular);
        public string EventName => "New Years Day";
        public string EventId { get; }
        public int EventHeight => 15;
        public bool ShowIcon => false;
        public Bitmap Icon => null;
    }
}
