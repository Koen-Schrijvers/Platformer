using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.AnimationUtil;
using Platformer.Managers;
using Platformer.Utilities;
using Platformer.Utilities.CollisionEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Terrain.Pickups
{
    internal class Heart: BasePickup
    {
        public Heart(Vector2 position, Vector2 scale) 
        {
            Texture = ContentManager.Instance().HeartSpritesheetTexture;
            Animation = SpriteCutter.CreateSingleAnimation(Texture, 8, 10);
            Position= position;
            Scale= scale;
            Hitbox = new FloatRectangle(
                position.X,
                position.Y,
                16 * scale.X,
                16 * scale.Y
                );
            CollisionEvent = new HeartCollisionEvent();
        }
    }
} 
