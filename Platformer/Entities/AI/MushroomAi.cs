using Microsoft.Xna.Framework;
using Platformer.Entities.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Entities.AI
{
    internal class MushroomAi : IAi
    {
        private BaseEnemy vessel;
        private int limitLeft;
        private int limitRight;
        public MushroomAi(BaseEnemy enemy, int limitLeft, int limitRight) 
        { 
            this.vessel = enemy;
            this.limitLeft = limitLeft;
            this.limitRight = limitRight;
        }
        public void Act()
        {
            if(vessel.Position.X<=limitLeft || vessel.Position.X >= limitRight)
            {
                vessel.CurrentDirection *= new Vector2(-1, 1);
            }
        }
    }
}
