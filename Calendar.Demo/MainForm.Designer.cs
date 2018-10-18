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
            this.label1 = new System.Windows.Forms.Label();
            this.cbDateMonth = new System.Windows.Forms.ComboBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.calendar1 = new Calendar.UserControl.Calendar();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 626);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date:";
            // 
            // cbDateMonth
            // 
            this.cbDateMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDateMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDateMonth.FormattingEnabled = true;
            this.cbDateMonth.Items.AddRange(new object[] {
            "January",
            "Febuary",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbDateMonth.Location = new System.Drawing.Point(203, 622);
            this.cbDateMonth.Name = "cbDateMonth";
            this.cbDateMonth.Size = new System.Drawing.Size(170, 26);
            this.cbDateMonth.TabIndex = 2;
            this.cbDateMonth.SelectedIndexChanged += new System.EventHandler(this.cbDateMonth_SelectedIndexChanged);
            // 
            // numYear
            // 
            this.numYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYear.Location = new System.Drawing.Point(379, 623);
            this.numYear.Maximum = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 24);
            this.numYear.TabIndex = 3;
            this.numYear.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numYear.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
            // 
            // calendar1
            // 
            this.calendar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(230)))));
            this.calendar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.calendar1.CalendarDate = new System.DateTime(2018, 10, 15, 19, 18, 28, 333);
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
            this.calendar1.Location = new System.Drawing.Point(157, 45);
            this.calendar1.MonthYearBackgroundColor = System.Drawing.Color.Transparent;
            this.calendar1.MonthYearFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendar1.MonthYearTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
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
            this.calendar1.RenderHolidays = true;
            this.calendar1.ShowDaysOfWeek = true;
            this.calendar1.ShowMonthYear = true;
            this.calendar1.ShowNextMonthButton = true;
            this.calendar1.ShowPreviousMonthButton = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(849, 571);
            this.calendar1.TabIndex = 4;
            this.calendar1.TodayButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.calendar1.TodayButtonBorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.calendar1.TodayButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.calendar1.TodayButtonFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.calendar1.TodayButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.calendar1.TodayButtonSize = new System.Drawing.Size(70, 25);
            this.calendar1.TodayButtonTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.calendar1.CalendarDayClicked += new Calendar.UserControl.Calendar.CalendarDayClickHandler(this.calendar1_CalendarDayClicked);
            this.calendar1.CalendarDayDoubleClicked += new Calendar.UserControl.Calendar.CalendarDayClickHandler(this.calendar1_CalendarDayDoubleClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1379, 825);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.cbDateMonth);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Calendar Demo";
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDateMonth;
        private System.Windows.Forms.NumericUpDown numYear;
        private UserControl.Calendar calendar1;
    }
}

