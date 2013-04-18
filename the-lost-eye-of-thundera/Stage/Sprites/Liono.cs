using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace the_lost_eye_of_thundera.Sprites
{
    class Liono : Sprite
    {
        public Bitmap[] standRight, walkRight, crouchRight, jumpRight;
        public Bitmap[] standLeft, walkLeft, crouchLeft, jumpLeft;
        public Bitmap[] attackRight, jumpAttackRight, crouchAttackRight;
        public Bitmap[] attackLeft, jumpAttackLeft, crouchAttackLeft;

        private bool _directionFacingRight, _isJumping;
        private int _initialPosX, _initialPosY, _jumpSpeed;

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
            this.StandNeutral();
            this.positionX = this._initialPosX = 100;
            this.positionY = this._initialPosY = 122;
            this._isJumping = false;//Init jumping to false
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
        public void Jump()
        {
            //set animation
            if (_directionFacingRight)
            {
                this.setAnimationStatus(jumpRight);
            }
            else {
                this.setAnimationStatus(jumpLeft);
            }
            
            //initialise jump
            this._initialPosY = this.positionY;
            this._isJumping = true;
            this._jumpSpeed = -7;
           
            //set position            
            while (this._isJumping)
            {                
                this.updateJump();
                Debug.WriteLine("sprite posY = " + this.positionY);
                Debug.WriteLine("jump speed = " + this._jumpSpeed);
            }
        }
        /// <summary>
        ///     Jump logic taken from:
        ///     http://flatformer.blogspot.ie/2010/02/making-character-jump-in-xnac-basic.html
        /// </summary>
        private void updateJump()
        {
            this.positionY += this._jumpSpeed;
            this._jumpSpeed += 1;
            if (this.positionY >= this._initialPosY)
            {
                this.positionY = this._initialPosY;
                this._isJumping = false;
            }
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