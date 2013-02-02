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
        Timer GameTimer;
        Graphics gameCanvas;
        Liono liono;
        static bool gameStart = false;
        static bool pause = false;
        static int tenth = 0;
        static int second = 0;
        static int animationStep = 0;

        public Form1()
        {
            InitializeComponent();
            //set up the game timer
            GameTimer = new Timer();
            GameTimer.Interval = 100;
            GameTimer.Tick += new EventHandler(GameTimer_Tick);
            //create the graphics object to draw with            
            gameCanvas = pictureBox1.CreateGraphics();
            //initialise sprite
            liono = new Liono();

            //start the game
            if (gameStart == true) {                
                GameTimer.Start();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //initialise the game for the first time
            if (gameStart == false) {
                gameStart = true;
            }
            //pause/resume game
            if (pause == true) {
                GameTimer.Stop();
                btnStart.Text = "Resume";
                pause = false;
            }
            else {
                GameTimer.Start();
                btnStart.Text = "Pause";
                pause = true;
            }            
        }

        void GameTimer_Tick(object sender, EventArgs e)
        {
            //Draw();
            //gameCanvas.DrawImage(liono.walk[0], 10, 100);
            
            //timers
            labelTimer.Text = "Timer: " + tenth;
            tenth++;
            labelSecondTimer.Text = "Timer: " + second;
            if (tenth % 10 == 0) {
                second++;
            }
            //draw walk cycle - 8 frames
            if (animationStep == 8)
            {
                animationStep = 0;
            }
            else
            {
                animationStep++;
            }
            //clear the canvas
            gameCanvas.Clear(SystemColors.Control);
            //draw updated frame
            gameCanvas.DrawImage(liono.walk[animationStep], 10, 100);
        }
    }
}
