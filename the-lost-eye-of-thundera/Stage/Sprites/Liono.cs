using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace the_lost_eye_of_thundera.Sprites
{
    class Liono : Sprite
    {
        public Bitmap[] standRight, walkRight, crouchRight, jumpRight;
        public Bitmap[] standLeft, walkLeft, crouchLeft, jumpLeft;
        public Bitmap[] attackRight, jumpAttackRight, crouchAttackRight;
        public Bitmap[] attackLeft, jumpAttackLeft, crouchAttackLeft;
        public bool momentumRight, momentumLeft, isJumping;

        private bool _directionFacingRight;
        private int _initialPosX, _initialPosY, _jumpSpeed;
        private Timer jumpTimer = new Timer();
        
        public Liono() {
            
            //source image
            this.spriteSheet = new Bitmap(@"..\..\Resources\liono_sprite.bmp");
            Bitmap[,] lionoSprites = sliceUpTile(spriteSheet, 54, 54, 11, 2, Color.Magenta);

            //initialise animation arrays
            standRight = new Bitmap[] { lionoSprites[10,0] };
            walkRight = new Bitmap[] { lionoSprites[0,0],
                lionoSprites[1,0],
                lionoSprites[2,0],
                lionoSprites[3,0],
                lionoSprites[4,0],
                lionoSprites[5,0],
                lionoSprites[6,0],
                lionoSprites[7,0],
                lionoSprites[8,0]
            };
            jumpRight = new Bitmap[] { lionoSprites[9,0] };
            jumpAttackRight = new Bitmap[] { lionoSprites[0,1],
                lionoSprites[1,1],
                lionoSprites[2,1]
            };
            attackRight = new Bitmap[] { lionoSprites[3,1],
                lionoSprites[4,1],
                lionoSprites[5,1]
            };
            crouchRight = new Bitmap[] { lionoSprites[6,1] };
            crouchAttackRight = new Bitmap[] { lionoSprites[7,1],
                lionoSprites[8,1],
                lionoSprites[9,1]
            };
            //flip all
            standLeft          = flipSprite(standRight);
            walkLeft           = flipSprite(walkRight);
            jumpLeft           = flipSprite(jumpRight);
            jumpAttackLeft     = flipSprite(jumpAttackRight);
            attackLeft         = flipSprite(attackRight);
            crouchLeft         = flipSprite(crouchRight);
            crouchAttackLeft   = flipSprite(crouchAttackRight);

            //initialise state            
            _directionFacingRight = true;
            momentumRight = false;
            momentumLeft = false;
            this.StandNeutral();
            this.positionX = this._initialPosX = 100;
            this.positionY = this._initialPosY = 122;
            this.isJumping = false;//Init jumping to false
            this._jumpSpeed = 0;//Default no speed
        }

        public void StandNeutral() {
            //set animation
            if (_directionFacingRight)
            {
                this.setAnimationStatus(standRight);
            }
            else
            {
                this.setAnimationStatus(standLeft);
            }
        }
        public void WalkRight()
        {
            this.setAnimationStatus(walkRight);
            _directionFacingRight = true;
        }
        public void WalkLeft()
        {
            this.setAnimationStatus(walkLeft);
            _directionFacingRight = false;
        }
        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.timer.aspx
        /// </summary>
        public void Jump()
        {
            //initialise jump by setting a jump off point (won't always be the floor)
            //as well as a flag to prevent further jumping until the initial jump is complete.
            //The negative jump speed allows the sprite to move up, then down.
            this._initialPosY = this.positionY;
            this.isJumping = true;
            this._jumpSpeed = -9;

            //is the sprite jumping to the right, left or straight up?
            if (this.momentumRight)
            {
                this.setAnimationStatus(jumpRight);
                //liono.jumpRight();
            }
            if (this.momentumLeft)
            {
                this.setAnimationStatus(jumpLeft);
                //liono.jumpLeft();
            }
            else
            {
                //set animation
                if (_directionFacingRight)
                {
                    this.setAnimationStatus(jumpRight);
                }
                else
                {
                    this.setAnimationStatus(jumpLeft);
                }
                jumpTimer.Tick += new EventHandler(TimerJumpUp);
            }            

            // Update the jump position every 0.05 seconds (this coincides with the 20fps set in the gameTimer).
            jumpTimer.Interval = 50;
            jumpTimer.Start();

            // Runs the timer, and raises the event. 
            while (this.isJumping)
            {
                // Processes all the events in the queue.
                Application.DoEvents();
            }            
        }
        /// <summary>
        ///     Jump logic taken from:
        ///     http://flatformer.blogspot.ie/2010/02/making-character-jump-in-xnac-basic.html
        ///     This is the method to run when the timer is raised.
        /// </summary>         
        private void TimerJumpUp(Object sender, EventArgs e)
        {
            jumpTimer.Stop();

            // Process the jump logic 
            //if (this.positionY >= 0)
            //{
                this.positionY += this._jumpSpeed;
                this._jumpSpeed += 1;
                if (this.positionY >= this._initialPosY)
                {
                    this.positionY = this._initialPosY;

                }
                else
                {
                    //finished the jump
                    this.isJumping = false;
                }
                // Restarts the timer and increments the counter.
                jumpTimer.Enabled = true;
            //}
            //else
            //{
            //    // Stops the timer.
            //    this.isJumping = false;
            //    Debug.WriteLine("help");
            //}
        }
        public void Crouch()
        {
            //set animation
            if (_directionFacingRight)
            {
                this.setAnimationStatus(crouchRight);
            }
            else
            {
                this.setAnimationStatus(crouchLeft);
            }
        }
        public void Attack()
        {
            //set animation
            if (_directionFacingRight)
            {
                this.setAnimationStatus(attackRight);
            }
            else
            {
                this.setAnimationStatus(attackLeft);
            }
        }
        public void CrouchAttack()
        {
            //set animation
            if (_directionFacingRight)
            {
                this.setAnimationStatus(crouchAttackRight);
            }
            else
            {
                this.setAnimationStatus(crouchAttackLeft);
            }
        }
    }
}