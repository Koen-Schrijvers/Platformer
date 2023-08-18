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
        public int ammunition { get; set; }

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
            ammunition = 1;
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
            if (mouse.X != -1 && mouse.Y != -1 && ammunition > 0) FireProjectile();
        }
        private void FireProjectile()
        {
            Vector2 direction = Vector2.Normalize(new Vector2(mouse.X, mouse.Y) - Hitbox.CenterPoint);
            GameManager.Instance().currentLevel.AddProjectile(new Projectile(new Vector2(1f, 1f), Position , direction));
            ammunition--;
        }
    }
}
