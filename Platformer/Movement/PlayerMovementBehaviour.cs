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
        public bool isGrounded {get;set;} = false;
        private bool hasDoubleJumped = false;
        private bool isWallJumping = false;
        private float gravity = 0.3f;
        private float jumpImpulse = -6.0f;
        public void Move(IMovable movable)
        {
            movable.CurrentSpeedX = movable.BaseSpeed.X * movable.CurrentDirection.X;
            if (movable.CurrentDirection.Y == -1)
            {
                if (isGrounded)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    isGrounded = false;
                    hasDoubleJumped = false;
                }
                else if(!hasDoubleJumped)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    hasDoubleJumped = true;
                }
            }
            movable.CurrentSpeedY += gravity;
            movable.Position += new Vector2(movable.CurrentSpeedX, movable.CurrentSpeedY);
        }
    }
}
