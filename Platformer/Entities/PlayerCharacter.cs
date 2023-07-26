using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Platformer.AnimationUtil;
using Platformer.Input;
using Platformer.Movement;
using Platformer.Movement.MovementBehaviours;
using Platformer.Utilities;
using Platformer.Utilities.CollisionEvents;

namespace Platformer.Entities
{
    internal class PlayerCharacter : IMovable, ICollidable
    {
        //animation
        private Texture2D texture;
        private List<Animation> animations;
        private int animationIndex;
        private Vector2 scale;
        private SpriteEffects spriteEffect;

        //input
        private KeyboardDirectionTranslator keyboardDirectionTranslator;
        private bool inputIsDisabled;
        private double inputDisabledTimeLimit;
        private double inputDisabledTimeCount;

        //movement
        public Vector2 CurrentDirection { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 BaseSpeed { get; }
        public float CurrentSpeedX { get; set; }
        public float CurrentSpeedY { get; set; }
        public bool IsGrounded { 
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
        public IMovementBehaviour MovementBehaviour { get; set; }

        //collision
        private FloatRectangle hitbox;
        public FloatRectangle Hitbox
        {
            get
            {
                return new FloatRectangle(
                    this.Position.X + this.hitbox.X,
                    this.Position.Y + this.hitbox.Y,
                    this.hitbox.Width,
                    this.hitbox.Height  
                    );
            }
        }
        public CollisionTag tag => throw new System.NotImplementedException();
        public ICollisionEvent CollisionEvent { get; set; }

        //combat
        private int health; 
        public int Health { 
            get 
            {
                return health;
            }
        }
        public bool IsInvincible { get; }


        public PlayerCharacter(Texture2D texture)
        {
            this.texture = texture;
            this.animations = SpriteCutter.CreateAnimations(texture, new int[7] {11, 12, 1, 6, 1, 5, 7});
            this.Position = new Vector2(300,300);
            this.CurrentDirection = new Vector2(0, 0);
            this.BaseSpeed = new Vector2(3, 0);
            this.hitbox = new FloatRectangle(6, 6, 20, 26);
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.keyboardDirectionTranslator = new KeyboardDirectionTranslator();
            this.MovementBehaviour = new PlayerMovementBehaviour();
            this.scale = new Vector2(1,1);
            this.health = 3;
            this.inputDisabledTimeCount = 0;
    }

        public void Update(GameTime gameTime)
        {
            ReadInput(gameTime);
            Move(gameTime);
            //Collision
            Animate(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture, 
                Position, 
                animations[animationIndex].CurrentFrame, 
                Color.White,
                0f,
                Vector2.Zero, 
                scale, 
                spriteEffect,
                0f
            );
        }

        public void Move(GameTime gameTime)
        {
            this.MovementBehaviour.Move(this, gameTime);
            PlayerMovementBehaviour m = (PlayerMovementBehaviour)this.MovementBehaviour;
            if (Position.Y > 300)
            {
                Position = new Vector2(Position.X, 300);
                m.IsGrounded= true;
                CurrentSpeedY = 0f;
            }
        }
        private void Animate(GameTime gameTime)
        {
            SelectAnimation();
            this.animations[this.animationIndex].Update(gameTime);
        }
        public void TakeDamage(int damage)
        {
            if (!IsInvincible)
            {
                health -= damage;
            }
        }
        public void KnockBack(float speedX,float speedY)
        {
            this.IsGrounded= false;
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
                if(this.inputDisabledTimeCount >= this.inputDisabledTimeLimit)
                {
                    this.inputIsDisabled = false;
                    this.inputDisabledTimeCount = 0;
                    this.inputDisabledTimeLimit = 0;
                }
                this.CurrentDirection = new Vector2(0,0);
                return;
            }
            this.CurrentDirection = keyboardDirectionTranslator.TranslateInputToDirection();
        }
        private void SelectAnimation()
        {
            PlayerMovementBehaviour m = (PlayerMovementBehaviour)this.MovementBehaviour;
            if (CurrentDirection.X == -1)
            {
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else if (CurrentDirection.X == 1) 
            {
                spriteEffect = SpriteEffects.None;
            }
            if (m.IsGrounded)
            {
                if (CurrentSpeedX != 0f)
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
                if (CurrentSpeedY <= 0f)
                { 
                    if (m.HasDoubleJumped)
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
        }
    }
}
