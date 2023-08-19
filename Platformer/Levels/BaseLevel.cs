using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.Entities;
using Platformer.Entities.Enemies;
using Platformer.Managers;
using Platformer.Screens;
using Platformer.Terrain;
using Platformer.Terrain.Blocks;
using Platformer.Terrain.Pickups;
using Platformer.UI;
using Platformer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Levels
{
    internal abstract class BaseLevel: IScreen
    {
        protected Texture2D backgroundTexture;
        protected HUD hud;
        public PlayerCharacter player;
        public int[,] GameBoard { get; set; }
        public List<Block> Blocks { get; set; }
        public Point DrawOffset { get; set; }
        public List<BaseEnemy> Enemies { get; set; }
        public List<BasePickup> Pickups { get; set; }
        public List<Projectile> Projectiles { get; set; }
        public List<ICollidable> Collidables { get; set; }

       
        public BaseLevel(int[,] gameBoard)
        {
            GameBoard = gameBoard;
            DrawOffset = new Point(0, Game1.ScreenHeight - GameBoard.GetLength(0) * 16);
            Blocks = new();
            Enemies = new();
            Pickups = new();
            Projectiles = new();
            InitializeBlocks();
            InitializeEntities();
            InitializeCollidables();
        }
        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            if(player.IsDead) GameManager.Instance().ChangeScreen(new GameOverScreen());
            for (int i = 0; i < Enemies.Count; i ++)
            {
                Enemies[i].Update(gameTime); 
                if (Enemies[i].IsDead) {
                    Collidables.Remove(Enemies[i]);
                    Enemies.RemoveAt(i);
                };
            }
            for (int i = 0; i < Pickups.Count; i++)
            {
                Pickups[i].Update(gameTime);
                if (Pickups[i].IsTaken)
                {
                    Collidables.Remove(Pickups[i]);
                    Pickups.RemoveAt(i);
                };
            }
            for (int i = 0; i< Projectiles.Count; i++)
            {
                Projectiles[i].Update(gameTime);
                if (Projectiles[i].IsDead)
                {
                    Collidables.Remove(Projectiles[i]);
                    Projectiles.RemoveAt(i);
                };
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) GameManager.Instance().ChangeScreen(new StartScreen());
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight), Color.White);
            Blocks.ForEach(x => x.Draw(spriteBatch));
            Enemies.ForEach(x => x.Draw(spriteBatch));
            Pickups.ForEach(x => x.Draw(spriteBatch));
            Projectiles.ForEach(x => x.Draw(spriteBatch));
            player.Draw(spriteBatch);
            hud.Draw(spriteBatch);
        }
        protected void InitializeBlocks()
        {
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
        public void AddProjectile(Projectile projectile)
        {
            Projectiles.Add(projectile);
            Collidables.Add(projectile);
        }
        protected abstract void InitializeEntities();
        protected void InitializeCollidables()
        {
            Collidables = new List<ICollidable>();
            Collidables.AddRange(Blocks);
            Collidables.AddRange(Enemies);
            Collidables.AddRange(Pickups);
            Collidables.AddRange(Projectiles);
        }
    }
}
