using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Entities.AI;
using Platformer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Entities.Enemies
{
    internal abstract class BaseEnemy : BaseCharacter
    {
        protected IAi ai;

        public override void Update(GameTime gameTime)
        {
            ai.Act();
            Move(gameTime);
            CollisionManager.Instance().HandleCollisions(this);
            CheckHealth();
            Animate(gameTime);
        }
    }
}
