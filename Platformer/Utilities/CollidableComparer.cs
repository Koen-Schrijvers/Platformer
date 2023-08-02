using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities
{
    internal class CollidableComparer : IComparer<ICollidable>
    {
        private FloatRectangle target;
        public CollidableComparer(FloatRectangle target) { this.target = target; }
        public int Compare(ICollidable x, ICollidable y)
        {
            if (x == null && y == null) { return 0; }
            else if (x == null) { return -1; }
            else if (y == null) { return 1; }


            float charToBlockXDist = new Vector2(x.Hitbox.CenterPoint.X - target.CenterPoint.X, x.Hitbox.CenterPoint.Y - target.CenterPoint.Y).Length();
            float charToBlockYDist = new Vector2(y.Hitbox.CenterPoint.X - target.CenterPoint.X, y.Hitbox.CenterPoint.Y - target.CenterPoint.Y).Length();
            return charToBlockXDist.CompareTo(charToBlockYDist);
        }
    }
}
