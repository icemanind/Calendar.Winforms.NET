using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar.UserControl
{
    [ToolboxBitmap(typeof(Calendar), "Calendar.UserControl.Resources.Calendar-icon.png")]
    public class Calendar : System.Windows.Forms.UserControl
    {
        #region Fields
        private Size _todayButtonSize;
        private bool _showTodayButton;
        private Font _todayButtonFont;
        private Color _todayButtonColor;
        private Color _todayButtonHoverColor;
        private Color _todayButtonBorderColor;
        private Color _todayButtonBorderHoverColor;
        private Color _todayButtonTextColor;
        private Size _previousMonthButtonSize;
        private Size _nextMonthButtonSize;
        private Color _previousMonthButtonBorderColor;
        private Color _previousMonthButtonBorderHoverColor;
        private Color _previousMonthButtonColor;
        private Color _previousMonthButtonHoverColor;
        private Color _previousMonthButtonTextColor;
        private Color _nextMonthButtonBorderColor;
        private Color _nextMonthButtonBorderHoverColor;
        private Color _nextMonthButtonColor;
        private Color _nextMonthButtonHoverColor;
        private Color _nextMonthButtonTextColor;
        private Font _nextMonthButtonFont;
        private Font _previousMonthButtonFont;
        private bool _showPreviousMonthButton;
        private bool _showNextMonthButton;
        private bool _showMonthYear;
        private bool _showDaysOfWeek;
        private Font _calendarEventsFont;
        private Font _calendarFont;
        private Color _calendarTextColor;
        private Color _calendarDisabledTextColor;
        private Color _backgroundColor;
        private Color _borderColor;
        private CalendarSizeModes _calendarSizeMode;
        private CalendarViewModes _calendarViewMode;
        private DateTime _calendarDate;
        private Color _daysOfTheWeekTextColor;
        private Color _daysOfTheWeekBackgroundColor;
        private Font _daysOfTheWeekFont;
        private Font _daysFont;
        private Color _daysTextColor;
        private Color _daysBackgroundColor;
        private Color _daysDisabledTextColor;
        private Color _daysDisabledBackgroundColor;
        private Padding _calendarPadding;
        private Color _monthYearTextColor;
        private Color _monthYearBackgroundColor;
        private Font _monthYearFont;
        private bool _renderHolidays;

        private bool _todayButtonHovered;
        private bool _previousMonthButtonHovered;
        private bool _nextMonthButtonHovered;

        private readonly List<ICalendarEvent> _calendarEvents;
        private readonly List<ICalendarEvent> _holidayEvents;
        private readonly Dictionary<Rectangle, ICalendarEvent> _eventsMatrix;
        private readonly Dictionary<Rectangle, DateTime> _daysMatrix;

        private readonly ToolTip _eventTooltip;
        private Point _lastMousePoint;

        #endregion

        #region Delegates
        public delegate void CalendarMouseClickHandler(object sender, CalendarMouseEventArgs e);

        public delegate void CalendarEventClickHandler(object sender, CalendarMouseEventArgs e, ICalendarEvent ev);

        public delegate void CalendarDayClickHandler(object sender, CalendarMouseEventArgs e, DateTime dt);

        #endregion

        #region Events
        public event CalendarMouseClickHandler TodayButtonClicked;
        public event CalendarMouseClickHandler PreviousMonthButtonClicked;
        public event CalendarMouseClickHandler NextMonthButtonClicked;
        public event CalendarEventClickHandler CalendarEventClicked;
        public event CalendarDayClickHandler CalendarDayClicked;

        public event CalendarMouseClickHandler TodayButtonDoubleClicked;
        public event CalendarMouseClickHandler PreviousMonthButtonDoubleClicked;
        public event CalendarMouseClickHandler NextMonthButtonDoubleClicked;
        public event CalendarEventClickHandler CalendarEventDoubleClicked;
        public event CalendarDayClickHandler CalendarDayDoubleClicked;
        #endregion

        #region Properties

        public bool RenderHolidays
        {
            get => _renderHolidays;
            set
            {
                _renderHolidays = value;
                if (_holidayEvents == null)
                {
                    Refresh();
                    return;
                }
                if (value)
                    _holidayEvents.ForEach(z => RegisterEvent(z));
                else _holidayEvents.ForEach(RemoveEvent);
                Refresh();
            }
        }

        public string CalendarTheme
        {
            get; private set;
        }

        public Color PreviousMonthButtonBorderHoverColor
        {
            get => _previousMonthButtonBorderHoverColor;
            set
            {
                _previousMonthButtonBorderHoverColor = value;
                Refresh();
            }
        }

        public Color PreviousMonthButtonHoverColor
        {
            get => _previousMonthButtonHoverColor;
            set
            {
                _previousMonthButtonHoverColor = value;
                Refresh();
            }
        }

        public Color NextMonthButtonBorderHoverColor
        {
            get => _nextMonthButtonBorderHoverColor;
            set
            {
                _nextMonthButtonBorderHoverColor = value;
                Refresh();
            }
        }

        public Color NextMonthButtonHoverColor
        {
            get => _nextMonthButtonHoverColor;
            set
            {
                _nextMonthButtonHoverColor = value;
                Refresh();
            }
        }

        public Color TodayButtonBorderHoverColor
        {
            get => _todayButtonBorderHoverColor;
            set
            {
                _todayButtonBorderHoverColor = value;
                Refresh();
            }
        }

        public Color TodayButtonHoverColor
        {
            get => _todayButtonHoverColor;
            set
            {
                _todayButtonHoverColor = value;
                Refresh();
            }
        }

        public Color MonthYearTextColor
        {
            get => _monthYearTextColor;
            set
            {
                _monthYearTextColor = value;
                Refresh();
            }
        }

        public Color MonthYearBackgroundColor
        {
            get => _monthYearBackgroundColor;
            set
            {
                _monthYearBackgroundColor = value;
                Refresh();
            }
        }

        public Font MonthYearFont
        {
            get => _monthYearFont;
            set
            {
                _monthYearFont = value;
                Refresh();
            }
        }

        public Padding CalendarPadding
        {
            get => _calendarPadding;
            set
            {
                _calendarPadding = value;
                Refresh();
            }
        }

        public Color DaysDisabledTextColor
        {
            get => _daysDisabledTextColor;
            set
            {
                _daysDisabledTextColor = value;
                Refresh();
            }
        }

        public Color DaysDisabledBackgroundColor
        {
            get => _daysDisabledBackgroundColor;
            set
            {
                _daysDisabledBackgroundColor = value;
                Refresh();
            }
        }

        public Color DaysTextColor
        {
            get => _daysTextColor;
            set
            {
                _daysTextColor = value;
                Refresh();
            }
        }

        public Color DaysBackgroundColor
        {
            get => _daysBackgroundColor;
            set
            {
                _daysBackgroundColor = value;
                Refresh();
            }
        }

        public Font DaysFont
        {
            get => _daysFont;
            set
            {
                _daysFont = value;
                Refresh();
            }
        }

        public Font DaysOfTheWeekFont
        {
            get => _daysOfTheWeekFont;
            set
            {
                _daysOfTheWeekFont = value;
                Refresh();
            }
        }

        public Color DaysOfTheWeekTextColor
        {
            get => _daysOfTheWeekTextColor;
            set
            {
                _daysOfTheWeekTextColor = value;
                Refresh();
            }
        }

        public Color DaysOfTheWeekBackgroundColor
        {
            get => _daysOfTheWeekBackgroundColor;
            set
            {
                _daysOfTheWeekBackgroundColor = value;
                Refresh();
            }
        }

        public bool ShowDaysOfWeek
        {
            get => _showDaysOfWeek;
            set
            {
                _showDaysOfWeek = value;
                Refresh();
            }
        }

        public Color CalendarTextColor
        {
            get => _calendarTextColor;
            set
            {
                _calendarTextColor = value;
                Refresh();
            }
        }

        public Color CalendarDisabledTextColor
        {
            get => _calendarDisabledTextColor;
            set
            {
                _calendarDisabledTextColor = value;
                Refresh();
            }
        }

        public Color PreviousMonthButtonColor
        {
            get => _previousMonthButtonColor;
            set
            {
                _previousMonthButtonColor = value;
                Refresh();
            }
        }

        public Color PreviousMonthButtonBorderColor
        {
            get => _previousMonthButtonBorderColor;
            set
            {
                _previousMonthButtonBorderColor = value;
                Refresh();
            }
        }

        public Color PreviousMonthButtonTextColor
        {
            get => _previousMonthButtonTextColor;
            set
            {
                _previousMonthButtonTextColor = value;
                Refresh();
            }
        }

        public Color NextMonthButtonColor
        {
            get => _nextMonthButtonColor;
            set
            {
                _nextMonthButtonColor = value;
                Refresh();
            }
        }

        public Color NextMonthButtonBorderColor
        {
            get => _nextMonthButtonBorderColor;
            set
            {
                _nextMonthButtonBorderColor = value;
                Refresh();
            }
        }

        public Color NextMonthButtonTextColor
        {
            get => _nextMonthButtonTextColor;
            set
            {
                _nextMonthButtonTextColor = value;
                Refresh();
            }
        }

        public Font PreviousMonthButtonFont
        {
            get => _previousMonthButtonFont;
            set
            {
                _previousMonthButtonFont = value;
                Refresh();
            }
        }

        public Font NextMonthButtonFont
        {
            get => _nextMonthButtonFont;
            set
            {
                _nextMonthButtonFont = value;
                Refresh();
            }
        }

        public Size TodayButtonSize
        {
            get => _todayButtonSize;
            set
            {
                _todayButtonSize = value;
                Refresh();
            }
        }

        public bool ShowTodayButton
        {
            get => _showTodayButton;
            set
            {
                _showTodayButton = value;
                Refresh();
            }
        }

        public Font TodayButtonFont
        {
            get => _todayButtonFont;
            set
            {
                _todayButtonFont = value;
                Refresh();
            }
        }

        public Color TodayButtonColor
        {
            get => _todayButtonColor;
            set
            {
                _todayButtonColor = value;
                Refresh();
            }
        }

        public Color TodayButtonBorderColor
        {
            get => _todayButtonBorderColor;
            set
            {
                _todayButtonBorderColor = value;
                Refresh();
            }
        }

        public Color TodayButtonTextColor
        {
            get => _todayButtonTextColor;
            set
            {
                _todayButtonTextColor = value;
                Refresh();
            }
        }

        public bool ShowPreviousMonthButton
        {
            get => _showPreviousMonthButton;
            set
            {
                _showPreviousMonthButton = value;
                Refresh();
            }
        }

        public bool ShowNextMonthButton
        {
            get => _showNextMonthButton;
            set
            {
                _showNextMonthButton = value;
                Refresh();
            }
        }

        public bool ShowMonthYear
        {
            get => _showMonthYear;
            set
            {
                _showMonthYear = value;
                Refresh();
            }
        }

        public Font CalendarEventsFont
        {
            get => _calendarEventsFont;
            set
            {
                _calendarEventsFont = value;
                Refresh();
            }
        }

        public Font CalendarFont
        {
            get => _calendarFont;
            set
            {
                _calendarFont = value;
                Refresh();
            }
        }

        public Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                Refresh();
            }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Refresh();
            }
        }

        public CalendarSizeModes CalendarSizeMode
        {
            get => _calendarSizeMode;
            set
            {
                _calendarSizeMode = value;
                Refresh();
            }
        }

        public CalendarViewModes CalendarViewMode
        {
            get => _calendarViewMode;
            set
            {
                _calendarViewMode = value;
                Refresh();
            }
        }

        public Size PreviousMonthButtonSize
        {
            get => _previousMonthButtonSize;
            set
            {
                _previousMonthButtonSize = value;
                Refresh();
            }
        }

        public Size NextMonthButtonSize
        {
            get => _nextMonthButtonSize;
            set
            {
                _nextMonthButtonSize = value;
                Refresh();
            }
        }

        public DateTime CalendarDate
        {
            get => _calendarDate;
            set
            {
                _calendarDate = value;
                Refresh();
            }
        }
        #endregion

        #region Constants
        private const int ButtonRadius = 10;
        #endregion

        #region Constructor
        public Calendar()
        {
            InitializeComponent();

            _todayButtonHovered = false;
            _previousMonthButtonHovered = false;
            _nextMonthButtonHovered = false;

            CalendarDate = DateTime.Now;
            CalendarTextColor = Color.FromArgb(0, 0, 0);
            CalendarDisabledTextColor = Color.FromArgb(190, 190, 190);
            ShowTodayButton = true;
            ShowPreviousMonthButton = true;
            ShowNextMonthButton = true;
            ShowMonthYear = true;
            ShowDaysOfWeek = true;
            RenderHolidays = true;

            CalendarEventsFont = new Font("Arial", 12, FontStyle.Regular);
            CalendarFont = new Font("Arial", 11, FontStyle.Regular);
            CalendarSizeMode = CalendarSizeModes.Stretch;
            CalendarViewMode = CalendarViewModes.Month;

            CalendarPadding = new Padding(10, 10, 10, 10);

            SetTheme(new Themes.BlueTheme());

            _eventsMatrix = new Dictionary<Rectangle, ICalendarEvent>();
            _daysMatrix = new Dictionary<Rectangle, DateTime>();
            _holidayEvents = new List<ICalendarEvent>();
            _lastMousePoint = new Point(0, 0);
            _calendarEvents = new List<ICalendarEvent>();
            _eventTooltip = new ToolTip();

            _holidayEvents.Add(new HolidayEvents.NewYears());
            _holidayEvents.Add(new HolidayEvents.MartinLutherKing());
            _holidayEvents.Add(new HolidayEvents.MemorialDay());
            _holidayEvents.Add(new HolidayEvents.PresidentsDay());
            _holidayEvents.Add(new HolidayEvents.IndependenceDay());
            _holidayEvents.Add(new HolidayEvents.LaborDay());
            _holidayEvents.Add(new HolidayEvents.ColumbusDay());
            _holidayEvents.Add(new HolidayEvents.VeteransDay());
            _holidayEvents.Add(new HolidayEvents.Thanksgiving());
            _holidayEvents.Add(new HolidayEvents.Halloween());
            _holidayEvents.Add(new HolidayEvents.Christmas());
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
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Calendar_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Calendar_MouseDoubleClick);
            this.MouseLeave += new System.EventHandler(this.Calendar_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Calendar_MouseMove);
            this.Resize += new System.EventHandler(this.Calendar_Resize);
            this.ResumeLayout(false);

        }
        #endregion

        public void RegisterEvent(params ICalendarEvent[] e)
        {
            foreach (ICalendarEvent ev in e)
            {
                if (_calendarEvents.FirstOrDefault(z => z.EventId == ev.EventId) == null)
                {
                    _calendarEvents.Add(ev);
                }
            }
        }

        public void RemoveEvent(ICalendarEvent e)
        {
            if (_calendarEvents.FirstOrDefault(z => z.EventId == e.EventId) != null)
            {
                _calendarEvents.Remove(e);
            }
        }

        public void RemoveEvent(string eventName)
        {
            var list = new List<ICalendarEvent>();

            foreach (ICalendarEvent e in _calendarEvents)
            {
                if (e.EventName != eventName) list.Add(e);
            }

            _calendarEvents.Clear();
            _calendarEvents.AddRange(list);
        }

        public void SetTheme(Themes.ThemeBase theme)
        {
            CalendarTheme = theme.ThemeName;
            BackgroundColor = theme.CalendarBackgroundColor;
            BorderColor = theme.CalendarBorderColor;
            DaysFont = theme.DaysFont;
            DaysTextColor = theme.DaysTextColor;
            DaysBackgroundColor = theme.DaysBackgroundColor;
            DaysDisabledBackgroundColor = theme.DaysDisabledBackgroundColor;
            DaysDisabledTextColor = theme.DaysDisabledTextColor;

            MonthYearBackgroundColor = theme.MonthYearBackgroundColor;
            MonthYearTextColor = theme.MonthYearTextColor;
            MonthYearFont = theme.MonthYearFont;

            DaysOfTheWeekBackgroundColor = theme.DaysOfTheWeekBackgroundColor;
            DaysOfTheWeekTextColor = theme.DaysOfTheWeekTextColor;
            DaysOfTheWeekFont = theme.DaysOfTheWeekFont;

            TodayButtonSize = theme.TodayButtonSize;
            TodayButtonFont = theme.TodayButtonFont;
            TodayButtonColor = theme.TodayButtonColor;
            TodayButtonBorderColor = theme.TodayButtonBorderColor;
            TodayButtonTextColor = theme.TodayButtonTextColor;
            TodayButtonHoverColor = theme.TodayButtonHoverColor;
            TodayButtonBorderHoverColor = theme.TodayButtonBorderHoverColor;

            PreviousMonthButtonSize = theme.PreviousMonthButtonSize;
            PreviousMonthButtonFont = theme.PreviousMonthButtonFont;
            PreviousMonthButtonColor = theme.PreviousMonthButtonColor;
            PreviousMonthButtonBorderColor = theme.PreviousMonthButtonBorderColor;
            PreviousMonthButtonTextColor = theme.PreviousMonthButtonTextColor;
            PreviousMonthButtonHoverColor = theme.PreviousMonthButtonHoverColor;
            PreviousMonthButtonBorderHoverColor = theme.PreviousMonthButtonBorderHoverColor;

            NextMonthButtonSize = theme.NextMonthButtonSize;
            NextMonthButtonFont = theme.NextMonthButtonFont;
            NextMonthButtonColor = theme.NextMonthButtonColor;
            NextMonthButtonBorderColor = theme.NextMonthButtonBorderColor;
            NextMonthButtonTextColor = theme.NextMonthButtonTextColor;
            NextMonthButtonHoverColor = theme.NextMonthButtonHoverColor;
            NextMonthButtonBorderHoverColor = theme.NextMonthButtonBorderHoverColor;
        }

        private int SundaysInMonth(DateTime thisMonth)
        {
            int sundays = 0;
            int month = thisMonth.Month;
            int year = thisMonth.Year;
            int daysThisMonth = DateTime.DaysInMonth(year, month);
            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            for (int i = 0; i < daysThisMonth; i++)
                if (beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                    sundays++;
            return sundays;
        }

        private void Calendar_Paint(object sender, PaintEventArgs e)
        {
            var bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.Clear(BackgroundColor);

                if (ShowTodayButton) DrawTodayButton(g);
                if (ShowPreviousMonthButton) DrawPreviousMonthButton(g);
                if (ShowNextMonthButton) DrawNextMonthButton(g);
                if (ShowMonthYear) DrawMonthYear(g);

                DrawCalendar(g);

                RenderEvents(g);
            }

            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void RenderEvents(Graphics g)
        {
            var dt = new DateTime(CalendarDate.Year, CalendarDate.Month, 1);
            int offset = (int)dt.DayOfWeek;
            int rows = SundaysInMonth(CalendarDate) + 1;
            int topMargin = Math.Max(Math.Max(TodayButtonSize.Height, NextMonthButtonSize.Height),
                                PreviousMonthButtonSize.Height) + 15;
            int squareWidth = (Width - CalendarPadding.Left - CalendarPadding.Right) / 7;
            int squareHeight = (Height - topMargin - CalendarPadding.Top - CalendarPadding.Bottom) / rows;
            SizeF daysOfWeekFontSize = g.MeasureString("Sun", DaysOfTheWeekFont);

            dt = dt.AddDays(-offset);

            _eventsMatrix.Clear();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (dt.Month != CalendarDate.Month)
                    {
                        dt = dt.AddDays(1);
                        continue;
                    }

                    int eventSize = 0;
                    foreach (ICalendarEvent evnt in _calendarEvents)
                    {
                        if (evnt.ShouldRender(dt))
                        {
                            var rect2 = new Rectangle(squareWidth * col + CalendarPadding.Left,
                                squareHeight * row + topMargin + CalendarPadding.Top, squareWidth, squareHeight);
                            var rect1 = new Rectangle(squareWidth * col + 1 + CalendarPadding.Left,
                                squareHeight * row + topMargin + CalendarPadding.Top + (int)daysOfWeekFontSize.Height + eventSize +
                                (ShowDaysOfWeek && row == 0 ? (int)daysOfWeekFontSize.Height : 0),
                                squareWidth - 1, evnt.EventHeight);
                            if (evnt.EventHeight + eventSize > rect2.Height - rect1.Height - 3) continue;
                            _eventsMatrix.Add(rect1, evnt);
                            g.FillRectangle(new SolidBrush(evnt.BackgroundColor), rect1);
                            var sf = new StringFormat
                            {
                                Trimming = StringTrimming.EllipsisCharacter,
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            };
                            if (evnt.ShowIcon)
                            {
                                g.DrawImage(evnt.Icon, rect1.X, rect1.Y);
                                rect1 = new Rectangle(rect1.X + evnt.Icon.Width, rect1.Y, rect1.Width - evnt.Icon.Width, rect1.Height);
                            }
                            g.DrawString(evnt.EventName, evnt.Font, new SolidBrush(evnt.TextColor), rect1, sf);
                            eventSize += evnt.EventHeight;
                        }
                    }

                    dt = dt.AddDays(1);
                }
            }
        }

        private void DrawMonthYear(Graphics g)
        {
            int x = CalendarPadding.Left;
            int y = CalendarPadding.Top;
            int maxHeight = ShowTodayButton ? TodayButtonSize.Height : 0;

            maxHeight = Math.Max(ShowPreviousMonthButton ? PreviousMonthButtonSize.Height : 0, maxHeight);
            maxHeight = Math.Max(ShowNextMonthButton ? NextMonthButtonSize.Height : 0, maxHeight);

            x += ShowTodayButton ? TodayButtonSize.Width + 10 : 0;
            x += ShowPreviousMonthButton ? PreviousMonthButtonSize.Width + 10 : 0;
            x += ShowNextMonthButton ? NextMonthButtonSize.Width + 10 : 0;

            var size = g.MeasureString(CalendarDate.ToString("MMMM yyyy"), MonthYearFont);
            var rect = new Rectangle(x, y, (int)size.Width + 10, (int)Math.Max(size.Height, maxHeight));

            var sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            g.FillRectangle(new SolidBrush(MonthYearBackgroundColor), rect);
            g.DrawString(CalendarDate.ToString("MMMM yyyy"), MonthYearFont, new SolidBrush(MonthYearTextColor), rect, sf);
        }

        private void DrawCalendar(Graphics g)
        {
            int rows = SundaysInMonth(CalendarDate) + 1;
            int topMargin = Math.Max(Math.Max(TodayButtonSize.Height, NextMonthButtonSize.Height),
                PreviousMonthButtonSize.Height) + 15;
            //Rectangle calendarBounds = new Rectangle(CalendarPadding.Left + 1, topMargin + CalendarPadding.Top,
            //    Width - 2 - CalendarPadding.Right, Height - topMargin - 2 - CalendarPadding.Bottom);

            //g.DrawRectangle(new Pen(BorderColor, 2), calendarBounds);

            int squareWidth = (Width - CalendarPadding.Left - CalendarPadding.Right) / 7;
            int squareHeight = (Height - topMargin - CalendarPadding.Top - CalendarPadding.Bottom) / rows;
            Pen borderPen = new Pen(BorderColor, 1);
            SizeF daysOfWeekFontSize = g.MeasureString("Sun", DaysOfTheWeekFont);

            _daysMatrix.Clear();
            var dt = new DateTime(CalendarDate.Year, CalendarDate.Month, 1);
            int offset = (int)dt.DayOfWeek;

            dt = dt.AddDays(-offset);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if ((int)dt.DayOfWeek == col)
                    {
                        SizeF numberFontSize = g.MeasureString(dt.Day.ToString(), DaysFont);
                        var rect1 = new Rectangle(squareWidth * col + 3 + CalendarPadding.Left,
                            squareHeight * row + topMargin + CalendarPadding.Top +
                            (ShowDaysOfWeek && row == 0 ? (int)daysOfWeekFontSize.Height : 0),
                            (int)numberFontSize.Width, (int)numberFontSize.Height);
                        g.Clip = new Region(rect1);
                        g.FillRectangle(new SolidBrush(DaysBackgroundColor), rect1);

                        g.DrawString(dt.Day.ToString(), DaysFont,
                            dt.Month == CalendarDate.Month
                                ? new SolidBrush(DaysTextColor)
                                : new SolidBrush(DaysDisabledTextColor),
                            new Point(squareWidth * col + 3 + CalendarPadding.Left,
                                squareHeight * row + topMargin + CalendarPadding.Top +
                                (ShowDaysOfWeek && row == 0 ? (int)daysOfWeekFontSize.Height : 0)));
                        g.ResetClip();

                        var rect2 = new Rectangle(squareWidth * col + CalendarPadding.Left,
                            squareHeight * row + topMargin + CalendarPadding.Top, squareWidth, squareHeight);
                        _daysMatrix.Add(rect2, dt);

                        dt = dt.AddDays(1);
                    }
                }
            }
            for (int col = 0; col < 7; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    var rect2 = new Rectangle(squareWidth * col + CalendarPadding.Left,
                        squareHeight * row + topMargin + CalendarPadding.Top, squareWidth, squareHeight);
                    g.DrawRectangle(borderPen, rect2);
                    if (!ShowDaysOfWeek) continue;

                    if (row == 0)
                    {
                        string calendarDay = "";

                        switch (col)
                        {
                            case 0:
                                calendarDay = "Sun";
                                break;
                            case 1:
                                calendarDay = "Mon";
                                break;
                            case 2:
                                calendarDay = "Tue";
                                break;
                            case 3:
                                calendarDay = "Wed";
                                break;
                            case 4:
                                calendarDay = "Thu";
                                break;
                            case 5:
                                calendarDay = "Fri";
                                break;
                            case 6:
                                calendarDay = "Sat";
                                break;
                        }

                        SizeF textSize = g.MeasureString(calendarDay, DaysOfTheWeekFont);
                        g.FillRectangle(new SolidBrush(DaysOfTheWeekBackgroundColor),
                            new RectangleF(squareWidth * col + 2 + CalendarPadding.Left, squareHeight * row + topMargin + CalendarPadding.Top, textSize.Width,
                                textSize.Height));
                        g.DrawString(calendarDay, DaysOfTheWeekFont, new SolidBrush(DaysOfTheWeekTextColor),
                            new Point(squareWidth * col + 2 + CalendarPadding.Left,
                                squareHeight * row + topMargin + CalendarPadding.Top));
                    }
                }
            }
        }

        private void DrawPreviousMonthButton(Graphics g)
        {
            int leftMargin = ShowTodayButton ? TodayButtonSize.Width + 10 : 0;
            Rectangle bounds = new Rectangle(leftMargin + CalendarPadding.Left, CalendarPadding.Top, PreviousMonthButtonSize.Width, PreviousMonthButtonSize.Height);
            int diameter = ButtonRadius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            using (GraphicsPath path = new GraphicsPath())
            {
                // top left arc  
                path.AddArc(arc, 180, 90);

                // top right arc  
                arc.X = bounds.Right - diameter;
                path.AddArc(arc, 270, 90);

                // bottom right arc  
                arc.Y = bounds.Bottom - diameter;
                path.AddArc(arc, 0, 90);

                // bottom left arc 
                arc.X = bounds.Left;
                path.AddArc(arc, 90, 90);

                path.CloseFigure();
                g.FillPath(new SolidBrush(_previousMonthButtonHovered ? PreviousMonthButtonHoverColor : PreviousMonthButtonColor), path);
                g.DrawPath(new Pen(_previousMonthButtonHovered ? PreviousMonthButtonBorderHoverColor : PreviousMonthButtonBorderColor, 1), path);

                g.Clip = new Region(path);
                var sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                g.DrawString("<", PreviousMonthButtonFont, new SolidBrush(PreviousMonthButtonTextColor), bounds, sf);
                g.ResetClip();
            }
        }

        private void DrawNextMonthButton(Graphics g)
        {
            int leftMargin = ShowTodayButton ? TodayButtonSize.Width + 10 : 0;
            leftMargin += ShowPreviousMonthButton ? PreviousMonthButtonSize.Width + 3 : 0;
            Rectangle bounds = new Rectangle(leftMargin + CalendarPadding.Left, CalendarPadding.Top, NextMonthButtonSize.Width, NextMonthButtonSize.Height);
            int diameter = ButtonRadius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            using (GraphicsPath path = new GraphicsPath())
            {
                // top left arc  
                path.AddArc(arc, 180, 90);

                // top right arc  
                arc.X = bounds.Right - diameter;
                path.AddArc(arc, 270, 90);

                // bottom right arc  
                arc.Y = bounds.Bottom - diameter;
                path.AddArc(arc, 0, 90);

                // bottom left arc 
                arc.X = bounds.Left;
                path.AddArc(arc, 90, 90);

                path.CloseFigure();
                g.FillPath(new SolidBrush(_nextMonthButtonHovered ? NextMonthButtonHoverColor : NextMonthButtonColor), path);
                g.DrawPath(new Pen(_nextMonthButtonHovered ? NextMonthButtonBorderHoverColor : NextMonthButtonBorderColor, 1), path);

                g.Clip = new Region(path);
                var sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                g.DrawString(">", NextMonthButtonFont, new SolidBrush(NextMonthButtonTextColor), bounds, sf);
                g.ResetClip();
            }
        }

        private void DrawTodayButton(Graphics g)
        {
            Rectangle bounds = new Rectangle(CalendarPadding.Left, CalendarPadding.Top, TodayButtonSize.Width, TodayButtonSize.Height);
            int diameter = ButtonRadius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            using (GraphicsPath path = new GraphicsPath())
            {
                // top left arc  
                path.AddArc(arc, 180, 90);

                // top right arc  
                arc.X = bounds.Right - diameter;
                path.AddArc(arc, 270, 90);

                // bottom right arc  
                arc.Y = bounds.Bottom - diameter;
                path.AddArc(arc, 0, 90);

                // bottom left arc 
                arc.X = bounds.Left;
                path.AddArc(arc, 90, 90);

                path.CloseFigure();
                g.FillPath(new SolidBrush(_todayButtonHovered ? TodayButtonHoverColor : TodayButtonColor), path);
                g.DrawPath(new Pen(_todayButtonHovered ? TodayButtonBorderHoverColor : TodayButtonBorderColor, 1), path);

                g.Clip = new Region(path);
                var sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                g.DrawString("Today", TodayButtonFont, new SolidBrush(TodayButtonTextColor), bounds, sf);
                g.ResetClip();
            }
        }

        private void Calendar_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Calendar_MouseMove(object sender, MouseEventArgs e)
        {
            CheckIfMouseIsOverTodayButton(e.Location);
            CheckIfMouseIsOverPreviousMonthButton(e.Location);
            CheckIfMouseIsOverNextMonthButton(e.Location);
            CheckIfMouseIsOverAnEvent(e.Location);
        }

        private void Calendar_MouseLeave(object sender, EventArgs e)
        {
            _todayButtonHovered = false;
            _nextMonthButtonHovered = false;
            _previousMonthButtonHovered = false;
            Refresh();
        }

        private void Calendar_MouseClick(object sender, MouseEventArgs e)
        {
            CheckIfMouseClickedOnTodayButton(e.Location, e, false);
            CheckIfMouseClickedOnPreviousMonthButton(e.Location, e, false);
            CheckIfMouseClickedOnNextMonthButton(e.Location, e, false);
            CheckIfMouseClickedOnEvent(e.Location, e, false);
            CheckIfMouseClickedOnDayEvent(e.Location, e, false);
        }

        private void Calendar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CheckIfMouseClickedOnTodayButton(e.Location, e, true);
            CheckIfMouseClickedOnPreviousMonthButton(e.Location, e, true);
            CheckIfMouseClickedOnNextMonthButton(e.Location, e, true);
            CheckIfMouseClickedOnEvent(e.Location, e, true);
            CheckIfMouseClickedOnDayEvent(e.Location, e, true);
        }

        private void CheckIfMouseClickedOnDayEvent(Point location, MouseEventArgs e, bool doubleClicked)
        {
            foreach (var r in _daysMatrix.ToList())
            {
                if (r.Key.Contains(location) && !_eventsMatrix.ToList().Any(z => z.Key.Contains(location)))
                {
                    var calendarEventArgs = new CalendarMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta) { Handled = false };
                    if (!doubleClicked)
                        CalendarDayClicked?.Invoke(this, calendarEventArgs, r.Value);
                    else
                        CalendarDayDoubleClicked?.Invoke(this, calendarEventArgs, r.Value);
                }
            }
        }

        private void CheckIfMouseClickedOnEvent(Point location, MouseEventArgs e, bool doubleClicked)
        {
            foreach (var r in _eventsMatrix.ToList())
            {
                if (r.Key.Contains(location))
                {
                    var calendarEventArgs = new CalendarMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta) { Handled = false };
                    if (!doubleClicked)
                        CalendarEventClicked?.Invoke(this, calendarEventArgs, r.Value);
                    else
                        CalendarEventDoubleClicked?.Invoke(this, calendarEventArgs, r.Value);
                }
            }
        }

        private void CheckIfMouseIsOverAnEvent(Point location)
        {
            if (location.X != _lastMousePoint.X || location.Y != _lastMousePoint.Y)
            {
                _lastMousePoint = new Point(location.X, location.Y);
                bool foundContains = false;
                foreach (var r in _eventsMatrix.ToList())
                {
                    if (r.Key.Contains(location))
                    {
                        foundContains = true;
                        _eventTooltip.ShowAlways = true;
                        _eventTooltip.Active = true;
                        _eventTooltip.Show(r.Value.EventName, this, location.X, location.Y + 20);
                    }
                }

                if (!foundContains)
                {
                    _eventTooltip.Hide(this);
                }
            }
        }

        private void CheckIfMouseClickedOnTodayButton(Point location, MouseEventArgs e, bool doubleClicked)
        {
            if (!ShowTodayButton) return;

            var calendarEventArgs = new CalendarMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta) { Handled = false };

            var rect = new Rectangle(CalendarPadding.Left, CalendarPadding.Top, TodayButtonSize.Width,
                TodayButtonSize.Height);

            if (rect.Contains(location))
            {
                if (!doubleClicked)
                    TodayButtonClicked?.Invoke(this, calendarEventArgs);
                else
                    TodayButtonDoubleClicked?.Invoke(this, calendarEventArgs);
                if (!calendarEventArgs.Handled && e.Button == MouseButtons.Left && !doubleClicked) CalendarDate = DateTime.Now;
            }
        }

        private void CheckIfMouseClickedOnPreviousMonthButton(Point location, MouseEventArgs e, bool doubleClicked)
        {
            if (!ShowPreviousMonthButton) return;

            var calendarEventArgs = new CalendarMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta) { Handled = false };

            int leftMargin = ShowTodayButton ? TodayButtonSize.Width + 10 : 0;
            var rect = new Rectangle(leftMargin + CalendarPadding.Left, CalendarPadding.Top, PreviousMonthButtonSize.Width, PreviousMonthButtonSize.Height);

            if (rect.Contains(location))
            {
                if (!doubleClicked)
                    PreviousMonthButtonClicked?.Invoke(this, calendarEventArgs);
                else
                    PreviousMonthButtonDoubleClicked?.Invoke(this, calendarEventArgs);
                if (!calendarEventArgs.Handled && e.Button == MouseButtons.Left && !doubleClicked) CalendarDate = CalendarDate.AddMonths(-1);
            }
        }

        private void CheckIfMouseClickedOnNextMonthButton(Point location, MouseEventArgs e, bool doubleClicked)
        {
            if (!ShowNextMonthButton) return;

            var calendarEventArgs = new CalendarMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta) { Handled = false };

            int leftMargin = ShowTodayButton ? TodayButtonSize.Width + 10 : 0;
            leftMargin += ShowPreviousMonthButton ? PreviousMonthButtonSize.Width + 3 : 0;
            var rect = new Rectangle(leftMargin + CalendarPadding.Left, CalendarPadding.Top, NextMonthButtonSize.Width, NextMonthButtonSize.Height);

            if (rect.Contains(location))
            {
                if (!doubleClicked)
                    NextMonthButtonClicked?.Invoke(this, calendarEventArgs);
                else
                    NextMonthButtonDoubleClicked?.Invoke(this, calendarEventArgs);
                if (!calendarEventArgs.Handled && e.Button == MouseButtons.Left && !doubleClicked) CalendarDate = CalendarDate.AddMonths(1);
            }
        }

        private void CheckIfMouseIsOverTodayButton(Point location)
        {
            if (!ShowTodayButton) return;

            var rect = new Rectangle(CalendarPadding.Left, CalendarPadding.Top, TodayButtonSize.Width,
                TodayButtonSize.Height);

            _todayButtonHovered = rect.Contains(location);
            Refresh();
        }

        private void CheckIfMouseIsOverPreviousMonthButton(Point location)
        {
            if (!ShowPreviousMonthButton) return;

            int leftMargin = ShowTodayButton ? TodayButtonSize.Width + 10 : 0;
            var rect = new Rectangle(leftMargin + CalendarPadding.Left, CalendarPadding.Top, PreviousMonthButtonSize.Width, PreviousMonthButtonSize.Height);

            _previousMonthButtonHovered = rect.Contains(location);
            Refresh();
        }

        private void CheckIfMouseIsOverNextMonthButton(Point location)
        {
            if (!ShowNextMonthButton) return;

            int leftMargin = ShowTodayButton ? TodayButtonSize.Width + 10 : 0;
            leftMargin += ShowPreviousMonthButton ? PreviousMonthButtonSize.Width + 3 : 0;
            var rect = new Rectangle(leftMargin + CalendarPadding.Left, CalendarPadding.Top, NextMonthButtonSize.Width, NextMonthButtonSize.Height);

            _nextMonthButtonHovered = rect.Contains(location);
            Refresh();
        }
    }
}
