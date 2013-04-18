using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace the_lost_eye_of_thundera.Stage.Scenery
{
    class Background
    {
        public bool mummRa = false;
        private Bitmap _bg, _scenery, _bgMummRa, _bottomBar;
        public int bgPosX, bgPosY;
        public int sceneryPosX, sceneryPosY;
        public int bgMummRaPosX, bgMummRaPosY;
        public int bottomBarPosX, bottomBarPosY;
        public int groundOffset = 8;

        public Background() {
            //initialise bitmap objects            
            this._bg = new Bitmap(@"..\..\Resources\background.bmp");
            this._bgMummRa = new Bitmap(@"..\..\Resources\background_mumm-ra.bmp");
            this._scenery = new Bitmap(@"..\..\Resources\scenery.bmp");
            this._bottomBar = new Bitmap(@"..\..\Resources\bottom_bar.bmp");

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
            this._scenery = tileScenery(this._scenery, 20);
        }
        public void draw(Graphics canvas)
        {
            //draw to the specified canvas
            canvas.DrawImage(_bg, this.bgPosX, this.bgPosY);
            canvas.DrawImage(_scenery, this.sceneryPosX, this.sceneryPosY);
            canvas.DrawImage(_bottomBar, this.bottomBarPosX, this.bottomBarPosY);
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
