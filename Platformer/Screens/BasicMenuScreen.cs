using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Screens
{
    internal abstract class BasicMenuScreen: IScreen
    {
        protected Texture2D backgroundTexture;
        protected Texture2D title;
        protected Vector2 titlePosition;
        protected Menu menu;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight), Color.White);
            spriteBatch.Draw(title, titlePosition, Color.White);
            menu.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            menu.Update(gameTime);
        }
    }
}
