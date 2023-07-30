using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.AnimationUtil.Animation_handlers
{
    internal interface IAnimationHandler
    {
        public Animation CurrentAnimation { get; }
        public void Animate(GameTime gameTime, IAnimated animated);
        public void Draw(SpriteBatch spriteBatch, IAnimated animated, Vector2 position);
        public void PlayFullAnimation(Animation animation);
        public void Blink(double duration, double interval);
    }
}
