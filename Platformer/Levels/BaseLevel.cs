using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Entities;
using Platformer.Entities.Enemies;
using Platformer.Managers;
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
    internal class BaseLevel
    {
        protected Dictionary<string, Texture2D> enemyTextures;
        protected Texture2D terrainTexture;
        protected Texture2D playerCharacterTexture;
        protected Vector2 playerSpawn;
        public PlayerCharacter player;
        public int[,] GameBoard { get; set; }
        public List<Block> Blocks { get; set; }
        public List<FillerBlock> FillerBlocks { get; set; }
        public Point DrawOffset { get; set; }
        public List<BaseEnemy> Enemies { get; set; }

        public BaseLevel(Texture2D texture)
        {
            terrainTexture = texture;
            DrawOffset = new Point(300, 300);
            GameBoard = new int[,] {
                { 1,0,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,1,1,1,1,1,1,1,1,1,1,1,1 } 
            };
            CollisionManager.Instance().CurrentLevel = this;
            Initialize();
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
                        Blocks.Add(BlockFactory.CreateBasicBlock((BlockType)GameBoard[i, j], terrainTexture ,i, j, DrawOffset, new Vector2(1,1)));
                    }
                }
            }
        }
        public void ResetLevel()
        {

        }
    }
}
