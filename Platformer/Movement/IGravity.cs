using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Movement
{
    internal interface IGravity
    {
        public bool IsGrounded { get; set; }
        public float CurrentSpeedY { get; set; }
    }
}
