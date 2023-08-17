using Microsoft.Xna.Framework.Graphics;
using Platformer.AnimationUtil.Animation_handlers;
using Platformer.AnimationUtil;
using Platformer.Entities.AI;
using Platformer.Movement.MovementBehaviours;
using Platformer.Utilities.CollisionEvents;
using Platformer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Platformer.Movement;
using Platformer.Managers;

namespace Platformer.Entities.Enemies
{
    internal class Mushroom: BaseEnemy, IGravity
    {
        public bool IsGrounded {
            get 
            {
                HorizontalSimpleMovementBehaviour m = MovementBehaviour as HorizontalSimpleMovementBehaviour;
                return m.IsGrounded;
            }
            set 
            {
                HorizontalSimpleMovementBehaviour m = MovementBehaviour as HorizontalSimpleMovementBehaviour;
                m.IsGrounded = value;
            } 
        }
        public Mushroom(Vector2 spawn, int limitLeft, int limitRight) 
        {
            this.Texture = ContentManager.Instance().MushroomTexture;
            this.Animations = SpriteCutter.CreateAnimations(Texture, new int[3] { 14, 16, 5 });
            this.Position = spawn;
            this.hitbox = new FloatRectangle(6, 12, 20, 20);
            this.CurrentDirection = new Vector2(1, 0);
            this.BaseSpeed = new Vector2(0.75f, 0);
            this.CollisionEvent = new BasicEnemyCollisionEvent(this);
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.MovementBehaviour = new HorizontalSimpleMovementBehaviour();
            this.Scale = new Vector2(1.1f, 1);
            this.ai = new MushroomAi(this, limitLeft, limitRight);
            this.animationHandler = new MushroomAnimationHandler();
            this.Health = 1;
        }


        public override void TakeDamage(int damage)
        {
            Health -= damage;
            animationHandler.PlayFullAnimation(Animations[2]);
        }

        public override void Update(GameTime gameTime)
        {
            ai.Act();
            Move(gameTime);
            CollisionManager.Instance().HandleCollisions(this);
            CheckHealth();
            Animate(gameTime);
        }

        protected override void Move(GameTime gameTime)
        {
            MovementBehaviour.Move(this, gameTime);
        }
        private void CheckHealth()
        {
            if (Health <= 0)
            {
                if (animationHandler.CurrentAnimation.IsLastFrame)
                {
                    IsDead = true;
                }
            }
        }
    }
}
