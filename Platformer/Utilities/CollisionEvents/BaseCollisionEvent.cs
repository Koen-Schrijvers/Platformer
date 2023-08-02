using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities.CollisionEvents
{
    internal abstract class BaseCollisionEvent: ICollisionEvent
    {
        public abstract void Execute(ICollidable other, ICollidable thisObject);
        protected float CalculateOverlapY(FloatRectangle otherHitbox, FloatRectangle thisHitbox)
        {
            float overlapY;
            if (otherHitbox.Top < thisHitbox.Top)
            {
                overlapY = otherHitbox.Bottom - thisHitbox.Top;
                // +
            }
            else
            {
                overlapY = otherHitbox.Top - thisHitbox.Bottom;
                // -
            }
            return overlapY;
        }
        protected float CalculateOverlapX(FloatRectangle otherHitbox, FloatRectangle thisHitbox)
        {
            float overlapX;
            if (otherHitbox.Left < thisHitbox.Left)
            {
                overlapX = otherHitbox.Right - thisHitbox.Left;
                // +
                // collision left side
            }
            else
            {
                overlapX = otherHitbox.Left - thisHitbox.Right;
                // -
                // collision right side
            }
            return overlapX;
        }
    }
}
