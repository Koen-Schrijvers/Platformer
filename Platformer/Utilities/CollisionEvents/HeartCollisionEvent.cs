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
    internal class HeartCollisionEvent : BaseCollisionEvent
    {
        public override void Execute(ICollidable other, ICollidable thisObject)
        {
            PlayerCharacter p = other as PlayerCharacter;
            Heart h = thisObject as Heart;
            if (p != null && h != null)
            {
                p.GainHealth(1);
                h.IsTaken= true;
                ContentManager.Instance().PowerupSoundEffect.Play();
            }
        }
    }
}
