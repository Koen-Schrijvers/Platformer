using Microsoft.Xna.Framework;
using Platformer.AnimationUtil;
using Platformer.Utilities.CollisionEvents;
using Platformer.Utilities;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platformer.Managers;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Terrain.Pickups
{
    internal class Ammunition: BasePickup
    {
        public Ammunition(Vector2 position, Vector2 scale)
        {
            Position = position;
            Scale = scale;
            Texture = ContentManager.Instance().BulletTexture;
            Hitbox = new FloatRectangle(
                position.X + 4,
                position.Y + 4,
                8 * scale.X,
                8 * scale.Y
                );
            CollisionEvent = new AmmunitionCollisionEvent();
        }
        public override void Update(GameTime gameTime)
        {
            // Do Nothing
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
