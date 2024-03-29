﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Levels;
using Platformer.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Managers
{
    internal class GameManager
    {
        private static GameManager instance;
        private IScreen currentScreen;
        private Game1 game;
        public BaseLevel currentLevel { get; set; }
        private GameManager() { }
        public static GameManager Instance()
        {
            instance ??= new GameManager();
            return instance;
        }
        public void Initialize(Game1 game)
        {
            this.game = game;
            currentScreen = new StartScreen();
        }
        public void Update(GameTime gameTime) 
        { 
            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch) 
        { 
            currentScreen.Draw(spriteBatch);
        }
        public void ChangeScreen(IScreen newScreen)
        {
            currentScreen = newScreen;
        }
        public void StartLevel(BaseLevel level)
        {
            currentScreen = level;
            currentLevel = level;
            CollisionManager.Instance().CurrentLevel = level;
        }
        public void QuitGame()
        {
            game.Exit();
        }
    }
}
