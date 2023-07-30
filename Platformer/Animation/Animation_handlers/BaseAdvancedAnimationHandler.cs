using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Platformer.AnimationUtil;
using Platformer.Entities;
using Platformer.Movement.MovementBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.AnimationUtil.Animation_handlers
{
    internal abstract class BaseAdvancedAnimationHandler: IAnimationHandler
    {
        private bool animationLock;
        private bool canDraw;
        private bool isBlinking;
        private double blinkingDurationLimit;
        private double blinkingCurrentDuration;
        private double blinkingInterval;
        public Animation CurrentAnimation { get; protected set; }
        public BaseAdvancedAnimationHandler()
        {
            canDraw = true;
            blinkingDurationLimit = 0;
            blinkingCurrentDuration = 0;
            isBlinking = false;
            blinkingInterval = 0;
        }
        protected abstract void SelectAnimation(IAnimated animated);

        public void Animate(GameTime gameTime, IAnimated animated)
        {
            Animation previous = CurrentAnimation;
            if (!animationLock)
            {
                SelectAnimation(animated);
            }
            if (previous != CurrentAnimation)
            {
                CurrentAnimation.ResetAnimation();
            }
            CurrentAnimation.Update(gameTime);
            if (animationLock && CurrentAnimation.IsLastFrame)
            {
                animationLock = false;
            }
            if (isBlinking)
            {
                blinkingCurrentDuration += gameTime.ElapsedGameTime.TotalSeconds;
                double currentInterval = blinkingCurrentDuration % (2 * blinkingInterval);
                if (currentInterval >= blinkingInterval)
                {
                    canDraw = false;
                }
                else
                {
                    canDraw = true;
                }
                if (blinkingCurrentDuration >= blinkingDurationLimit)
                {
                    canDraw = true;
                    isBlinking = false;
                    blinkingCurrentDuration = 0;
                    blinkingDurationLimit = 0;
                }
            }
        }

        public void Blink(double duration, double interval)
        {
            isBlinking = true;
            blinkingInterval = interval;
            blinkingDurationLimit = duration;
        }

        public void Draw(SpriteBatch spriteBatch, IAnimated animated, Vector2 position)
        {
            if (canDraw)
            {
                spriteBatch.Draw(
                    animated.Texture,
                    position,
                    CurrentAnimation.CurrentFrame,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    animated.Scale,
                    animated.SpriteEffects,
                    0f);
            }

        }

        public void PlayFullAnimation(Animation animation)
        {
            CurrentAnimation.ResetAnimation();
            animation.ResetAnimation();
            CurrentAnimation = animation;
            animationLock = true;
        }
    }
}

