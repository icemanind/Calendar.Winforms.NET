using System.Windows.Forms;

namespace Calendar.UserControl
{
    public class CalendarMouseEventArgs : MouseEventArgs
    {
        public bool Handled { get; set; }

        public CalendarMouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta) : base(button, clicks, x, y, delta)
        {
        }
    }
}
