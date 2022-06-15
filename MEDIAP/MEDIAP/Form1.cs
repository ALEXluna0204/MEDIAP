using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEDIAP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string file = openFileDialog1.FileName;
            WMP.URL = file;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.play();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            WMP.settings.volume=trackBar1.Value;
        }

        private void WMP_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar2.Maximum = Convert.ToInt32(WMP.currentMedia.duration);
            trackBar2.Value = Convert.ToInt32(WMP.Ctlcontrols.currentPosition);
            if (WMP != null)
            {
                int s = (int)WMP.Ctlcontrols.currentPosition;
                int h = s / 3600;
                int m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);
                label2.Text = String.Format("{0:D}:{1:D2}:{2:D2}", h, m ,s);
            }
            else
            {
                label2.Text = "0:00:00";
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.currentPosition = trackBar2.Value;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.play();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.pause();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string file = openFileDialog1.FileName;
            WMP.URL = file;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
