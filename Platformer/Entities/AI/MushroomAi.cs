using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Entities.AI
{
    internal class MushroomAi : IAi
    {
        private Enemy vessel;
        public MushroomAi(Enemy enemy) 
        { 
            this.vessel = enemy;
        }
        public void Act()
        {
            if(vessel.Position.X>700 || vessel.Position.X < 0)
            {
                vessel.CurrentDirection *= new Vector2(-1, 1);
            }
        }
    }
}
