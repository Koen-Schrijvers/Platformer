using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Platformer.Input;
using Platformer.Movement.MovementBehaviours;
using Platformer.Movement;
using Platformer.Utilities.CollisionEvents;
using Platformer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platformer.AnimationUtil.Animation_handlers;
using Platformer.AnimationUtil;

namespace Platformer.Entities
{
    internal abstract class BaseCharacter: ICollidable, IAnimated, IMovable, IGameObject
    {
        //animation
        protected IAnimationHandler animationHandler;
        public Vector2 Scale { get; set; }
        public Texture2D Texture { get; protected set; }
        public List<Animation> Animations { get; protected set; }
        public SpriteEffects SpriteEffects { get; set; }

        //movement
        public Vector2 CurrentDirection { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 BaseSpeed { get; protected set; }
        public float CurrentSpeedX { get; set; }
        public float CurrentSpeedY { get; set; }
        public IMovementBehaviour MovementBehaviour { get; set; }

        //collision
        protected FloatRectangle hitbox;
        public FloatRectangle Hitbox
        {
            get
            {
                return new FloatRectangle(
                    this.Position.X + (this.hitbox.X * Scale.X),
                    this.Position.Y + (this.hitbox.Y * Scale.Y),
                    this.hitbox.Width * Scale.X,
                    this.hitbox.Height * Scale.Y
                    );
            }
        }
        public ICollisionEvent CollisionEvent { get; set; }

        //combat
        public int Health { get; protected set; }
        public bool IsDead { get; protected set; }





        public abstract void Update(GameTime gameTime);
       
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.animationHandler.Draw(spriteBatch, this, Position);
        }

        protected virtual void Move(GameTime gameTime)
        {
            MovementBehaviour.Move(this,gameTime);
        }

        protected virtual void Animate(GameTime gameTime)
        {
            animationHandler.Animate(gameTime, this);
        }
        public abstract void TakeDamage(int damage);
        protected virtual void CheckHealth()
        {
            IsDead = Health <=0 && animationHandler.CurrentAnimation.IsLastFrame || IsDead;
        }

    }
}
