using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Entities;
using Platformer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.UI
{
    internal class HUD
    {
        private PlayerCharacter character;
        private Texture2D heartTexture;
        private Texture2D bulletTexture;
        public HUD(PlayerCharacter character) 
        {
            this.character = character;
            heartTexture = ContentManager.Instance().HeartTexture;
            bulletTexture= ContentManager.Instance().BulletTexture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i< character.Health; i++) 
            {
                spriteBatch.Draw(heartTexture, new Rectangle(20 + i*40,50, 48, 48), Color.Wheat);
            }
            for (int i = 0; i < character.Ammunition; i++)
            {
                spriteBatch.Draw(bulletTexture, new Rectangle(30 + i * 30, 100, 25, 25), Color.Wheat);
            }
        }
    }
}
