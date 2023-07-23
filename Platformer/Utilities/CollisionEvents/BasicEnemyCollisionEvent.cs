using Platformer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            PlayerCharacter p = other as PlayerCharacter;
            p.Position = new Microsoft.Xna.Framework.Vector2(100, 100);
        }
        private float CalculateOverlapY(FloatRectangle otherHitbox)
        {
            throw new NotImplementedException();
        }
        private float CalculateOverlapX(FloatRectangle otherHitbox)
        {
            throw new NotImplementedException();
        }
    }
}
