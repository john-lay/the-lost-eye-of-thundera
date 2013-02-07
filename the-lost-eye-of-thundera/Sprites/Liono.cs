using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace the_lost_eye_of_thundera.Sprites
{
    class Liono : Sprite
    {
        public Bitmap[] standRight, walkRight, crouchRight, jumpRight;
        public Bitmap[] standLeft, walkLeft, crouchLeft, jumpLeft;
        public Bitmap[] attackRight, jumpAttackRight, crouchAttackRight;
        public Bitmap[] attackLeft, jumpAttackLeft, crouchAttackLeft;

        public Liono() {
            
            //source image
            this.spriteSheet = new Bitmap("C:\\Documents and Settings\\Master John\\My Documents\\My game ideas\\the-lost-eye-of-thundera\\the-lost-eye-of-thundera\\Resources\\liono_sprite.bmp");
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
            this.StandRight();
        }

        public void StandRight() {
            this.setAnimationStatus(standRight);
        }
        public void WalkRight()
        {
            this.setAnimationStatus(walkRight);
            this.positionX += 2;
        }
        public void StandLeft()
        {
            this.setAnimationStatus(standLeft);
        }
        public void WalkLeft()
        {
            this.setAnimationStatus(walkLeft);
            this.positionX -= 2;
        }
    }
}