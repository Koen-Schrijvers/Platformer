using Microsoft.Xna.Framework;
using Platformer.Entities;
using Platformer.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities.CollisionEvents
{
    internal class SpikeCollisionEvent : BaseCollisionEvent
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
                o.Position -= new Vector2(0, overlapY);
                
                if (overlapY > 0)
                {
                    PlayerCharacter p = other as PlayerCharacter;
                    if (p != null)
                    {
                        p.IsGrounded = true;
                        p.CurrentSpeedY = -5f;
                        p.TakeDamage(1);
                        return;
                    }
                    BaseCharacter c = other as  BaseCharacter; 
                    if (c != null) 
                    { 
                        c.TakeDamage(1);
                    }
                }
            }
        }
    }
}
