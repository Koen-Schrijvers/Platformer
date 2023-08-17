﻿using Microsoft.Xna.Framework;
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

        //health
        private bool isInvincible;
        private double invincibleDurationLimit;
        private double invincibleCurrentDuration;

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
            IsDead= false;
            isInvincible= false;
            invincibleCurrentDuration= 0f;
            invincibleDurationLimit = 0f;
        }

        public override void Update(GameTime gameTime)
        {
            ReadInput(gameTime);
            Move(gameTime);
            CollisionManager.Instance().HandleCollisions(this);
            CheckHealth();
            CheckInvincibility(gameTime);
            Animate(gameTime);
        }

        protected override void Move(GameTime gameTime)
        {
            this.MovementBehaviour.Move(this, gameTime);
            if (Position.Y > Game1.ScreenHeight*2) IsDead = true; 
            if (Position.X < -hitbox.Left)
            {
                Position = new Vector2(-hitbox.Left,Position.Y);
                CurrentSpeedX= 0f;
            }
            else if(Position.X > Game1.ScreenWidth - hitbox.Right)
            {
                Position = new Vector2(Game1.ScreenWidth - hitbox.Right, Position.Y);
                CurrentSpeedX = 0f;
            }
        }
        public override void TakeDamage(int damage)
        {
            if (!isInvincible)
            {
                Health -= damage;
            }
            SetInvincible(1d);
            animationHandler.PlayFullAnimation(Animations[6]);
            animationHandler.Blink(1d, 0.05);
        }
        public void KnockBack(float speedX, float speedY)
        {
            IsGrounded = false;
            CurrentSpeedX = speedX;
            CurrentSpeedY = speedY;
            Position += new Vector2(CurrentSpeedX, CurrentSpeedY);
        }
        public void DisableInput(double duration)
        {
            keyboardDirectionTranslator.InputIsDisabled = true;
            keyboardDirectionTranslator.InputDisabledTimeLimit = duration;
            keyboardDirectionTranslator.InputDisabledTimeCount = 0;
        }
        public void GainHealth(int health)
        {
            Health += health;
        }
        public void SetInvincible(double duration)
        {
            invincibleDurationLimit = duration;
            invincibleCurrentDuration= 0;
            isInvincible= true;
        }
        private void ReadInput(GameTime gameTime)
        {
           CurrentDirection = keyboardDirectionTranslator.Translate(gameTime);
        }
        private void CheckHealth()
        {
            if (Health <= 0)
            {
                if (animationHandler.CurrentAnimation.IsLastFrame)
                {
                    IsDead = true;
                }
            }
           
        }
        private void CheckInvincibility(GameTime gameTime)
        { 
            if (isInvincible)
            {
                invincibleCurrentDuration += gameTime.ElapsedGameTime.TotalSeconds;
                if (invincibleCurrentDuration>= invincibleDurationLimit) 
                {
                    invincibleCurrentDuration = 0;
                    isInvincible= false;
                    invincibleDurationLimit= 0;
                }
            }
        }
    }
}
