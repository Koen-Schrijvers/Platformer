using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Managers;
using Platformer.Utilities;
using Platformer.Utilities.CollisionEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Terrain.Blocks
{
    internal class BasicBlock: Block
    {
        public BasicBlock(Rectangle frame, Vector2 position, Vector2 scale)
        {
            Texture = ContentManager.Instance().TerrainTexture;
            textureFrame = frame;
            Position = position;
            Scale = scale;
            CollisionEvent = new BlockMovementCollisionEvent();
            Hitbox = new FloatRectangle(
                    position.X,
                    position.Y,
                    frame.Width * Scale.X,
                    frame.Height * Scale.Y
                    );
        }
    }
}
