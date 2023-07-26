using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Movement.MovementBehaviours
{
    public enum MovementState
    {
        GROUNDED,
        AIRBORNE,
        WALL_HANGING_LEFT,
        WALL_HANGING_RIGHT,
    }
    internal class PlayerMovementBehaviour : IMovementBehaviour
    {
        public bool IsGrounded { get; set; } = false;
        public bool HasDoubleJumped { get; set; } = false;
        public bool IsWallHanging { get; set; } = false;
        private float gravity = 0.3f;
        private float jumpImpulse = -5.0f;
        private float aerialAccelerationX = 0.5f;
        private float wallJumpImpulse = 3.0f;
        private double wallHangToFallingTime = 0.3d;
        private double wallHangToFallingCurrentTime = 0d;
        public MovementState CurrentState { get; set; } = MovementState.AIRBORNE;
        public void Move(IMovable movable, GameTime gameTime)
        {
            // setState
            if (IsGrounded)
            {
                HasDoubleJumped = false;
            }
            // calculateX
            if (!IsGrounded)
            {
                movable.CurrentSpeedX += aerialAccelerationX * movable.CurrentDirection.X;
                if (Math.Abs((double)movable.CurrentSpeedX) > 3)
                {
                    movable.CurrentSpeedX = Math.Sign(movable.CurrentSpeedX) * 3;
                }
            }
            else
            {
                movable.CurrentSpeedX = movable.BaseSpeed.X * movable.CurrentDirection.X;
            }


            // calculateY
            if (movable.CurrentDirection.Y == -1)
            {
                if (IsGrounded)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    IsGrounded = false;
                }
                else if (!HasDoubleJumped)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    HasDoubleJumped = true;
                }
            }
            movable.CurrentSpeedY += gravity;

            // change Position
            movable.Position += new Vector2(movable.CurrentSpeedX, movable.CurrentSpeedY);

            // reset State
            IsGrounded = false;
        }

    }
}
