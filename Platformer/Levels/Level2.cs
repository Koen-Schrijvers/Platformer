using Platformer.Entities.Enemies;
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

namespace Platformer.Levels
{
    internal class Level2 : BaseLevel
    {
        public Level2()
        {
            Projectiles= new List<Projectile>();
            Blocks = new List<Block>();
            Enemies = new List<BaseEnemy>
            {
                new Turtle(new Vector2(450, 300), 410, 522)
            };
            player = new PlayerCharacter(new Vector2(300, 300));
            Pickups = new List<BasePickup>
            {
                new Heart(new Vector2(128, 408), new Vector2(1f, 1f)),
                new Apple(new Vector2(760f, 280f), new Vector2(1f,1f))
            };
            GameBoard = new int[,] {
                { 4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,16,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,17,18,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,19,19,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,1,0,0,0,0,0,0,16,17,17,17,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,17,17,17,17,17,17,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,3,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,5,6,6,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,6,6,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,18,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,6,6,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,6,6,7,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19 },
                {12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,6,6,12,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 }
            };
            DrawOffset = new Point(
                0,
                Game1.ScreenHeight - GameBoard.GetLength(0) * 16
                );
            InitializeBlocks();
            Collidables = new List<ICollidable>();
            Collidables.AddRange(Blocks);
            Collidables.AddRange(Enemies);
            Collidables.AddRange(Pickups);
            backgroundTexture = ContentManager.Instance().LevelBackgroundTexture;
            hud = new HUD(player);
        }
    }
}
