using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities
{
    internal interface ICollider
    {
        Rectangle Hitbox { get; set; }

    }
}
