using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using the_lost_eye_of_thundera.Stage;

namespace the_lost_eye_of_thundera.Sprites
{
    class Sprite : Utility
    {        
        public int animationStep;
        public int positionX, positionY;
        protected Bitmap[] animationStatus;

        /// <summary>
        ///     Draws the sprites current frame to a specifed canvas
        /// </summary>
        /// <param name="canvas">Graphics: canvas to draw on</param>
        public void draw(Graphics canvas)
        {            
            //loop back around to first frame if on the final frame
            if (animationStep >= animationStatus.Length)
            {
                animationStep = 0;
            }
            Bitmap bitmap = animationStatus[animationStep];            
            //draw to the specified canvas
            canvas.DrawImage(bitmap, this.positionX, this.positionY);
        }
        public Bitmap[] flipSprite(Bitmap[] originalSprite)
        {
            var count = 0;
            var arraySize = originalSprite.Length;
            Bitmap[] newSprite = new Bitmap[arraySize];
            foreach (Bitmap sprite in originalSprite)
            {
                Bitmap temp = new Bitmap(sprite);
                temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                newSprite[count] = temp;
                count++;
            }
            return newSprite;
        }
        protected void setAnimationStatus(Bitmap[] newStatus)
        {
            if(this.animationStatus != newStatus) {
                this.animationStatus = newStatus;
            }
        }        
    }
}
