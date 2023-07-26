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
    internal class Enemy: IMovable, ICollidable
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
        public IMovementBehaviour MovementBehaviour { get; set; }

        // Collision
        private FloatRectangle hitbox;
        public FloatRectangle Hitbox {
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
        public CollisionTag tag { get; }
        public ICollisionEvent CollisionEvent { get; set; }

        // AI
        private IAi ai;

        // Combat 
        private int health;
        public int Health
        {
            get
            {
                return health;
            }
        }
        public bool IsInvincible { get; }
        public Enemy(Texture2D texture) {
            this.texture = texture;
            this.animations = SpriteCutter.CreateAnimations(texture, new int[3] { 14, 16, 5});
            this.Position = new Vector2(500, 300);
            this.hitbox = new FloatRectangle(6, 12, 20, 20);
            this.CurrentDirection = new Vector2(1, 0);
            this.BaseSpeed = new Vector2(1, 0);
            this.CollisionEvent = new BasicEnemyCollisionEvent(this);
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.MovementBehaviour = new HorizontalSimpleMovementBehaviour();
            this.scale = new Vector2(1, 1);
            this.ai = new MushroomAi(this);
            this.tag = CollisionTag.ENEMY;
        }

        public void Update(GameTime gameTime)
        {
            ai.Act();
            this.MovementBehaviour.Move(this, gameTime);
            HorizontalSimpleMovementBehaviour m = (HorizontalSimpleMovementBehaviour)this.MovementBehaviour;
            if (Position.Y > 300)
            {
                    Position = new Vector2(Position.X, 300);
                    m.IsGrounded = true;
                    CurrentSpeedY = 0f;
            }
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
        public void Animate(GameTime gameTime)
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
        private void SelectAnimation()
        {
            HorizontalSimpleMovementBehaviour m = (HorizontalSimpleMovementBehaviour)this.MovementBehaviour;
            if (CurrentDirection.X == 1)
            {
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else if (CurrentDirection.X == -1)
            {
                spriteEffect = SpriteEffects.None;
            }
            if (m.IsGrounded)
            {
                if (CurrentSpeedX != 0f)
                {
                    animationIndex = 1;
                }
            }
            else
            {
                animationIndex = 0;
            }
        }
    }
}
