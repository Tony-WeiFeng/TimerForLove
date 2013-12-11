using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TimerForLove
{
    public partial class TimerOfLove : Form
    {
        public TimerOfLove()
        {
            InitializeComponent();
            //Form.FormBorderStyle = FormBorderStyle.FixedSingle;
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadStart ts = new ThreadStart(refreshLabel);
            Thread thread = new Thread(ts);
            thread.Start();
        }

        public string getTheTime()
        {
            DateTime Tstart = new DateTime(2013, 11, 22, 19, 49, 51);
            DateTime Tnow = DateTime.Now;
            TimeSpan Tspan = Tnow - Tstart;

            string day = Tspan.Days.ToString();
            string hour = Tspan.Hours.ToString();
            string minute = Tspan.Minutes.ToString();
            string second = Tspan.Seconds.ToString();

            string result = day + " Days " + hour + " Hours " + minute + " Minutes " + second + " Seconds...";

            return result;
        }

        public void refreshLabel()
        {
            while (true)
            {
                label3.Text = getTheTime();
                Thread.Sleep(1000);
            }
        }
    }
}
