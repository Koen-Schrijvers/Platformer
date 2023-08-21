using Platformer.Entities;
using Platformer.Entities.Enemies;
using System;
using System.Diagnostics;

namespace Platformer.Utilities.CollisionEvents
{
    internal class BasicEnemyCollisionEvent : BaseCollisionEvent
    {
        public override void Execute(ICollidable other, ICollidable thisObject)
        {
            PlayerCharacter p = other as PlayerCharacter;
            BaseEnemy e = thisObject as BaseEnemy;
            if (p == null || e == null) return;
            float overlapX = CalculateOverlapX(other.Hitbox, e.Hitbox);
            float overlapY = CalculateOverlapY(other.Hitbox, e.Hitbox);
            if (Math.Abs(overlapX /= p.Hitbox.Width) >= Math.Abs(overlapY /= p.Hitbox.Height) && overlapY > 0)
            {
                p.CurrentSpeedY = -4f;
                p.IsGrounded = true;
                e.TakeDamage(1);
            }
            else
            {
                p.TakeDamage(1);
                p.DisableInput(0.3d);
                e.CurrentDirection *= -1;
                if (overlapX < 0)
                {
                    p.KnockBack(5f, -2f);
                }
                else
                {
                    p.KnockBack(-5f, -2f);
                }
            }
        }
    }
}
