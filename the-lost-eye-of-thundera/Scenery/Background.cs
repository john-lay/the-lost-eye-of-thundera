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
            this.bg = new Bitmap("C:\\Documents and Settings\\Master John\\My Documents\\My game ideas\\the-lost-eye-of-thundera\\the-lost-eye-of-thundera\\Resources\\background.bmp");
            this.bgMummRa = new Bitmap("C:\\Documents and Settings\\Master John\\My Documents\\My game ideas\\the-lost-eye-of-thundera\\the-lost-eye-of-thundera\\Resources\\background_mumm-ra.bmp");
            this.scenery = new Bitmap("C:\\Documents and Settings\\Master John\\My Documents\\My game ideas\\the-lost-eye-of-thundera\\the-lost-eye-of-thundera\\Resources\\scenery.bmp");
            this.bottomBar = new Bitmap("C:\\Documents and Settings\\Master John\\My Documents\\My game ideas\\the-lost-eye-of-thundera\\the-lost-eye-of-thundera\\Resources\\bottom_bar.bmp");

            //set position
            this.bgPosX = 0;
            this.bgPosY = 0;
            this.bgMummRaPosX = 0;
            this.bgMummRaPosY = 0;
            this.sceneryPosX = 0;
            this.sceneryPosY = 47;
            this.bottomBarPosX = 0;
            this.bottomBarPosY = 176 + groundOffset;
        }
        public void draw(Graphics canvas)
        {
            //draw to the specified canvas
            canvas.DrawImage(bg, this.bgPosX, this.bgPosY);
            canvas.DrawImage(scenery, this.sceneryPosX, this.sceneryPosY);
            canvas.DrawImage(bottomBar, this.bottomBarPosX, this.bottomBarPosY);
        }
    }
}
