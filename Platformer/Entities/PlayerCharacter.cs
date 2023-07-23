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
    internal class PlayerCharacter: IMovable, ICollidable
    {
        //animation
        private Texture2D texture;
        private List<Animation> animations;
        private int animationIndex;
        private Vector2 scale;
        private SpriteEffects spriteEffect;

        //input
        private KeyboardDirectionTranslator keyboardDirectionTranslator;

        //movement
        public Vector2 CurrentDirection {get; set;}
        public Vector2 Position { get; set; }
        public Vector2 BaseSpeed { get; }
        public float CurrentSpeedX { get; set; }
        public float CurrentSpeedY { get; set; }

        private IMovementBehaviour movementBehaviour;

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
            this.movementBehaviour = new PlayerMovementBehaviour();
            this.scale = new Vector2(1,1);
        }

        public void Update(GameTime gameTime)
        {
            Move(gameTime);
            //Collision
            SelectAnimation();
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
            CurrentDirection = keyboardDirectionTranslator.TranslateInputToDirection();
            this.movementBehaviour.Move(this, gameTime);
            PlayerMovementBehaviour m = (PlayerMovementBehaviour)this.movementBehaviour;
            if (Position.Y > 300)
            {
                Position = new Vector2(Position.X, 300);
                m.IsGrounded= true;
                CurrentSpeedY = 0f;
            }
        }
        public void Animate(GameTime gameTime)
        {
            this.animations[this.animationIndex].Update(gameTime);
        }
        private void SelectAnimation()
        {
            PlayerMovementBehaviour m = (PlayerMovementBehaviour)this.movementBehaviour;
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
