using System.Drawing;

namespace Calendar.UserControl.Themes
{
    public abstract class ThemeBase
    {
        #region Abstract Properties
        public abstract string ThemeName { get; }
        #endregion

        #region Calendar Properties
        public virtual Color CalendarBackgroundColor => Color.FromArgb(160,210,230);
        public virtual Color CalendarBorderColor => Color.FromArgb(170, 170, 170);
        public virtual Font DaysFont => new Font("Arial", 11, FontStyle.Regular);
        public virtual Color DaysTextColor => Color.FromArgb(0, 0, 0);
        public virtual Color DaysBackgroundColor => Color.Transparent;
        public virtual Color DaysDisabledTextColor => Color.FromArgb(150, 150, 150);
        public virtual Color DaysDisabledBackgroundColor => Color.Transparent;
        #endregion

        #region Month/Year Display Properties
        public virtual Color MonthYearTextColor => Color.FromArgb(60, 100, 160);
        public virtual Color MonthYearBackgroundColor => Color.Transparent;
        public virtual Font MonthYearFont => new Font("Arial", 12, FontStyle.Bold);
        #endregion

        #region Days Of The Week Properties
        public virtual Color DaysOfTheWeekTextColor => Color.FromArgb(0, 0, 0);
        public virtual Color DaysOfTheWeekBackgroundColor => Color.Transparent;
        public virtual Font DaysOfTheWeekFont => new Font("Arial", 11, FontStyle.Regular);
        #endregion

        #region Today Button Properties
        public virtual Size TodayButtonSize => new Size(70, 25);
        public virtual Font TodayButtonFont => new Font("Arial", 11, FontStyle.Bold);
        public virtual Color TodayButtonColor => Color.FromArgb(0, 191, 255);
        public virtual Color TodayButtonBorderColor => Color.FromArgb(65, 105, 225);
        public virtual Color TodayButtonTextColor => Color.FromArgb(45, 105, 205);
        public virtual Color TodayButtonHoverColor => Color.FromArgb(30, 221, 255);
        public virtual Color TodayButtonBorderHoverColor => Color.FromArgb(95, 135, 255);
        #endregion

        #region Previous Month Button Properties
        public virtual Size PreviousMonthButtonSize => new Size(35, 25);
        public virtual Font PreviousMonthButtonFont => new Font("Arial", 11, FontStyle.Bold);
        public virtual Color PreviousMonthButtonColor => Color.FromArgb(0, 191, 255);
        public virtual Color PreviousMonthButtonBorderColor => Color.FromArgb(65, 105, 225);
        public virtual Color PreviousMonthButtonTextColor => Color.FromArgb(45, 105, 205);
        public virtual Color PreviousMonthButtonHoverColor => Color.FromArgb(30, 221, 255);
        public virtual Color PreviousMonthButtonBorderHoverColor => Color.FromArgb(95, 135, 255);
        #endregion

        #region Next Month Button Properties
        public virtual Size NextMonthButtonSize => new Size(35, 25);
        public virtual Font NextMonthButtonFont => new Font("Arial", 11, FontStyle.Bold);
        public virtual Color NextMonthButtonColor => Color.FromArgb(0, 191, 255);
        public virtual Color NextMonthButtonBorderColor => Color.FromArgb(65, 105, 225);
        public virtual Color NextMonthButtonTextColor => Color.FromArgb(45, 105, 205);
        public virtual Color NextMonthButtonHoverColor => Color.FromArgb(30, 221, 255);
        public virtual Color NextMonthButtonBorderHoverColor => Color.FromArgb(95, 135, 255);
        #endregion
    }
}
