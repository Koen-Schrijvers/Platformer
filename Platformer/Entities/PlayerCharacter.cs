using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platformer.AnimationUtil;
using SharpDX.MediaFoundation;
using Platformer.Input;
using Platformer.Movement;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Platformer.Entities
{
    internal class PlayerCharacter: IMovable
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
     
        public PlayerCharacter(Texture2D texture)
        {
            this.texture = texture;
            this.animations = SpriteCutter.CreateAnimations(texture, new int[7] {11, 12, 1, 6, 1, 5, 7});
            this.Position = new Vector2(300,300);
            this.CurrentDirection = new Vector2(0, 0);
            this.BaseSpeed = new Vector2(3, 0);
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.keyboardDirectionTranslator = new KeyboardDirectionTranslator();
            this.movementBehaviour = new PlayerMovementBehaviour();
            this.scale = new Vector2(1,1);
        }

        public void Update(GameTime gameTime)
        {
            Move();
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

        public void Move()
        {
            CurrentDirection = keyboardDirectionTranslator.TranslateInputToDirection();
            this.movementBehaviour.Move(this);
            if(Position.Y > 300){
                Position = new Vector2(Position.X,300);
                PlayerMovementBehaviour m = (PlayerMovementBehaviour)this.movementBehaviour;
                m.IsGrounded = true;
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
            if(CurrentDirection.X != 0)
            {
                if (CurrentDirection.X == -1)
                {
                    spriteEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    spriteEffect = SpriteEffects.None;
                }
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
