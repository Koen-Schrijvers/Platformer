using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.AnimationUtil;
using Platformer.Managers;
using Platformer.UI.Components.MenuActions;
using Platformer.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.UI.Components
{
    internal class MenuOption
    {
        private string text;
        private SpriteFont font;
        private Vector2 textPosition;
        public Texture2D ButtonTexture {get; private set;}
        public Rectangle DestinationRectangle { get; private set; }
        public Action MenuAction { get; private set; }
        public MenuOption(Texture2D texture, Action action, Rectangle destinationRect, string text)
        {
            ButtonTexture = texture;
            MenuAction = action;
            DestinationRectangle = destinationRect;
            this.text = text;
            font = ContentManager.Instance().ButtonFont;
            Vector2 textSize = font.MeasureString(text);
            textPosition = new Vector2(
                destinationRect.X + (destinationRect.Width - textSize.X) / 2,
                destinationRect.Y + (destinationRect.Height - textSize.Y) / 2);
        }
        public void Draw(SpriteBatch spriteBatch, bool isSelected)
        {
            Color color = isSelected? Color.White : Color.Gray;
            if(ButtonTexture !=null) spriteBatch.Draw(ButtonTexture, DestinationRectangle ,null, color);
            spriteBatch.DrawString(font, text, textPosition, Color.Black);
        }
        public void Execute()
        {
            Debug.WriteLine("called");
            MenuAction();
        }
    }
}
