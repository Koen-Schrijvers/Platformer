using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Platformer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Movement.MovementBehaviours
{
    internal class PlayerMovementBehaviour : IMovementBehaviour
    {
        public bool IsGrounded { get; set; } = false;
        public bool HasDoubleJumped { get; set; } = false;
        private float gravity = 0.3f;
        private float jumpImpulse = -5.0f;
        private float aerialAccelerationX = 0.5f;
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
                    ContentManager.Instance().JumpSoundEffect.Play();
                }
                else if (!HasDoubleJumped)
                {
                    movable.CurrentSpeedY = jumpImpulse;
                    HasDoubleJumped = true;
                    ContentManager.Instance().JumpSoundEffect.Play();
                }
            }
            movable.CurrentSpeedY += gravity;
            if (movable.CurrentSpeedY >= 5) movable.CurrentSpeedY = 5;

            // change Position
            movable.Position += new Vector2(movable.CurrentSpeedX, movable.CurrentSpeedY);

            // reset State
            IsGrounded = false;
        }

    }
}
