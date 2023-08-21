using Platformer.AnimationUtil.Animation_handlers;
using Platformer.AnimationUtil;
using Platformer.Entities.AI;
using Platformer.Movement.MovementBehaviours;
using Platformer.Utilities.CollisionEvents;
using Platformer.Utilities;
using Microsoft.Xna.Framework;
using Platformer.Managers;

namespace Platformer.Entities.Enemies
{
    internal class KamikazeBird: BaseEnemy
    {
        public KamikazeBird(Vector2 spawn)
        {
            this.Texture = ContentManager.Instance().KamikazeTexture;
            this.Animations = SpriteCutter.CreateAnimations(Texture, new int[2] { 9, 5 });
            this.Position = spawn;
            this.hitbox = new FloatRectangle(6, 12, 20, 20);
            this.CurrentDirection = new Vector2(0, 0);
            this.BaseSpeed = new Vector2(1.3f, 1.3f);
            this.CollisionEvent = new BirdCollisionEvent();
            this.CurrentSpeedX = 0f;
            this.CurrentSpeedY = 0f;
            this.MovementBehaviour = new SimpleXAndYNoGravityMovementBehaviour();
            this.Scale = new Vector2(1.1f, 1);
            this.ai = new BirdAi(this);
            this.animationHandler = new TurtleAnimationHandler();
            this.Health = 1;
        }

        public override void Update(GameTime gameTime)
        {
            ai.Act();
            if (Health > 0) Move(gameTime);
            CollisionManager.Instance().HandleOnlyProjectileCollisions(this);
            CheckHealth();
            Animate(gameTime);
        }
        public override void TakeDamage(int damage)
        {
            Health -= damage;
            animationHandler.PlayFullAnimation(Animations[1]);
        }
    }
}
