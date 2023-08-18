using Microsoft.Xna.Framework;
using Platformer.AnimationUtil.Animation_handlers;
using Platformer.AnimationUtil;
using Platformer.Entities.AI;
using Platformer.Movement;
using Platformer.Movement.MovementBehaviours;
using Platformer.Utilities.CollisionEvents;
using Platformer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Platformer.Managers;

namespace Platformer.Entities.Enemies
{
    internal class Turtle : BaseEnemy, IGravity
    {
        public bool IsGrounded
        {
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

        public Turtle(Vector2 spawn, int limitLeft, int limitRight)
        {
            this.Texture = ContentManager.Instance().TurtleTexture;
            this.Animations = SpriteCutter.CreateAnimations(Texture, new int[2] { 14, 5 });
            this.Position = spawn;
            this.hitbox = new FloatRectangle(7, 6, 30, 20);
            this.CurrentDirection = new Vector2(1, 0);
            this.BaseSpeed = new Vector2(0.5f, 0);
            this.CollisionEvent = new TurtleCollisionEvent();
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.MovementBehaviour = new HorizontalSimpleMovementBehaviour();
            this.Scale = new Vector2(0.7f, 0.7f);
            this.ai = new MushroomAi(this, limitLeft, limitRight);
            this.animationHandler = new TurtleAnimationHandler();
            this.Health = 1;
        }
        public override void TakeDamage(int damage)
        {
            Health -= damage;
            animationHandler.PlayFullAnimation(Animations[1]);
        }


    }
}
