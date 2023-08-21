﻿using Platformer.Entities.Enemies;
using Platformer.Entities;
using Platformer.Managers;
using Platformer.Terrain.Blocks;
using Platformer.Terrain.Pickups;
using Platformer.UI;
using Platformer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Platformer.Levels
{
    internal class Level2 : BaseLevel
    {

        public Level2() : base(new int[,] {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,19, 19, 0, 0, 0, 19, 19,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2, 3, 3, 3, 3, 3, 4,0,0,0,0,0,0,0,0,16,17,18,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 6, 6, 6, 6, 6, 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 6, 6, 6, 6, 6, 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 6, 6, 6, 6, 6, 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 6, 6, 6, 6, 6, 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 6, 6, 6, 6, 6, 7,0,0,0,0,0,0,0,0,16,18,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 6, 6, 6, 6, 6, 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,10,10,10,10,10,10,17,17,17,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,3, 4, 0, 0, 0, 0, 0,0,0,0,0,0,16,17,17,18,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 7, 0, 0, 0, 2, 4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,18,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,5, 7, 0, 0, 0, 5, 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 7, 0, 0, 0, 5, 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,5, 7, 0, 0, 0, 8, 11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 7, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,5, 7, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,18,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 7, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,2,3,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5, 12, 18, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 19,19,19,5,6,7,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,5, 7, 0, 0, 0, 2, 4,0,0,0,0,0,0,0,0,0,0,19,19,19,19,19,19,19,19,19,19,19,19 },
                { 3,3,3,9,6,12,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,9,7,0,0,0,5,12,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },
            })
        {
            backgroundTexture = ContentManager.Instance().LevelBackgroundTexture;
            hud = new HUD(player);
            MediaPlayer.Play(ContentManager.Instance().MarioSoundtrack);
        }

        protected override void InitializeEntities()
        {
            player = new PlayerCharacter(new Vector2(60, 420));
            Enemies.Add(new Mushroom(new Vector2(550, 450), 450, 560));
            Enemies.Add(new Turtle(new Vector2(450, 250), 445, 485));
            Enemies.Add(new KamikazeBird(new Vector2(550, 100)));
            Pickups.Add(new Heart(new Vector2(370, 440), new Vector2(1f, 1f)));
            Pickups.Add(new Heart(new Vector2(465, 250), new Vector2(1f, 1f)));
            Pickups.Add(new Apple(new Vector2(376, 130), new Vector2(1f, 1f)));
            Pickups.Add(new Ammunition(new Vector2(550, 320), new Vector2(1f, 1f)));
        }
    }
}
