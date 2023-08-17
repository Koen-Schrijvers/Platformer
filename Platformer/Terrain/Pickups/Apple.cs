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
using Microsoft.Xna.Framework;

namespace Platformer.Terrain.Pickups
{
    internal class Apple: BasePickup
    {
        public Apple(Vector2 position, Vector2 scale) 
        {
            Texture = ContentManager.Instance().AppleSpritesheetTexture;
            Animation = SpriteCutter.CreateSingleAnimation(Texture, 17, 20);
            Position = position;
            Scale = scale;
            Hitbox = new FloatRectangle(
                position.X + 16,
                position.Y + 12,
                10 * scale.X,
                10 * scale.Y
                );
            CollisionEvent = new AppleCollisionEvent();
        }
    }
}
