using Platformer.Entities;
using Platformer.Managers;
using Platformer.Terrain.Pickups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities.CollisionEvents
{
    internal class AmmunitionCollisionEvent : BaseCollisionEvent
    {
        public override void Execute(ICollidable other, ICollidable thisObject)
        {
            PlayerCharacter p = other as PlayerCharacter;
            BasePickup a = thisObject as BasePickup;
            if (a == null || p == null) return;
            p.Ammunition++;
            a.IsTaken = true;
            ContentManager.Instance().AmmunitionSoundEffect.Play();
        }
    }
}
