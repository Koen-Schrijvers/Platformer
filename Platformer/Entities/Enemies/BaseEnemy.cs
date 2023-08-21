using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Entities.AI;
using Platformer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Entities.Enemies
{
    internal abstract class BaseEnemy : BaseCharacter
    {
        protected IAi ai;
        public override void Update(GameTime gameTime)
        {
            ai.Act();
            Move(gameTime);
            CollisionManager.Instance().HandleCollisions(this);
            CheckHealth();
            Animate(gameTime);
        }
        protected override void CheckHealth()
        {
            base.CheckHealth();
            if (Health<=0) GameManager.Instance().currentLevel.Collidables.Remove(this);
            if (IsDead) GameManager.Instance().currentLevel.Enemies.Remove(this);
        }
        public override void TakeDamage(int damage)
        {
            Health -= damage;
            animationHandler.PlayFullAnimation(Animations[AnimationUtil.AnimationType.HURT]);
            ContentManager.Instance().HurtEnemySoundEffect.Play();
        }
    }
}
