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
            BaseEnemy t = animated as BaseEnemy;
            if (t.CurrentDirection.X > 0)
            {
                t.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if (t.CurrentDirection.X < 0)
            {
                t.SpriteEffects = SpriteEffects.None;
            }
            CurrentAnimation = animated.Animations[AnimationType.RUN];
        }
    }
}
