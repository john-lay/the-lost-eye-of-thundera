using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Threading;

namespace the_lost_eye_of_thundera.Sprites
{
    class Liono : Sprite
    {
        public Bitmap[] standRight, walkRight, crouchRight, jumpRight;
        public Bitmap[] standLeft, walkLeft, crouchLeft, jumpLeft;
        public Bitmap[] attackRight, jumpAttackRight, crouchAttackRight;
        public Bitmap[] attackLeft, jumpAttackLeft, crouchAttackLeft;

        private bool directionFacingRight, isJumping;
        private int initialPosX, initialPosY, jumpSpeed;

        public Liono() {
            
            //source image
            this.spriteSheet = new Bitmap(@"..\..\Resources\liono_sprite.bmp");
            Bitmap[,] lionoSprites = sliceUpTile(spriteSheet, 54, 54, 10, 2, Color.Magenta);

            //initialise animation arrays
            standRight = new Bitmap[] { lionoSprites[0, 0] };
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
            jumpRight = new Bitmap[] { lionoSprites[9, 0] };
            jumpAttackRight = new Bitmap[] { lionoSprites[0,1],
                lionoSprites[1,1],
                lionoSprites[2,1]
            };
            attackRight = new Bitmap[] { lionoSprites[3,1],
                lionoSprites[4,1],
                lionoSprites[5,1]
            };
            crouchRight = new Bitmap[] { lionoSprites[6, 1] };
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
            directionFacingRight = true;
            this.StandNeutral();
            this.positionX = this.initialPosX = 100;
            this.positionY = this.initialPosY = 122;
            this.isJumping = false;//Init jumping to false
            this.jumpSpeed = 0;//Default no speed
        }

        public void StandNeutral() {
            //set animation
            if (directionFacingRight)
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
            directionFacingRight = true;
            this.positionX += 2;
        }
        public void WalkLeft()
        {
            this.setAnimationStatus(walkLeft);
            directionFacingRight = false;
            this.positionX -= 2;
        }
        public void Jump()
        {
            //set animation
            if (directionFacingRight)
            {
                this.setAnimationStatus(jumpRight);
            }
            else {
                this.setAnimationStatus(jumpLeft);
            }
            //set position
            //while(this.isJumping){
            //    this.updateJump();
                
            //}
            //ground sprite
            //this.positionY = 122;
            //this.StandNeutral();
            if (this.isJumping)
            {
                this.positionY += this.jumpSpeed;//Making it go up
                this.jumpSpeed++;
                if (this.positionY >= initialPosY)
                //If it's farther than ground
                {
                    this.positionY = initialPosY;//Then set it on
                    this.isJumping = false;
                }
                Thread.Sleep(200);
            }
            else
            {
                this.isJumping = true;
                jumpSpeed = -14;//Give it upward thrust
            }

        }
        private void updateJump() {
            if (this.positionY != 50)
            {
                this.positionY--;
                Thread.Sleep(200);                
            }
            else {
                this.isJumping = true;
            }
            
        }
        public void Crouch()
        {
            //set animation
            if (directionFacingRight)
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
            if (directionFacingRight)
            {
                this.setAnimationStatus(attackRight);
            }
            else
            {
                this.setAnimationStatus(attackLeft);
            }
        }
    }
}