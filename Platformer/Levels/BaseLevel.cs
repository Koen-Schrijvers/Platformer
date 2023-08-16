using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.Entities;
using Platformer.Entities.Enemies;
using Platformer.Managers;
using Platformer.Screens;
using Platformer.Terrain;
using Platformer.Terrain.Blocks;
using Platformer.UI;
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
        private Texture2D backgroundTexture;
        private HUD hud;
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
            Enemies.Add(new Mushroom(new Vector2(450,300), 410, 522)); // 522
            player = new PlayerCharacter(new Vector2(300,300));
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
                Game1.ScreenHeight - GameBoard.GetLength(0)*16
                );
            CollisionManager.Instance().CurrentLevel = this;
            Initialize();
            Collidables = new List<ICollidable>();
            Collidables.AddRange(Blocks);
            Collidables.AddRange(Enemies);
            backgroundTexture = ContentManager.Instance().LevelBackgroundTexture;
            hud = new HUD(player);
        }
        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            if(player.IsDead) GameManager.Instance().ChangeScreen(new StartScreen());
            for (int i = 0; i < Enemies.Count; i ++)
            {
                Enemies[i].Update(gameTime);
                if (Enemies[i].IsDead) {
                    Collidables.Remove(Enemies[i]);
                    Enemies.RemoveAt(i);
                };
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) GameManager.Instance().ChangeScreen(new StartScreen());
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight), Color.White);
            Blocks.ForEach(x => x.Draw(spriteBatch));
            Enemies.ForEach(x => x.Draw(spriteBatch));
            player.Draw(spriteBatch);
            hud.Draw(spriteBatch);
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
    }
}
