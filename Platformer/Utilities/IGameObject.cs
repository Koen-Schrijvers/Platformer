using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities
{
    internal interface IGameObject
    {
        public void Draw(SpriteBatch spriteBatch);
        public Vector2 Position { get; set; }
    }
}
