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
            Mushroom m = animated as Mushroom;
            if (m.CurrentDirection.X == 1)
            {
                m.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if (m.CurrentDirection.X == -1)
            {
                m.SpriteEffects = SpriteEffects.None;
            }
            int animationIndex;
            if (m.CurrentSpeedX != 0f)
            {
                animationIndex = 1;
            }
            else
            {
                animationIndex = 0;
            }
            CurrentAnimation = animated.Animations[animationIndex];
        }
    }
}
