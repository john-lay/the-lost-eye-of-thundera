using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace the_lost_eye_of_thundera.Stage.Scenery
{
    /// <summary>
    /// Allows only 2 unique types of power-ups to be referenced.
    /// </summary>
    public enum PowerUp
    {
        extraLife,
        extraTime
    }

    class Foreground : Utility
    {
        private Bitmap _sBrick, _mBrick, _lBrick;
        private Bitmap _ground, _water;
        private Bitmap _sTree1, _sTree2;
        private Bitmap _mTree1, _mTree2, _mTree3;
        private Bitmap _iTree1, _iTree2, _iTree3, _iTree4;
        private Bitmap _lTree1, _lTree2, _lTree3, _lTree4, _lTree5, _lTree6, _lTree7, _lTree8;
        private Bitmap _exLife, _exTime, _pot;
        private Bitmap _goal01, _goal02, _goal03, _goal04, _goal05, _goal06, _goal07, _goal08;
        private Bitmap _null; //blank tile
        private Bitmap _stage;
        private Bitmap[,] _tiles;
        private Bitmap[,] _visualArray;
        private int[,] _collisionArray;
        private int[,] _collectableArray;
        private int _singleTileWidth, _singleTileHeight;

        public int sceneryPosX, sceneryPosY;        
        public int animationStep;
        protected Bitmap[] animationStatus;

        public Foreground() 
        {
            this.spriteSheet = new Bitmap(@"..\..\Resources\tile_sheet.bmp");
            _singleTileWidth = 32;
            _singleTileHeight = 32;
            _tiles = sliceUpTile(spriteSheet, _singleTileWidth, _singleTileHeight, 8, 5, Color.Magenta);

            //set position
            this.sceneryPosX = 0;
            this.sceneryPosY = 48;
            //initialise animation arrays
            initTiles();
            //initialise tiles, collision and collectable (items) arrays
            populate_visualArray();
            //finally draw all the tiles to a single Bitmap
            build_stage();
        }
        /// <summary>
        /// initialise animation arrays
        /// </summary>
        private void initTiles()
        {
            //initialise animation arrays
            _sBrick = new Bitmap(_tiles[0, 0]);
            _mBrick = new Bitmap(_tiles[1, 0]);
            _lBrick = new Bitmap(_tiles[2, 0]);
            _pot    = new Bitmap(_tiles[3, 0]);
            _ground = new Bitmap(_tiles[4, 0]);
            _water  = new Bitmap(_tiles[5, 0]);
            //_water= new Bitmap(_tiles[6, 0]);
            //_water= new Bitmap(_tiles[7, 0]);

            _lTree1 = new Bitmap(_tiles[0, 1]);
            _lTree2 = new Bitmap(_tiles[1, 1]);
            _goal01 = new Bitmap(_tiles[2, 1]);
            _goal02 = new Bitmap(_tiles[3, 1]);
            _mTree1 = new Bitmap(_tiles[4, 1]);
            //empty = new Bitmap(_tiles[5, 1]);
            _iTree1 = new Bitmap(_tiles[6, 1]);
            //empty = new Bitmap(_tiles[7, 1]);

            _lTree3 = new Bitmap(_tiles[0, 2]);
            _lTree4 = new Bitmap(_tiles[1, 2]);
            _goal03 = new Bitmap(_tiles[2, 2]);
            _goal04 = new Bitmap(_tiles[3, 2]);
            _mTree2 = new Bitmap(_tiles[4, 2]);
            _iTree2 = new Bitmap(_tiles[5, 2]);
            _iTree3 = new Bitmap(_tiles[6, 2]);
            _sTree1 = new Bitmap(_tiles[7, 2]);

            _lTree5 = new Bitmap(_tiles[0, 3]);
            _lTree6 = new Bitmap(_tiles[1, 3]);
            _goal05 = new Bitmap(_tiles[2, 3]);
            _goal06 = new Bitmap(_tiles[3, 3]);
            _mTree3 = new Bitmap(_tiles[4, 3]);
            //empty = new Bitmap(_tiles[5, 3]);
            _iTree4 = new Bitmap(_tiles[6, 3]);
            _sTree2 = new Bitmap(_tiles[7, 3]);

            _lTree7 = new Bitmap(_tiles[0, 4]);
            _lTree8 = new Bitmap(_tiles[1, 4]);
            _goal07 = new Bitmap(_tiles[2, 4]);
            _goal08 = new Bitmap(_tiles[3, 4]);
            _exLife = new Bitmap(_tiles[4, 4]);
            _exTime = new Bitmap(_tiles[5, 4]);
            //empty = new Bitmap(_tiles[6, 4]);
            _null   = new Bitmap(_tiles[7, 4]);
        }
        /// <summary>
        /// initialise visual array
        /// </summary>
        private void populate_visualArray()
        {
            _visualArray = new Bitmap[,] {
                {  _null, _goal01, _goal02,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _lTree1, _lTree2,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _lTree1, _lTree2,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _lTree1, _lTree2,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _goal01, _goal02,   _null,   _null},
                {  _null, _goal03, _goal04,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,    _pot, _iTree1,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _lTree3, _lTree4,   _null,   _null,   _null,   _null, _mTree1,   _null,   _null,   _null,   _null,    _pot, _iTree1,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _lTree3, _lTree4,   _null,   _null,   _null,   _null, _mTree1,   _null,   _null,   _null,   _null,   _null,    _pot, _iTree1,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _lTree3, _lTree4,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _goal03, _goal04,   _null,   _null},
                {  _null, _goal05, _goal06,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _iTree2, _iTree3,   _null,   _null, _sTree1,   _null,   _null,   _null,   _null, _lTree5, _lTree6,   _null,   _null,   _null,   _null, _mTree2,   _null,   _null,   _null,   _null, _iTree2, _iTree3,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _lTree5, _lTree6,   _null,   _null,   _null,   _null, _mTree2,   _null,   _null,   _null,   _null,   _null, _iTree2, _iTree3,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _lTree5, _lTree6,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _goal05, _goal06,   _null,   _null},
                {  _null, _goal07, _goal08,   _null,   _null,   _null,   _null,   _null, _mBrick, _sBrick,   _null,   _null,   _null, _iTree4,   _null,   _null, _sTree2,   _null,   _null, _mBrick,   _null, _lTree7, _lTree8,   _null,   _null,   _null,   _null, _mTree3,   _null,   _null, _mBrick,   _null,   _null, _iTree4,   _null,   _null, _mBrick, _mBrick, _mBrick, _sBrick,   _null,   _null, _lTree7, _lTree8, _mBrick,   _null,   _null, _sBrick, _mTree3,   _null, _mBrick, _lBrick, _mBrick,   _null,   _null, _iTree4,   _null,   _null,   _null,   _null,   _null, _sBrick, _mBrick,   _null, _lTree7, _lTree8,   _null,   _null,   _null,   _null,   _null,   _null,   _null,   _null, _goal07, _goal08, _mBrick, _mBrick},
                {_ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground,  _water,  _water, _ground, _ground, _ground, _ground, _ground, _ground, _ground, _ground}
            };
        }
        /// <summary>
        /// generate single bitmap (stage) from the visual array
        /// </summary>
        private void build_stage()
        {
            //initialise a drawing canvas
            int _stageHeight = _visualArray.GetLength(0) * _singleTileHeight;
            int _stageWidth = _visualArray.GetLength(1) * _singleTileWidth;
            _stage = new Bitmap(_stageWidth, _stageHeight);

            //create a rectangle representing a single tile
            Rectangle singleTile = new Rectangle(0, 0, _singleTileWidth, _singleTileHeight);
            
            //handle to a graphics objects
            Graphics g = Graphics.FromImage(_stage);

            // Draw the y-axis tiles onto the canvas
            for (int y = 0; y < _visualArray.GetLength(0); y ++)
            {
                // Draw the x-axis tiles onto the canvas
                for (int x = 0; x < _visualArray.GetLength(1); x ++)
                {
                    Bitmap currentTile = _visualArray[y, x];
                    //set a starting position (top-left) where to draw the next tile on the canvas
                    int drawFromX = x * _singleTileWidth;
                    int drawFromY = y * _singleTileHeight;
                    g.DrawImage(currentTile, drawFromX, drawFromY, singleTile, GraphicsUnit.Pixel);
                }
            }
            // Clean up
            g.Dispose();      
        }
        /// <summary>
        /// The pot graphic contains the power up.
        /// This methods adds the power-up graphic
        /// </summary>
        public void addCollectable(int locX, int locY, PowerUp powerUp) 
        {
        
        }
        /// <summary>
        /// The pot graphic contains the power up.
        /// This method removes the pot graphic
        /// </summary>
        public void removeCollectable(int locX, int locY)
        {

        }
        /// <summary>
        ///     Draws the tile sheet to a specifed canvas
        /// </summary>
        /// <param name="canvas">Graphics: canvas to draw on</param>
        public void draw(Graphics canvas)
        {
            //loop back around to first frame if on the final frame
            //if (animationStep >= animationStatus.Length)
            //{
            //    animationStep = 0;
            //}
            //Bitmap bitmap = animationStatus[animationStep];
            //draw to the specified canvas
            canvas.DrawImage(_stage, this.sceneryPosX, this.sceneryPosY);
        }
    }
}
