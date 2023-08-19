using Microsoft.Xna.Framework;
using Platformer.Movement;
using Platformer.Terrain.Blocks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities.CollisionEvents
{
    internal class BlockMovementCollisionEvent : BaseCollisionEvent
    {
        public override void Execute(ICollidable other, ICollidable thisObject)
        {
            FloatRectangle otherHitbox = other.Hitbox;
            FloatRectangle thisObjectHitbox = thisObject.Hitbox;
            float overlapY = CalculateOverlapY(otherHitbox, thisObjectHitbox);
            float overlapX = CalculateOverlapX(otherHitbox, thisObjectHitbox);
            IGameObject o = other as IGameObject;
            if (Math.Abs(overlapX / otherHitbox.Width) < Math.Abs(overlapY / otherHitbox.Height))
            {
                o.Position -= new Vector2(overlapX, 0);
            }
            else
            {
                o.Position -= new Vector2(0,overlapY);
                IGravity g = other as IGravity;
                if(g != null)
                {
                    g.CurrentSpeedY = 0f;
                    if(overlapY>0) g.IsGrounded = true;
                }
            }
        }
    }
}
