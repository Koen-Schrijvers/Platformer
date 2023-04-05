using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platformer.AnimationUtil;

namespace Platformer.Entities
{
    internal class PlayerCharacter
    {
        private Texture2D texture;
        private List<Animation> animations;
        public PlayerCharacter(Texture2D texture)
        {
            this.texture = texture;
            this.animations = SpriteCutter.CreateAnimations(texture, new int[7] {11, 12, 1, 6, 1, 5, 7});
        }

        public void Update(GameTime gameTime)
        {
            this.animations[1].Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(100, 100), this.animations[1].CurrentFrame, Color.White);
        }
    }
}
