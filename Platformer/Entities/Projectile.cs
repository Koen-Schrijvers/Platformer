using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Managers;
using Platformer.Movement;
using Platformer.Movement.MovementBehaviours;
using Platformer.Utilities;
using Platformer.Utilities.CollisionEvents;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Entities
{
    internal class Projectile : IGameObject, IMovable, ICollidable
    {
        Texture2D texture;
        private Vector2 scale;
        public Vector2 Position { get; set; }
        public Vector2 BaseSpeed {get; private set;}
        public Vector2 CurrentDirection { get; set; }
        public float CurrentSpeedX { get; set; }
        public float CurrentSpeedY { get; set; }
        public IMovementBehaviour MovementBehaviour { get; set; }
        public bool IsDead { get; set; }

        private FloatRectangle hitbox;
        public FloatRectangle Hitbox 
        { 
            get { 
                return new FloatRectangle(
                    Position.X + (hitbox.X * scale.X),
                    Position.Y + (hitbox.Y * scale.Y),
                    hitbox.Width * scale.X,
                    hitbox.Height * scale.Y
                    ); 
            }
        }
        public ICollisionEvent CollisionEvent { get; set; }
        public Projectile(Vector2 scale, Vector2 position, Vector2 direction)
        {
            this.scale = scale;
            Position = position;
            CurrentDirection = direction;
            CurrentSpeedX = 0;
            CurrentSpeedY = 0;
            MovementBehaviour = new SimpleXAndYNoGravityMovementBehaviour();
            BaseSpeed = new Vector2(4f,4f);
            texture = ContentManager.Instance().BulletTexture;
            hitbox = new FloatRectangle(4,4,8,8);
            CollisionEvent = new ProjectileCollisionEvent();
            IsDead= false;
        }

        public void Update(GameTime gameTime)
        {
            MovementBehaviour.Move(this, gameTime);
            IsDead = Position.X < 0 || Position.X > Game1.ScreenWidth || Position.Y < 0 || Position.Y > Game1.ScreenHeight || IsDead;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position,null,Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
