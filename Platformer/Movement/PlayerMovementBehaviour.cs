using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Movement
{
    internal class PlayerMovementBehaviour : IMovementBehaviour
    {
        public bool IsGrounded { get; set; } = false;
        public bool HasDoubleJumped { get; set; } = false;
        private float gravity = 0.3f;
        private float jumpImpulse = -6.0f;
        public void Move(IMovable movable)
        {
            if (IsGrounded)
            {
                HasDoubleJumped = false;
            }
            movable.CurrentSpeedX = movable.BaseSpeed.X * movable.CurrentDirection.X;
            if (movable.CurrentDirection.Y == -1)
            {
                if (IsGrounded)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    IsGrounded = false;
                }
                else if(!HasDoubleJumped)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    HasDoubleJumped = true;
                }
            }
            movable.CurrentSpeedY += gravity;
            movable.Position += new Vector2(movable.CurrentSpeedX, movable.CurrentSpeedY);
            //IsGrounded = false;
        }
    }
}
