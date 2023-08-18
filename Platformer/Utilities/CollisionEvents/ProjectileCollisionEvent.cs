using Platformer.Entities;
using Platformer.Entities.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities.CollisionEvents
{
    internal class ProjectileCollisionEvent : BaseCollisionEvent
    {
        public override void Execute(ICollidable other, ICollidable thisObject)
        {
            BaseEnemy e = other as BaseEnemy;
            Projectile p = thisObject as Projectile;
            if (p == null) return;
            if (e != null) 
            { 
                e.TakeDamage(1);
                p.IsDead = true;
            }
        }
    }
}
