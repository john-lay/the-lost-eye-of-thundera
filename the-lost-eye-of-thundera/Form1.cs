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
using System.Diagnostics;

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
        static int hundredth = 0;
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
            GameTimer.Interval = 10; //10 milliseconds 1/100 second
            GameTimer.Tick += new EventHandler(GameTimer_Tick);
            //create the graphics object to draw with            
            gameCanvas = pictureBox1.CreateGraphics();
            //initialise sprite
            liono = new Liono();

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
            hundredth++;            
            if (hundredth % 100 == 0) {
                second++;
            }
            labelTimer.Text = "1/100th Timer: " + hundredth;
            labelSecondTimer.Text = "Seconds Timer: " + second;
            //draw updated frame at 20fps
            if (hundredth % 5 == 0)
            {
                bg.draw(gameCanvas);
                liono.draw(gameCanvas);
                liono.animationStep++;
            }                    
        }

        void userInput(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                labelInput.Text = "Input: " + "right";
                liono.WalkRight();
                //scroll bg
                if (bg.sceneryPosX >= -(288 * 5)) //tiled bg width
                    bg.sceneryPosX -= 2;
            }
            if (e.KeyCode == Keys.Left)
            {
                labelInput.Text = "Input: " + "left";                
                //scroll bg and animate sprite only if the player hasn't reached
                //the far left of the stage.
                if (bg.sceneryPosX < 0)
                {
                    liono.WalkLeft();
                    bg.sceneryPosX += 2;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                labelInput.Text = "Input: " + "up";
                liono.Jump();
            }
            if (e.KeyCode == Keys.Down)
            {
                labelInput.Text = "Input: " + "down";
                liono.Crouch();
            }
            if (e.KeyCode == Keys.Space)
            {
                labelInput.Text = "Input: " + "space";
                e.SuppressKeyPress = true; //stop spacebar interaction with winform buttons
                liono.Attack();
            }
        }
        void userNoInput(object sender, KeyEventArgs e)
        {
            //wait for sprite to be grounded,
            //then return to neutral.
            liono.StandNeutral();
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
