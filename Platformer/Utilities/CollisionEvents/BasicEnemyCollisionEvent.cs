using Platformer.Entities;
using Platformer.Entities.Enemies;
using System;

namespace Platformer.Utilities.CollisionEvents
{
    internal class BasicEnemyCollisionEvent : BaseCollisionEvent
    {
        private BaseEnemy subject;
        public BasicEnemyCollisionEvent(BaseEnemy subject)
        {
            this.subject = subject;
        }
        public override void Execute(ICollidable other)
        {
            float overlapX = CalculateOverlapX(other.Hitbox, subject.Hitbox);
            float overlapY = CalculateOverlapY(other.Hitbox, subject.Hitbox);
            PlayerCharacter p = other as PlayerCharacter;
            if (Math.Abs(overlapX /= p.Hitbox.Width) >= Math.Abs(overlapY /= p.Hitbox.Height) && overlapY > 0)
            {
                p.CurrentSpeedY = -4f;
                p.IsGrounded = true;
                subject.TakeDamage(1);
            }
            else
            {
                p.TakeDamage(1);
                p.DisableInput(0.3d);
                subject.CurrentDirection *= -1;
                if (overlapX < 0)
                {
                    p.KnockBack(100f, -2f);
                }
                else
                {
                    p.KnockBack(-100f, -2f);
                }
            }
        }
    }
}
