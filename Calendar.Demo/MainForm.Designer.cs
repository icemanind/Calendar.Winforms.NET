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
            this.calendar1.BackgroundColor = System.Drawing.Color.Transparent;
            this.calendar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.calendar1.CalendarEventsFont = new System.Drawing.Font("Arial", 12F);
            this.calendar1.CalendarFont = new System.Drawing.Font("Arial", 12F);
            this.calendar1.CalendarSizeMode = Calendar.UserControl.CalendarSizeModes.Stretch;
            this.calendar1.Location = new System.Drawing.Point(246, 78);
            this.calendar1.Name = "calendar1";
            this.calendar1.ShowMonthYear = true;
            this.calendar1.ShowNextMonthButton = true;
            this.calendar1.ShowPreviousMonthButton = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(849, 571);
            this.calendar1.TabIndex = 0;
            this.calendar1.TodayButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.calendar1.TodayButtonFont = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.calendar1.TodayButtonTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 825);
            this.Controls.Add(this.calendar1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl.Calendar calendar1;
    }
}

