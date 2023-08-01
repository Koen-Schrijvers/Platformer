using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Movement.MovementBehaviours
{
    internal interface IMovementBehaviour
    {
        void Move(IMovable movable, GameTime gameTime);
    }
}
