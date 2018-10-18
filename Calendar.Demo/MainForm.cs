using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar.UserControl;

namespace Calendar.Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            cbDateMonth.SelectedIndex = DateTime.Now.Month - 1;
            numYear.Value = DateTime.Now.Year;
        }

        private void cbDateMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            calendar1.CalendarDate = new DateTime((int) numYear.Value, cbDateMonth.SelectedIndex + 1, 1);
        }

        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            calendar1.CalendarDate = new DateTime((int)numYear.Value, cbDateMonth.SelectedIndex + 1, 1);
        }
        
        // StackOverflow
        // https://stackoverflow.com/questions/27577195/how-do-i-stop-a-numericupdown-from-playing-ding-sound-on-enterkeypress
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                var ctl = ActiveControl;
                var box = ctl as TextBoxBase;
                // Make Enter behave like Tab, unless it is a multiline textbox
                if (ctl != null && (box == null || !box.Multiline))
                {
                    SelectNextControl(ctl, true, true, true, true);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void calendar1_CalendarDayClicked(object sender, CalendarMouseEventArgs e, DateTime dt)
        {
            if (e.Button == MouseButtons.Right)
                MessageBox.Show(@"Calendar day Clicked");
        }

        private void calendar1_CalendarDayDoubleClicked(object sender, CalendarMouseEventArgs e, DateTime dt)
        {
            MessageBox.Show(@"Calendar day Double Clicked");
        }
    }
}
