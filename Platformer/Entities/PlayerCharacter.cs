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

namespace Platformer.Entities
{
    internal class PlayerCharacter : BaseCharacter
    {

        //input
        private KeyboardDirectionTranslator keyboardDirectionTranslator;
        private bool inputIsDisabled;
        private double inputDisabledTimeLimit;
        private double inputDisabledTimeCount;

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


        public PlayerCharacter(Texture2D texture)
        {
            this.Texture = texture;
            this.Animations = SpriteCutter.CreateAnimations(texture, new int[7] { 11, 12, 1, 6, 1, 5, 7 });
            this.Position = new Vector2(300, 300);
            this.CurrentDirection = new Vector2(0, 0);
            this.BaseSpeed = new Vector2(3, 0);
            this.hitbox = new FloatRectangle(6, 6, 20, 26);
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.keyboardDirectionTranslator = new KeyboardDirectionTranslator();
            this.MovementBehaviour = new PlayerMovementBehaviour();
            this.Scale = new Vector2(1, 1);
            this.Health = 3;
            this.inputDisabledTimeCount = 0;
            this.animationHandler = new PlayerAnimationHandler();
            this.Tag = CollisionTag.PLAYER;
        }

        public override void Update(GameTime gameTime)
        {
            ReadInput(gameTime);
            Move(gameTime);
            //Collision
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
            PlayerMovementBehaviour m = (PlayerMovementBehaviour)this.MovementBehaviour;
            if (Position.Y > 300)
            {
                Position = new Vector2(Position.X, 300);
                m.IsGrounded = true;
                CurrentSpeedY = 0f;
            }
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
            this.IsGrounded = false;
            this.CurrentSpeedX = speedX;
            this.CurrentSpeedY = speedY;
        }
        public void DisableInput(double duration)
        {
            this.inputIsDisabled = true;
            this.inputDisabledTimeLimit = duration;
        }

        private void ReadInput(GameTime gameTime)
        {
            if (this.inputIsDisabled)
            {
                this.inputDisabledTimeCount += gameTime.ElapsedGameTime.TotalSeconds;
                if (this.inputDisabledTimeCount >= this.inputDisabledTimeLimit)
                {
                    this.inputIsDisabled = false;
                    this.inputDisabledTimeCount = 0;
                    this.inputDisabledTimeLimit = 0;
                }
                this.CurrentDirection = new Vector2(0, 0);
                return;
            }
            this.CurrentDirection = keyboardDirectionTranslator.TranslateInputToDirection();
        }
    }
}
