using Microsoft.Xna.Framework;
using Platformer.Utilities.CollisionEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities
{
    internal interface ICollidable
    {
        CollisionTag tag { get; }
        FloatRectangle Hitbox { get; }
        ICollisionEvent CollisionEvent { get; set; }
    }
}
