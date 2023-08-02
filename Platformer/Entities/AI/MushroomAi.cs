using Microsoft.Xna.Framework;
using Platformer.Entities.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Entities.AI
{
    internal class MushroomAi : IAi
    {
        private BaseEnemy vessel;
        public MushroomAi(BaseEnemy enemy) 
        { 
            this.vessel = enemy;
        }
        public void Act()
        {
            if(vessel.Position.X>400 || vessel.Position.X <316)
            {
                vessel.CurrentDirection *= new Vector2(-1, 1);
            }
        }
    }
}
