using Platformer.Entities;
using System;

namespace Platformer.Utilities.CollisionEvents
{
    internal class BasicEnemyCollisionEvent : ICollisionEvent
    {
        private Enemy subject;
        public BasicEnemyCollisionEvent(Enemy subject)
        {
            this.subject = subject;
        }
        public void Execute(ICollidable other)
        {
            float overlapX = CalculateOverlapX(other.Hitbox);
            float overlapY = CalculateOverlapY(other.Hitbox);
            PlayerCharacter p = other as PlayerCharacter;
            if (Math.Abs(overlapX /= p.Hitbox.Width) >= Math.Abs(overlapY /= p.Hitbox.Height) && overlapY > 0)
            {
                p.CurrentSpeedY = -4f;
                p.IsGrounded= true;
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
            //p.Position = new Vector2(subject.Position.X - other.Hitbox.Width, p.Position.Y - 10);
           
        }
        private float CalculateOverlapY(FloatRectangle otherHitbox)
        {
            float overlapY;
            if (otherHitbox.Top < this.subject.Hitbox.Top)
            {
                overlapY = otherHitbox.Bottom - this.subject.Hitbox.Top;
                // +
            }
            else
            {
                overlapY = otherHitbox.Top - this.subject.Hitbox.Bottom;
                // -
            }
            return overlapY;
        }
        private float CalculateOverlapX(FloatRectangle otherHitbox)
        {
            float overlapX;
            if (otherHitbox.Left < this.subject.Hitbox.Left)
            {
                overlapX = otherHitbox.Right - this.subject.Hitbox.Left;
                // +
            }
            else
            {
                overlapX = otherHitbox.Left - this.subject.Hitbox.Right;
                // -
            }
            return overlapX;
        }
    }
}
