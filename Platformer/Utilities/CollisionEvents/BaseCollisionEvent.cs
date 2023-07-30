using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities.CollisionEvents
{
    internal abstract class BaseCollisionEvent: ICollisionEvent
    {
        public abstract void Execute(ICollidable collidable);
        protected float CalculateOverlapY(FloatRectangle otherHitbox, FloatRectangle subjectHitbox)
        {
            float overlapY;
            if (otherHitbox.Top < subjectHitbox.Top)
            {
                overlapY = otherHitbox.Bottom - subjectHitbox.Top;
                // +
            }
            else
            {
                overlapY = otherHitbox.Top - subjectHitbox.Bottom;
                // -
            }
            return overlapY;
        }
        protected float CalculateOverlapX(FloatRectangle otherHitbox, FloatRectangle subjectHitbox)
        {
            float overlapX;
            if (otherHitbox.Left < subjectHitbox.Left)
            {
                overlapX = otherHitbox.Right - subjectHitbox.Left;
                // +
            }
            else
            {
                overlapX = otherHitbox.Left - subjectHitbox.Right;
                // -
            }
            return overlapX;
        }
    }
}
