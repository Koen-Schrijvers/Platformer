using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Entities;
using Platformer.Entities.Enemies;
using Platformer.Managers;
using Platformer.Screens;
using Platformer.Terrain;
using Platformer.Terrain.Blocks;
using Platformer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Levels
{
    internal class BaseLevel: IScreen
    {
        public PlayerCharacter player;
        public int[,] GameBoard { get; set; }
        public List<Block> Blocks { get; set; }
        public List<FillerBlock> FillerBlocks { get; set; }
        public Point DrawOffset { get; set; }
        public List<BaseEnemy> Enemies { get; set; }
        public List<ICollidable> Collidables { get; set; }

        public BaseLevel()
        {
            Blocks = new List<Block>();
            Enemies = new List<BaseEnemy>();
            Enemies.Add(new Mushroom(new Vector2(400,300)));
            player = new PlayerCharacter(new Vector2(300,300));
            DrawOffset = new Point(300, 300);
            GameBoard = new int[,] {
                { 4,0,0,0,0,0,0,0,0,0,0,0,2 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,5 },
                { 7,0,0,0,0,0,0,0,0,0,0,0,5 },
                { 12,3,3,3,3,3,3,3,3,3,3,3,9 } 
            };
            CollisionManager.Instance().CurrentLevel = this;
            Initialize();
            Collidables = new List<ICollidable>();
            Collidables.AddRange(Blocks);
            Collidables.AddRange(Enemies);
        }
        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            Enemies.ForEach(x => x.Update(gameTime));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Blocks.ForEach(x => x.Draw(spriteBatch));
            Enemies.ForEach(x => x.Draw(spriteBatch));
            player.Draw(spriteBatch);

        }
        private void Initialize()
        {
            Blocks = new List<Block>();
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i, j] != 0)
                    {
                        Blocks.Add(BlockFactory.CreateBasicBlock((BlockType)GameBoard[i, j],i, j, DrawOffset, new Vector2(1,1)));
                    }
                }
            }
        }
        public void ResetLevel()
        {

        }
    }
}
