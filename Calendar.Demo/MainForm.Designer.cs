namespace Calendar.Demo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.calendar1 = new Calendar.UserControl.Calendar();
            this.SuspendLayout();
            // 
            // calendar1
            // 
            this.calendar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(230)))));
            this.calendar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.calendar1.CalendarDate = new System.DateTime(2018, 10, 12, 15, 7, 57, 161);
            this.calendar1.CalendarDisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.calendar1.CalendarEventsFont = new System.Drawing.Font("Arial", 12F);
            this.calendar1.CalendarFont = new System.Drawing.Font("Arial", 11F);
            this.calendar1.CalendarPadding = new System.Windows.Forms.Padding(10);
            this.calendar1.CalendarSizeMode = Calendar.UserControl.CalendarSizeModes.Stretch;
            this.calendar1.CalendarTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.calendar1.CalendarViewMode = Calendar.UserControl.CalendarViewModes.Month;
            this.calendar1.DaysBackgroundColor = System.Drawing.Color.Transparent;
            this.calendar1.DaysDisabledBackgroundColor = System.Drawing.Color.Transparent;
            this.calendar1.DaysDisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.calendar1.DaysFont = new System.Drawing.Font("Arial", 11F);
            this.calendar1.DaysOfTheWeekBackgroundColor = System.Drawing.Color.Transparent;
            this.calendar1.DaysOfTheWeekFont = new System.Drawing.Font("Arial", 11F);
            this.calendar1.DaysOfTheWeekTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.calendar1.DaysTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.calendar1.Location = new System.Drawing.Point(345, 118);
            this.calendar1.MonthYearBackgroundColor = System.Drawing.Color.Transparent;
            this.calendar1.MonthYearFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendar1.MonthYearTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.calendar1.Name = "calendar1";
            this.calendar1.NextMonthButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.calendar1.NextMonthButtonBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.calendar1.NextMonthButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.calendar1.NextMonthButtonFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.calendar1.NextMonthButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.calendar1.NextMonthButtonSize = new System.Drawing.Size(35, 25);
            this.calendar1.NextMonthButtonTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.calendar1.PreviousMonthButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.calendar1.PreviousMonthButtonBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.calendar1.PreviousMonthButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.calendar1.PreviousMonthButtonFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.calendar1.PreviousMonthButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.calendar1.PreviousMonthButtonSize = new System.Drawing.Size(35, 25);
            this.calendar1.PreviousMonthButtonTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.calendar1.ShowDaysOfWeek = true;
            this.calendar1.ShowMonthYear = true;
            this.calendar1.ShowNextMonthButton = true;
            this.calendar1.ShowPreviousMonthButton = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(849, 571);
            this.calendar1.TabIndex = 0;
            this.calendar1.TodayButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.calendar1.TodayButtonBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.calendar1.TodayButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.calendar1.TodayButtonFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.calendar1.TodayButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.calendar1.TodayButtonSize = new System.Drawing.Size(70, 25);
            this.calendar1.TodayButtonTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1379, 825);
            this.Controls.Add(this.calendar1);
            this.Name = "MainForm";
            this.Text = "Calendar Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl.Calendar calendar1;
    }
}

