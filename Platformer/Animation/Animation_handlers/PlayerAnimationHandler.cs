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
            AnimationType animationType;
            if (p.IsGrounded)
            {
                if (p.CurrentSpeedX != 0f)
                {
                    animationType = AnimationType.RUN;
                }
                else
                {
                    animationType = AnimationType.IDLE;
                }
            }
            else
            {
                if (p.CurrentSpeedY <= 0f)
                {
                    if (p.HasDoubleJumped)
                    {
                        animationType = AnimationType.DOUBLE_JUMP;
                    }
                    else
                    {
                        animationType = AnimationType.JUMP;
                    }
                }
                else
                {
                    animationType = AnimationType.FALL;
                }
            }
            CurrentAnimation = animated.Animations[animationType];
        }
    }
}
