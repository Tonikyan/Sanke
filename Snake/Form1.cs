using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private bool arcade = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Speed speed = Speed.VerSlow;
            switch (trackBar1.Value)
            {
                case 1:
                    speed = Speed.VerSlow;
                    break;
                case 2:
                    speed = Speed.SLow;
                    break;
                case 3:
                    speed = Speed.Medium;
                    break;
                case 4:
                    speed = Speed.Fast;
                    break;
                case 5:
                    speed = Speed.VeryFast;
                    break;
            }
            new GameForm((int)speed, arcade).ShowDialog();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                arcade = false;
                trackBar1.Enabled = true;
            }
            else
            {
                arcade = true;
                trackBar1.Value = 1;
                trackBar1.Enabled = false;
            }
        }
    }
}
