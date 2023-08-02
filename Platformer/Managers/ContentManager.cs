﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Managers
{
    internal class ContentManager
    {
        public Texture2D FrogTexture { get; set; }
        public Texture2D MushroomTexture { get; set; }
        public Texture2D TerrainTexture { get; set; }
        private static ContentManager instance;
        private ContentManager(){
}
        public static ContentManager Instance()
        {
            instance ??= new ContentManager();
            return instance;
        }
        public void Initialize(Game1 game)
        {
            FrogTexture = game.Content.Load<Texture2D>("Entities/player_characters/Frog");
            MushroomTexture = game.Content.Load<Texture2D>("Entities/enemies/Mushroom");
            TerrainTexture = game.Content.Load<Texture2D>("Terrain/Terrain (16 x 16)");

        }
    }
}
