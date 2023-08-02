using SharpDX.MediaFoundation.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities.CollisionEvents
{
    internal interface ICollisionEvent
    {
        void Execute(ICollidable other, ICollidable thisObject);
    }
}
