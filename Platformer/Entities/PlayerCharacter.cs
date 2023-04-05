using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Entities
{
    internal class PlayerCharacter
    {
        private Texture2D texture;
        public PlayerCharacter(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(100, 100), Color.White);
        }
    }
}
