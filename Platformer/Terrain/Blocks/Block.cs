using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.AnimationUtil;
using Platformer.Utilities;
using Platformer.Utilities.CollisionEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Terrain.Blocks
{
    internal abstract class Block: IGameObject, ICollidable
    {
        public FloatRectangle Hitbox { get; protected set; }
        public ICollisionEvent CollisionEvent { get; set; }
        public Texture2D Texture { get; protected set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        protected Rectangle textureFrame;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                    Texture,
                    Position,
                    textureFrame,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    Scale,
                    SpriteEffects.None,
                    0f); 
        }
    }
}
