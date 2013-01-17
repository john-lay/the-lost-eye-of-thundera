using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using the_lost_eye_of_thundera.Sprites;

namespace the_lost_eye_of_thundera
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //create the graphics object to draw with
            Graphics paper;
            paper = pictureBox1.CreateGraphics();
            Liono liono = new Liono();
            paper.DrawImage(liono.walk[0], 10, 100);
        }
    }
}
