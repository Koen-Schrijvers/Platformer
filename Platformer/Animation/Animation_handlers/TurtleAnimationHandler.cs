using Microsoft.Xna.Framework.Graphics;
using Platformer.Entities.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.AnimationUtil.Animation_handlers
{
    internal class TurtleAnimationHandler : BaseAdvancedAnimationHandler
    {
        protected override void SelectAnimation(IAnimated animated)
        {
            Turtle t = animated as Turtle;
            if (t.CurrentDirection.X == 1)
            {
                t.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if (t.CurrentDirection.X == -1)
            {
                t.SpriteEffects = SpriteEffects.None;
            }
            CurrentAnimation = animated.Animations[0];
        }
    }
}
