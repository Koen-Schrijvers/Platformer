using Platformer.Entities;
using Platformer.Entities.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities.CollisionEvents
{
    internal class BirdCollisionEvent : BaseCollisionEvent
    {
        public override void Execute(ICollidable other, ICollidable thisObject)
        {
            PlayerCharacter p = other as PlayerCharacter;
            BaseEnemy e = thisObject as BaseEnemy;
            if (p == null || e == null) return;
            p.TakeDamage(1);
            p.KnockBack(e.CurrentSpeedX, e.CurrentSpeedY);
            e.TakeDamage(1);
        }
    }
}
