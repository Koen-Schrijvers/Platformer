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
using Microsoft.Xna.Framework.Input;
using SharpDX.XAudio2;
using Microsoft.VisualBasic.Devices;

namespace Platformer.Entities
{
    internal class PlayerCharacter : BaseCharacter, IGravity
    {

        //input
        private KeyboardDirectionTranslator keyboardDirectionTranslator;
        private MouseReader mouseReader;
        private Vector2 mouse;

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

        //projectile
        public int Ammunition { get; set; }

        public PlayerCharacter(Vector2 spawn)
        {
            Texture = ContentManager.Instance().FrogTexture;
            this.Animations = SpriteCutter.CreateAnimations(Texture, new Dictionary<AnimationType, int>() {
                {AnimationType.IDLE, 11 },
                {AnimationType.RUN, 12 },
                {AnimationType.JUMP, 1 },
                {AnimationType.DOUBLE_JUMP, 6 },
                {AnimationType.FALL, 1 },
                {AnimationType.WALL_JUMP, 5 },
                {AnimationType.HURT, 7 },
            });
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
            Ammunition = 1;
            mouseReader = new MouseReader();
            mouse = new Vector2(-1, -1);
        }

        public override void Update(GameTime gameTime)
        {
            ReadInput(gameTime);
            Act(gameTime);
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
            SetInvincible(10d);
            animationHandler.PlayFullAnimation(Animations[AnimationType.HURT]);
            animationHandler.Blink(0.5d, 0.05);
            ContentManager.Instance().HurtSoundEffect.Play();
        }
        public void KnockBack(float speedX, float speedY)
        {
            // Werkt niet 100%
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
            mouse = mouseReader.ReadInput();
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
        private void Act(GameTime gameTime)
        {
            Move(gameTime);
            if (mouse.X != -1 && mouse.Y != -1 && Ammunition > 0) FireProjectile();
        }
        private void FireProjectile()
        {
            Vector2 direction = Vector2.Normalize(new Vector2(mouse.X, mouse.Y) - Hitbox.CenterPoint);
            GameManager.Instance().currentLevel.AddProjectile(new Projectile(new Vector2(1f, 1f), Position , direction));
            Ammunition--;
        }
    }
}
