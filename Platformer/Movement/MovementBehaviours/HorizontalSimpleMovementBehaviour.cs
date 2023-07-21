using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Movement.MovementBehaviours
{
    internal class HorizontalSimpleMovementBehaviour : IMovementBehaviour
    {
        public bool IsGrounded { get; set; } = false;
        private float gravity = 0.15f;
        public void Move(IMovable movable, GameTime gameTime)
        {
            movable.CurrentSpeedX = movable.BaseSpeed.X * movable.CurrentDirection.X;
            movable.Position += new Vector2(movable.CurrentSpeedX, gravity);
            IsGrounded = false;
        }
    }
}
