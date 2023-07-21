using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.AnimationUtil;
using Platformer.Entities.AI;
using Platformer.Input;
using Platformer.Movement;
using Platformer.Movement.MovementBehaviours;
using Platformer.Utilities;
using Platformer.Utilities.CollisionEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Entities
{
    internal class Enemy: IMovable, ICollider
    {
        //animation
        private Texture2D texture;
        private List<Animation> animations;
        private int animationIndex;
        private Vector2 scale;
        private SpriteEffects spriteEffect;

        //movement
        public Vector2 CurrentDirection { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 BaseSpeed { get; }
        public float CurrentSpeedX { get; set; }
        public float CurrentSpeedY { get; set; }

        // Collision
        public Rectangle Hitbox { get; set; }
        public ICollisionEvent CollisionEvent { get; set; }

        // AI
        private IAi ai;

        private IMovementBehaviour movementBehaviour;
        public Enemy(Texture2D texture) {
            this.texture = texture;
            this.animations = SpriteCutter.CreateAnimations(texture, new int[3] { 14, 16, 5});
            this.Position = new Vector2(500, 300);
            this.CurrentDirection = new Vector2(1, 0);
            this.BaseSpeed = new Vector2(2, 0);
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.movementBehaviour = new HorizontalSimpleMovementBehaviour();
            this.scale = new Vector2(1, 1);
            this.ai = new MushroomAi(this);
        }

        public void Update(GameTime gameTime)
        {
            ai.Act();
            this.movementBehaviour.Move(this, gameTime);
            HorizontalSimpleMovementBehaviour m = (HorizontalSimpleMovementBehaviour)this.movementBehaviour;
            if (Position.Y > 300)
            {
                    Position = new Vector2(Position.X, 300);
                    m.IsGrounded = true;
                    CurrentSpeedY = 0f;
            }
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
        public void Animate(GameTime gameTime)
        {
            this.animations[this.animationIndex].Update(gameTime);
        }
        private void SelectAnimation(){}
    }
}
