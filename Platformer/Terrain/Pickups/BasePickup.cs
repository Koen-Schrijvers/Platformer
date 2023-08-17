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

namespace Platformer.Terrain.Pickups
{
    internal class BasePickup: IGameObject, ICollidable
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; protected set; }
        public Vector2 Scale { get; set; }
        public FloatRectangle Hitbox { get; protected set; }
        public ICollisionEvent CollisionEvent { get; set; }
        public bool IsTaken { get; set; }
        protected Animation Animation;

        public void Update(GameTime gameTime) 
        {
            Animation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Animation.CurrentFrame, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
