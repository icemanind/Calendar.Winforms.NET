using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Calendar.UserControl.HolidayEvents
{
    public class Thanksgiving : ICalendarEvent
    {
        public Thanksgiving()
        {
            EventId = Guid.NewGuid().ToString();

            Assembly myAssembly = Assembly.GetExecutingAssembly();
            using (Stream myStream = myAssembly.GetManifestResourceStream("Calendar.UserControl.HolidayIcons.Turkey.png"))
            {
                Icon = null;
                if (myStream != null) Icon = new Bitmap(myStream);
            }
        }

        public bool ShouldRender(DateTime calendarDate)
        {
            if (calendarDate.Month != 11 || calendarDate.DayOfWeek != DayOfWeek.Thursday) return false;

            var dt = new DateTime(calendarDate.Year, calendarDate.Month, 1);
            int thursdays = 0;
            while (dt.Day < 30)
            {
                if (dt.DayOfWeek == DayOfWeek.Thursday) thursdays++;
                if (thursdays == 4 && dt.Day == calendarDate.Day) return true;
                dt = dt.AddDays(1);
            }
            return false;
        }

        public Color BackgroundColor => Color.FromArgb(110, 200, 250);
        public Color TextColor => Color.Black;
        public Font Font => new Font("Arial", 10, FontStyle.Regular);
        public string EventName => "Thanksgiving";
        public string EventId { get; }
        public int EventHeight => 43;
        public bool ShowIcon => true;
        public Bitmap Icon
        {
            get;
        }
    }
}
