using Microsoft.Xna.Framework.Graphics;
using Platformer.Entities;
using Platformer.Entities.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.AnimationUtil.Animation_handlers
{
    internal class MushroomAnimationHandler : BaseAdvancedAnimationHandler
    {
        protected override void SelectAnimation(IAnimated animated)
        {
            BaseEnemy m = animated as BaseEnemy;
            if (m.CurrentDirection.X == 1)
            {
                m.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if (m.CurrentDirection.X == -1)
            {
                m.SpriteEffects = SpriteEffects.None;
            }
            AnimationType animationType;
            if (m.CurrentSpeedX != 0f)
            {
                animationType = AnimationType.RUN;
            }
            else
            {
                animationType = AnimationType.IDLE;
            }
            CurrentAnimation = animated.Animations[animationType];
        }
    }
}
