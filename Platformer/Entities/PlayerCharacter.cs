using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Platformer.AnimationUtil;
using Platformer.Input;
using Platformer.Movement;
using Platformer.Movement.MovementBehaviours;
using Platformer.Utilities;
using Platformer.Utilities.CollisionEvents;
using Platformer.AnimationUtil.Animation_handlers;
using Platformer.Managers;

namespace Platformer.Entities
{
    internal class PlayerCharacter : BaseCharacter, IGravity
    {

        //input
        private KeyboardDirectionTranslator keyboardDirectionTranslator;

        //movement
        public bool HasDoubleJumped
        {
            get
            {
                PlayerMovementBehaviour m = this.MovementBehaviour as PlayerMovementBehaviour;
                return m.HasDoubleJumped;
            }
            set
            {
                PlayerMovementBehaviour m = this.MovementBehaviour as PlayerMovementBehaviour;
                m.HasDoubleJumped = value;
            }
        }
        public bool IsGrounded
        {
            get
            {
                PlayerMovementBehaviour m = this.MovementBehaviour as PlayerMovementBehaviour;
                return m.IsGrounded;
            }
            set
            {
                PlayerMovementBehaviour m = this.MovementBehaviour as PlayerMovementBehaviour;
                m.IsGrounded = value;
            }
        }


        public PlayerCharacter(Vector2 spawn)
        {
            Texture = ContentManager.Instance().FrogTexture;
            Animations = SpriteCutter.CreateAnimations(Texture, new int[7] { 11, 12, 1, 6, 1, 5, 7 });
            Position = spawn;
            CurrentDirection = new Vector2(0, 0);
            BaseSpeed = new Vector2(3, 0);
            hitbox = new FloatRectangle(6, 6, 20, 26);
            CurrentSpeedX = 0f;
            CurrentSpeedY = 0f;
            keyboardDirectionTranslator = new KeyboardDirectionTranslator();
            MovementBehaviour = new PlayerMovementBehaviour();
            Scale = new Vector2(1f, 1f);
            Health = 3;
            animationHandler = new PlayerAnimationHandler();
            Tag = CollisionTag.PLAYER;
        }

        public override void Update(GameTime gameTime)
        {
            ReadInput(gameTime);
            Move(gameTime);
            CollisionManager.Instance().HandleCollisions(this);
            if (Health <=0)
            {
                if (animationHandler.CurrentAnimation.IsLastFrame)
                {
                    IsDead= true;
                }
            }
            Animate(gameTime);
        }

        protected override void Move(GameTime gameTime)
        {
            this.MovementBehaviour.Move(this, gameTime);
        }
        public override void TakeDamage(int damage)
        {
            if (!IsInvincible)
            {
                Health -= damage;
            }
            animationHandler.PlayFullAnimation(Animations[6]);
            animationHandler.Blink(1d, 0.05);
        }
        public void KnockBack(float speedX, float speedY)
        {
            IsGrounded = false;
            CurrentSpeedX = speedX;
            CurrentSpeedY = speedY;
        }
        public void DisableInput(double duration)
        {
            keyboardDirectionTranslator.InputIsDisabled = true;
            keyboardDirectionTranslator.InputDisabledTimeLimit = duration;
            keyboardDirectionTranslator.InputDisabledTimeCount = 0;
        }

        private void ReadInput(GameTime gameTime)
        {
           CurrentDirection = keyboardDirectionTranslator.Translate(gameTime);
        }
    }
}
