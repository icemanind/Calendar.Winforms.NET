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
        public Color TodayButtonColor { get; set; }
        public Color TodayButtonTextColor { get; set; }
        public bool ShowPreviousMonthButton { get; set; }
        public bool ShowNextMonthButton { get; set; }
        public bool ShowMonthYear { get; set; }
        public Font CalendarEventsFont { get; set; }
        public Font CalendarFont { get; set; }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public CalendarSizeModes CalendarSizeMode { get; set; }

        private const int TopMargin = 15;

        public Calendar()
        {
            InitializeComponent();

            ShowTodayButton = true;
            ShowPreviousMonthButton = true;
            ShowNextMonthButton = true;
            ShowMonthYear = true;
            TodayButtonFont = new Font("Arial", 24, FontStyle.Bold);
            TodayButtonColor = Color.FromArgb(200, 200, 200);
            TodayButtonTextColor = Color.FromArgb(100, 100, 100);
            CalendarEventsFont = new Font("Arial", 12, FontStyle.Regular);
            CalendarFont = new Font("Arial", 12, FontStyle.Regular);
            BackgroundColor = Color.Transparent;
            BorderColor = Color.FromArgb(200, 200, 200);
            CalendarSizeMode = CalendarSizeModes.Stretch;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.DoubleBuffered = true;
            this.Name = "Calendar";
            this.Size = new System.Drawing.Size(849, 571);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Calendar_Paint);
            this.ResumeLayout(false);

        }

        private void Calendar_Paint(object sender, PaintEventArgs e)
        {
            var bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(BackgroundColor);
                g.DrawLine(new Pen(Color.Green), 0, 0, 50, 50);
            }

            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
