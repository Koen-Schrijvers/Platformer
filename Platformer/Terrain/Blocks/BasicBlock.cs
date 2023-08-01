using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Terrain.Blocks
{
    internal class BasicBlock: Block
    {
        public BasicBlock(Texture2D texture, Rectangle frame, Vector2 position, Vector2 scale)
        {
            Texture = texture;
            textureFrame = frame;
            Position = position;
            Scale = scale;
        }
    }
}
