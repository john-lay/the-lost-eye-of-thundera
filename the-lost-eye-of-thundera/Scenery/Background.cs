using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace the_lost_eye_of_thundera.Scenery
{
    class Background
    {
        public bool mummRa = false;
        private Bitmap bg, scenery, bgMummRa, bottomBar;
        public int bgPosX, bgPosY;
        public int sceneryPosX, sceneryPosY;        
        public int bgMummRaPosX, bgMummRaPosY;
        public int bottomBarPosX, bottomBarPosY;
        public int groundOffset = 8;

        public Background() {
            //initialise bitmap objects            
            this.bg = new Bitmap(@"..\..\Resources\background.bmp");
            this.bgMummRa = new Bitmap(@"..\..\Resources\background_mumm-ra.bmp");
            this.scenery = new Bitmap(@"..\..\Resources\scenery.bmp");
            this.bottomBar = new Bitmap(@"..\..\Resources\bottom_bar.bmp");

            //set position
            this.bgPosX = 0;
            this.bgPosY = 0;
            this.bgMummRaPosX = 0;
            this.bgMummRaPosY = 0;
            this.sceneryPosX = 0;
            this.sceneryPosY = 47;
            this.bottomBarPosX = 0;
            this.bottomBarPosY = 176 + groundOffset;

            //tile scenery on the x-axis
            this.scenery = tileScenery(this.scenery, 5);
        }
        public void draw(Graphics canvas)
        {
            //draw to the specified canvas
            canvas.DrawImage(bg, this.bgPosX, this.bgPosY);
            canvas.DrawImage(scenery, this.sceneryPosX, this.sceneryPosY);
            canvas.DrawImage(bottomBar, this.bottomBarPosX, this.bottomBarPosY);
        }
        public Bitmap tileScenery(Bitmap scenery, int tileX)
        {
            //create a canvas
            Bitmap sceneryCanvas = new Bitmap(scenery.Width * tileX, scenery.Height);
            //select an area of the scenery image to draw (all of it)
            Rectangle sceneryRect = new Rectangle(0, 0, scenery.Width, scenery.Height);
            //handle to a graphics objects
            Graphics g = Graphics.FromImage(sceneryCanvas);

            // Draw the scenery n times onto the canvas
            for (int i = 0; i < (tileX * scenery.Width); i += scenery.Width)
            {
                g.DrawImage(scenery, i, 0, sceneryRect, GraphicsUnit.Pixel);
            }
            // Clean up
            g.Dispose();

            // Return the bitmap
            return sceneryCanvas;        
        }
    }
}
