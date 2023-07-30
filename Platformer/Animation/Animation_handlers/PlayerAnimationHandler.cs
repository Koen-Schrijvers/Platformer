using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.AnimationUtil;
using Platformer.AnimationUtil.Animation_handlers;
using Platformer.Entities;
using Platformer.Movement.MovementBehaviours;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.AnimationUtil.Animation_handlers
{
    internal class PlayerAnimationHandler : BaseAdvancedAnimationHandler
    {
        protected override void SelectAnimation(IAnimated animated)
        {
            PlayerCharacter p = animated as PlayerCharacter;
            if (p.CurrentDirection.X == -1)
            {
                p.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if (p.CurrentDirection.X == 1)
            {
                p.SpriteEffects = SpriteEffects.None;
            }
            int animationIndex;
            if (p.IsGrounded)
            {
                if (p.CurrentSpeedX != 0f)
                {
                    animationIndex = 1;
                }
                else
                {
                    animationIndex = 0;
                }
            }
            else
            {
                if (p.CurrentSpeedY <= 0f)
                {
                    if (p.HasDoubleJumped)
                    {
                        animationIndex = 3;
                    }
                    else
                    {
                        animationIndex = 2;
                    }
                }
                else
                {
                    animationIndex = 4;
                }
            }
            CurrentAnimation = animated.Animations[animationIndex];
        }
    }
}
