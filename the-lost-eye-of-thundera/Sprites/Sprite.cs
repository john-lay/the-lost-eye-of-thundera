using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace the_lost_eye_of_thundera.Sprites
{
    class Sprite
    {
        protected Bitmap spriteSheet;
        /// <summary>
        ///     Takes a bitmap sprite/tile sheet and returns a 2 dimensional
        ///     array of tiles.
        /// </summary>
        /// <param name="src">Bitmap: Source file of bitmap tile sheet</param>
        /// <param name="tileWidth">int: Width of a single tile</param>
        /// <param name="tileHeight">int: Height of a single tile</param>
        /// <param name="numTileX">int: Number of tiles in the horizontal strip</param>
        /// <param name="numTileY">int: Number of tiles in the vertical strip</param>
        /// <param name="alphaColor">Color: Color used to indicate transparent area in tile</param>
        /// <returns>Bitmap[][]: 2d array of individual tiles</returns>
        protected static Bitmap[,] sliceUpTile(Bitmap src, int tileWidth, int tileHeight, int numTileX, int numTileY, Color alphaColor)
        {
            //array of bitmap
            Bitmap[,] tileArray = new Bitmap[numTileX, numTileY];

            //loop through areas in the tile sheet and slice it up.
            int tileCounterX = 0; int tileCounterY = 0;
            int tileOriginX = 0; int tileOriginY = 0;
            
            //outerloop
            for (int y = 0; y < numTileY; y++)
            {
                //innerloop
                for (int x = 0; x < numTileX; x++)
                {
                    //temp storage for single tile
                    Bitmap tempTile;
                    tempTile = Copy(src, new Rectangle(tileOriginX, tileOriginY, tileHeight, tileHeight));
                    tempTile.MakeTransparent(alphaColor);//set transparency

                    //populate array
                    tileArray[tileCounterX, tileCounterY] = tempTile;
                    //move to next empty element in the bitmap array
                    tileCounterX++;
                    //move the x origin across the width of a single tile
                    tileOriginX += tileWidth;
                }
                //move to next empty element in the bitmap array
                tileCounterY++;
                //move the y origin down the height of a single tile
                tileOriginY += tileHeight;

                //reset the bitmap array element, and x origin for this new row
                tileCounterX = 0;
                tileOriginX = 0;
            }
            return tileArray;
        }

        static public Bitmap Copy(Bitmap srcBitmap, Rectangle section)
        {
            // Create the new bitmap and associated graphics object
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);

            // Draw the specified section of the source bitmap to the new one
            g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);

            // Clean up
            g.Dispose();

            // Return the bitmap
            return bmp;
        }
    }
}
