﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WorldOfTheThreeKingdoms.GameScreens.ScreenLayers
{
    public class MapTile:Tile 
    {
        public string  number;
        private Texture2D tileTexture;

        public Texture2D TileTexture
        {
            get
            {
                return this.tileTexture;
            }
            set
            {
                this.tileTexture = value;
            }
        }
         
    }



}
