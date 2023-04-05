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

namespace Platformer.Entities
{
    internal class PlayerCharacter
    {
        //animation
        private Texture2D texture;
        private List<Animation> animations;

        //input
        private KeyboardDirectionTranslator keyboardDirectionTranslator;

        //movement
      
        private Vector2 currentDirection;
        private Vector2 position;
        private Vector2 baseSpeed;
        private Vector2 currentSpeed;
     
        private float gravity;
        private float jumpImpulse;
        public PlayerCharacter(Texture2D texture)
        {
            this.texture = texture;
            this.animations = SpriteCutter.CreateAnimations(texture, new int[7] {11, 12, 1, 6, 1, 5, 7});
            this.position = new Vector2(300,300);
            this.currentDirection = new Vector2(0, 0);
            this.baseSpeed = new Vector2(3, 0);
            this.currentSpeed= new Vector2(0, 0);
            this.jumpImpulse = 10f;
            this.gravity = 1f;
            this.keyboardDirectionTranslator = new KeyboardDirectionTranslator();
        }

        public void Update(GameTime gameTime)
        {
            Move();
            Animate(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animations[1].CurrentFrame, Color.White);
        }

        public void Move()
        {
            currentDirection = keyboardDirectionTranslator.TranslateInputToDirection();
            currentSpeed.X = baseSpeed.X * currentDirection.X;
            if (currentDirection.Y == -1) {
                //jump
                currentSpeed.Y -= jumpImpulse;
            }
            currentSpeed.Y += gravity;
            position += currentSpeed;
            if(position.Y > 300)
            {
                position.Y = 300;
                currentSpeed.Y = 0;
            }
        }
        public void Animate(GameTime gameTime)
        {
            this.animations[1].Update(gameTime);
        }
    }
}
