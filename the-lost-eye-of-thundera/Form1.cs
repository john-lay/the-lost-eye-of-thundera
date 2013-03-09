using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using the_lost_eye_of_thundera.Sprites;
using the_lost_eye_of_thundera.Scenery;

namespace the_lost_eye_of_thundera
{
    public partial class Form1 : Form
    {
        Timer GameTimer;
        Graphics gameCanvas;
        Liono liono;
        Background bg;
        static bool gameStart = false;
        static bool pause = false;
        static int tenth = 0;
        static int second = 0;

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            //set up the game timer
            GameTimer = new Timer();
            GameTimer.Interval = 100;
            GameTimer.Tick += new EventHandler(GameTimer_Tick);
            //create the graphics object to draw with            
            gameCanvas = pictureBox1.CreateGraphics();
            //initialise sprite
            liono = new Liono();
            liono.positionX = 100;
            liono.positionY = 122;

            //initialise bg
            bg = new Background();

            //start the game
            if (gameStart == true) {                
                GameTimer.Start();
            }
            //handle game input
            // Set KeyPreview object to true to allow the form to process  
            // the key before the control with focus processes it.
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(userInput);
            this.KeyUp += new KeyEventHandler(userNoInput);
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
            //timers
            labelTimer.Text = "Timer: " + tenth;
            tenth++;
            labelSecondTimer.Text = "Timer: " + second;
            if (tenth % 10 == 0) {
                second++;
            }
            
            //clear the canvas
            //gameCanvas.Clear(SystemColors.Control);
            bg.draw(gameCanvas);
            //draw updated frame
            liono.draw(gameCanvas);
            liono.animationStep++;
        }

        void userInput(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                labelInput.Text = "Input: " + "right";
                liono.WalkRight();
            }
            if (e.KeyCode == Keys.Left)
            {
                labelInput.Text = "Input: " + "left";
                liono.WalkLeft();
            }
        }
        void userNoInput(object sender, KeyEventArgs e)
        {
            //wait for sprite to be grounded,
            //then return to neutral.
        }
        /// <summary>
        ///     Override the arrow and tab keyboard events
        ///     http://mike-caron.com/2010/07/dude-wheres-my-arrow-key/
        /// </summary>
        /// <param name="keyData">Keys: keys pressed</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            return false;
        }
    }
}
