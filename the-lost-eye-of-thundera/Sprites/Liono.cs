using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace the_lost_eye_of_thundera.Sprites
{
    class Liono : Sprite
    {
        public Bitmap[] walk, crouch, jump;
        public Bitmap[] attack, jumpAttack, crouchAttack;

        public Liono() {
            
            //source image
            this.spriteSheet = new Bitmap("C:\\Documents and Settings\\Master John\\My Documents\\My game ideas\\the-lost-eye-of-thundera\\the-lost-eye-of-thundera\\Resources\\liono_sprite.bmp");
            Bitmap[,] lionoSprites = sliceUpTile(spriteSheet, 54, 54, 10, 2, Color.Magenta);

            //initialise animation arrays
            walk = new Bitmap[] { lionoSprites[0,0],
                lionoSprites[1,0],
                lionoSprites[2,0],
                lionoSprites[3,0],
                lionoSprites[4,0],
                lionoSprites[5,0],
                lionoSprites[6,0],
                lionoSprites[7,0],
                lionoSprites[8,0]
            };
            jump = new Bitmap[] { lionoSprites[9,0] };
            jumpAttack = new Bitmap[] { lionoSprites[0,1],
                lionoSprites[1,1],
                lionoSprites[2,1]
            };
            attack = new Bitmap[] { lionoSprites[3,1],
                lionoSprites[4,1],
                lionoSprites[5,1]
            };
            crouch = new Bitmap[] { lionoSprites[6, 1] };
            crouchAttack = new Bitmap[] { lionoSprites[7,1],
                lionoSprites[8,1],
                lionoSprites[9,1]
            };
        }
    }
}
