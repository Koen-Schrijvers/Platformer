using Platformer.AnimationUtil.Animation_handlers;
using Platformer.AnimationUtil;
using Platformer.Entities.AI;
using Platformer.Movement.MovementBehaviours;
using Platformer.Utilities.CollisionEvents;
using Platformer.Utilities;
using Microsoft.Xna.Framework;
using Platformer.Movement;
using Platformer.Managers;
using System.Collections.Generic;

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
            this.Animations = SpriteCutter.CreateAnimations(Texture, new Dictionary<AnimationType, int>() {
                {AnimationType.IDLE, 14 },
                {AnimationType.RUN, 16 },
                {AnimationType.HURT, 5 },
            });
            this.Position = spawn;
            this.hitbox = new FloatRectangle(6, 12, 20, 20);
            this.CurrentDirection = new Vector2(1, 0);
            this.BaseSpeed = new Vector2(0.75f, 0);
            this.CollisionEvent = new BasicEnemyCollisionEvent();
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.MovementBehaviour = new HorizontalSimpleMovementBehaviour();
            this.Scale = new Vector2(1.1f, 1);
            this.ai = new MushroomAi(this, limitLeft, limitRight);
            this.animationHandler = new MushroomAnimationHandler();
            this.Health = 1;
        }

       
    }
}
