using Microsoft.Xna.Framework;
using Platformer.Entities.Enemies;
using Platformer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Entities.AI
{
    internal class BirdAi : IAi
    {
        private BaseEnemy vessel;
        private bool isActivated;
        public BirdAi(BaseEnemy vessel)
        {
            this.vessel = vessel;
            isActivated = false;
        }
        public void Act()
        {
            Vector2 playerPosition = GameManager.Instance().currentLevel.player.Position;
            Vector2 direction = playerPosition - vessel.Position;
            float distance = (direction).Length();
            isActivated = distance < 150 || isActivated;
            if(isActivated) vessel.CurrentDirection = Vector2.Normalize(direction);
        }
    }
}
