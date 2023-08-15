using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.AnimationUtil;
using Platformer.Levels;
using Platformer.Managers;
using Platformer.UI;
using Platformer.UI.Components.MenuActions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Platformer.Screens
{
    internal class StartScreen: IScreen
    {
        private Texture2D backgroundAnimationSpriteSheet;
        private Animation backgroundAnimation;
        private Texture2D title;
        private Vector2 titlePosition;
        private Menu menu;
        private Vector2 titleSpeed;

        public StartScreen()
        {
            int menuWidth = 176;
            int menuHeight = 126;
            title = ContentManager.Instance().Title;
            titlePosition = new Vector2(
               (Game1.ScreenWidth - title.Width) / 2,
               90
               );
            backgroundAnimationSpriteSheet = ContentManager.Instance().TitleScreenBackgroundTexture;
            backgroundAnimation = SpriteCutter.CreateSingleAnimation(
                ContentManager.Instance().TitleScreenBackgroundTexture,
                8,
                10
                );
            menu = new Menu(new Dictionary<string, Action>() {
                { "play", ()=>{ GameManager.Instance().ChangeScreen(new BaseLevel()); } },
                { "levels", null },
                { "quit", ()=>{ GameManager.Instance().QuitGame(); } },
            }, new Rectangle((Game1.ScreenWidth - menuWidth)/2, (Game1.ScreenHeight - menuHeight)/2 + 50, menuWidth, menuHeight), Managers.ContentManager.Instance().ButtonTexture, 10);
            titleSpeed = new Vector2(0.4f,0.4f); 
        }
        public void Update(GameTime gameTime)
        {
            backgroundAnimation.Update(gameTime);
            menu.Update(gameTime);
            MoveTitle();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundAnimationSpriteSheet, new Rectangle(0,0,Game1.ScreenWidth,Game1.ScreenHeight),backgroundAnimation.CurrentFrame, Color.White);
            spriteBatch.Draw(title, titlePosition, Color.White);
            menu.Draw(spriteBatch);
        }
        private void MoveTitle()
        {
            if (titlePosition.X < 250 || titlePosition.X>400)
            {
                titleSpeed.X *= -1;
            }
            if (titlePosition.Y < 70 || titlePosition.Y > 110)
            {
                titleSpeed.Y *= -1;
            }
            titlePosition += titleSpeed;
        }
    }
}
