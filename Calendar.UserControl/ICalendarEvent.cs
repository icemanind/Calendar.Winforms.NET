using System;
using System.Drawing;

namespace Calendar.UserControl
{
    public interface ICalendarEvent
    {
        bool ShouldRender(DateTime calendarDate);
        Color BackgroundColor { get; }
        Color TextColor { get; }
        Font Font { get; }
        string EventName { get; }
        string EventId { get; }
        int EventHeight { get; }
        bool ShowIcon { get; }
        Bitmap Icon { get; }
    }
}
