using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.AnimationUtil
{
    internal interface IAnimated
    {
        public Texture2D Texture { get; }
        public List<Animation> Animations { get; }
        public SpriteEffects SpriteEffects { get; set; }
        public Vector2 Scale { get; set; }
    }
}
