using Microsoft.Xna.Framework;
using Platformer.Movement.MovementBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Movement
{
    internal interface IMovable
    {
        public Vector2 Position { get; set; }
        public Vector2 BaseSpeed { get; }
        public Vector2 CurrentDirection { get; set; }
        public float CurrentSpeedX { get; set; }
        public float CurrentSpeedY { get; set; }
        public IMovementBehaviour MovementBehaviour { get; set; }
    }
}
