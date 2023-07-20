using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Movement
{
    public enum MovementState{
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
        private float jumpImpulse = -6.0f;
        private float aerialAccelerationX = 0.5f;
        private float wallJumpImpulse = 3.0f;
        private double wallHangToFallingTime = 0.3d;
        private double wallHangToFallingCurrentTime = 0d;
        public MovementState CurrentState { get; set; } = MovementState.AIRBORNE;
        public void Move(IMovable movable, GameTime gameTime)
        {
            if (CurrentState == MovementState.GROUNDED || CurrentState == MovementState.WALL_HANGING_LEFT || CurrentState == MovementState.WALL_HANGING_RIGHT)
            {
                HasDoubleJumped = false;
            }
            // X
            if(CurrentState== MovementState.AIRBORNE)
            {
                movable.CurrentSpeedX += aerialAccelerationX * movable.CurrentDirection.X;
                if (Math.Abs((double)movable.CurrentSpeedX) > 3)
                {
                    movable.CurrentSpeedX = Math.Sign(movable.CurrentSpeedX) * 3;
                }
            }
            else if(CurrentState == MovementState.WALL_HANGING_LEFT || CurrentState == MovementState.WALL_HANGING_RIGHT)
            {
                if(movable.CurrentDirection.X != 0)
                {
                    wallHangToFallingCurrentTime += gameTime.ElapsedGameTime.TotalSeconds;
                    if(wallHangToFallingCurrentTime >= wallHangToFallingTime)
                    {
                        movable.CurrentSpeedX = movable.BaseSpeed.X * movable.CurrentDirection.X;
                        wallHangToFallingCurrentTime = 0d;
                    }
                }
                else
                {
                    wallHangToFallingCurrentTime = 0d;
                }
            }
            else
            {
                movable.CurrentSpeedX = movable.BaseSpeed.X * movable.CurrentDirection.X;
            }

            // Y
            movable.CurrentSpeedY += gravity;
            if (movable.CurrentDirection.Y == -1)
            {
                if (CurrentState == MovementState.GROUNDED)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                }
                else if (CurrentState == MovementState.WALL_HANGING_LEFT || CurrentState == MovementState.WALL_HANGING_RIGHT)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    movable.CurrentSpeedX = wallJumpImpulse;
                }
                else if(!HasDoubleJumped)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    HasDoubleJumped = true;
                }
            }
            else if (CurrentState == MovementState.WALL_HANGING_LEFT || CurrentState == MovementState.WALL_HANGING_RIGHT)
            {
                movable.CurrentSpeedY /= 2;
            }

            // Change Position
            movable.Position += new Vector2(movable.CurrentSpeedX, movable.CurrentSpeedY);
            IsGrounded = false;
            CurrentState = MovementState.AIRBORNE;
        }
        /*
            if (IsGrounded)
            {
                HasDoubleJumped = false;
                IsWallHanging = false;
            }
            if (IsWallHanging)
            {
                HasDoubleJumped = false; 
            }
            movable.CurrentSpeedX = movable.BaseSpeed.X * movable.CurrentDirection.X;
            if (movable.CurrentDirection.Y == -1)
            {
                if ((IsGrounded))
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    IsGrounded = false;
                    IsWallHanging= false;
                }
                else if (IsWallHanging)
                {
                    
                }
                else if(!HasDoubleJumped)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    HasDoubleJumped = true;
                }
            }
            movable.CurrentSpeedY += gravity;
            if (IsWallHanging)
            {
                movable.CurrentSpeedY /= 2;
            }
            movable.Position += new Vector2(movable.CurrentSpeedX, movable.CurrentSpeedY);
            //IsGrounded = false;
         */
    }
}
