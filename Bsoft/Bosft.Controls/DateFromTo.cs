using System;
using System.Windows.Forms;

namespace Bsoft.Controls
{
    public partial class DateFromTo : UserControl
    {
        public DateFromTo()
        {
            InitializeComponent();
        }

        private TimeSpan days = new TimeSpan();

        public double Days
        {
            get { return days.TotalDays; }
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            days = dtTo.Value - dtFrom.Value;
            lblDays.Text = days.Days.ToString() + " Days";
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            days = dtTo.Value - dtFrom.Value;
            lblDays.Text = days.Days.ToString() + " Days";
        }
    }
}