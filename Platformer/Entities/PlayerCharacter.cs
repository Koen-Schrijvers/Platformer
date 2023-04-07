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

namespace Platformer.Entities
{
    internal class PlayerCharacter: IMovable
    {
        //animation
        private Texture2D texture;
        private List<Animation> animations;

        //input
        private KeyboardDirectionTranslator keyboardDirectionTranslator;

        //movement
        public Vector2 CurrentDirection {get; set;}
        public Vector2 Position { get; set; }
        public Vector2 BaseSpeed { get; }
        public float CurrentSpeedX { get; set; }
        public float CurrentSpeedY { get; set; }

        private IMovementBehaviour movementBehaviour;
     
        private float gravity;
        private float jumpImpulse;
        private bool isGrounded;
        public PlayerCharacter(Texture2D texture)
        {
            this.texture = texture;
            this.animations = SpriteCutter.CreateAnimations(texture, new int[7] {11, 12, 1, 6, 1, 5, 7});
            this.Position = new Vector2(300,300);
            this.CurrentDirection = new Vector2(0, 0);
            this.BaseSpeed = new Vector2(3, 0);
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.jumpImpulse = 10f;
            this.gravity = 1f;
            this.keyboardDirectionTranslator = new KeyboardDirectionTranslator();
            this.movementBehaviour = new PlayerMovementBehaviour();
        }

        public void Update(GameTime gameTime)
        {
            Move();
            Animate(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animations[1].CurrentFrame, Color.White);
        }

        public void Move()
        {
            CurrentDirection = keyboardDirectionTranslator.TranslateInputToDirection();
            this.movementBehaviour.Move(this);
            if(Position.Y > 300){
                Position = new Vector2(Position.X,300);
                PlayerMovementBehaviour m = (PlayerMovementBehaviour)this.movementBehaviour;
                m.isGrounded = true;
                CurrentSpeedY = 0f; 
            }
        }
        public void Animate(GameTime gameTime)
        {
            this.animations[1].Update(gameTime);
        }
    }
}
