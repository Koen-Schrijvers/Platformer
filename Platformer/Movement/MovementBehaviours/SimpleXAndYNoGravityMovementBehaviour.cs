using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Movement.MovementBehaviours
{
    internal class SimpleXAndYNoGravityMovementBehaviour : IMovementBehaviour
    {
        public void Move(IMovable movable, GameTime gameTime)
        {
            movable.CurrentSpeedX = movable.BaseSpeed.X * movable.CurrentDirection.X;
            movable.CurrentSpeedY = movable.BaseSpeed.Y * movable.CurrentDirection.Y;
            movable.Position += new Vector2(movable.CurrentSpeedX, movable.CurrentSpeedY);
        }
    }
}
