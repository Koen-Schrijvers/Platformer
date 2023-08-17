using Platformer.Entities;
using Platformer.Managers;
using Platformer.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities.CollisionEvents
{
    internal class AppleCollisionEvent : BaseCollisionEvent
    {
        public override void Execute(ICollidable other, ICollidable thisObject)
        {
            PlayerCharacter character = other as PlayerCharacter;
            if (character != null)
            {
                GameManager.Instance().ChangeScreen(new VictoryScreen());
            }
        }
    }
}
