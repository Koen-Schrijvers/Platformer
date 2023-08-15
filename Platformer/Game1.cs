using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.AnimationUtil;
using Platformer.Entities;
using Platformer.Entities.Enemies;
using Platformer.Levels;
using Platformer.Managers;
using Platformer.Screens;
using Platformer.Terrain;
using Platformer.Terrain.Blocks;
using Platformer.UI;
using Platformer.UI.Components;
using Platformer.UI.Components.MenuActions;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Platformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BaseLevel baseLevel;
        public static int ScreenWidth = 1000;
        public static int ScreenHeight = 500;

        //TEST
        private StartScreen menu;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            //baseLevel = new BaseLevel();
            //menu = new StartScreen();
            GameManager.Instance().Initialize(this);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            //baseLevel.Update(gameTime);
            GameManager.Instance().Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //baseLevel.Draw(_spriteBatch);
            GameManager.Instance().Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}