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

namespace Platformer.Entities.Enemies
{
    internal class Mushroom: BaseEnemy
    {
        public Mushroom(Texture2D texture) 
        {
            this.Texture = texture;
            this.Animations = SpriteCutter.CreateAnimations(texture, new int[3] { 14, 16, 5 });
            this.Position = new Vector2(500, 300);
            this.hitbox = new FloatRectangle(6, 12, 20, 20);
            this.CurrentDirection = new Vector2(1, 0);
            this.BaseSpeed = new Vector2(1, 0);
            this.CollisionEvent = new BasicEnemyCollisionEvent(this);
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.MovementBehaviour = new HorizontalSimpleMovementBehaviour();
            this.Scale = new Vector2(1.1f, 1);
            this.ai = new MushroomAi(this);
            this.Tag = CollisionTag.ENEMY;
            this.animationHandler = new MushroomAnimationHandler();
        }

        public override void TakeDamage(int damage)
        {
            if (!IsInvincible)
            {
                Health -= damage;
            }
            animationHandler.PlayFullAnimation(Animations[2]);
        }

        public override void Update(GameTime gameTime)
        {
            ai.Act();
            Move(gameTime);
            Animate(gameTime);
        }

        protected override void Move(GameTime gameTime)
        {
            MovementBehaviour.Move(this, gameTime);
            HorizontalSimpleMovementBehaviour m = (HorizontalSimpleMovementBehaviour)this.MovementBehaviour;
            if (Position.Y > 300)
            {
                Position = new Vector2(Position.X, 300);
                m.IsGrounded = true;
                CurrentSpeedY = 0f;
            }
        }
    }
}
