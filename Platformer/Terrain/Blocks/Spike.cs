using Microsoft.Xna.Framework;
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
    internal class Spike: Block
    {
        public Spike(Vector2 position, Vector2 scale) 
        {
            Texture = ContentManager.Instance().SpikeTexture;
            Position= position;
            Scale = scale;
            CollisionEvent = new SpikeCollisionEvent();
            Hitbox = new FloatRectangle(
                position.X,
                position.Y,
                Texture.Width * scale.X, 
                Texture.Height * scale.Y /2
                );
            textureFrame = new Rectangle(0,0,16,16);
        }
    }
}
