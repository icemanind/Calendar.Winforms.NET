using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar.UserControl
{
    [ToolboxBitmap(typeof(Calendar), "Calendar_icon")]
    public class Calendar : System.Windows.Forms.UserControl
    {
        public bool ShowTodayButton { get; set; }
        public Font TodayButtonFont { get; set; }
        public bool ShowPreviousMonthButton { get; set; }
        public bool ShowNextMonthButton { get; set; }
        public bool ShowMonthYear { get; set; }
        public Font CalendarEventsFont { get; set; }
        public Font CalendarFont { get; set; }

        public Calendar()
        {
            ShowTodayButton = true;
            ShowPreviousMonthButton = true;
            ShowNextMonthButton = true;
            ShowMonthYear = true;
            TodayButtonFont = new Font("Arial", 24, FontStyle.Bold);
            CalendarEventsFont = new Font("Arial", 12, FontStyle.Regular);
            CalendarFont = new Font("Arial", 12, FontStyle.Regular);
        }
    }
}
