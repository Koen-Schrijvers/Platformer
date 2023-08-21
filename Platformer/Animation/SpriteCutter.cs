using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.AnimationUtil
{
    internal class SpriteCutter
    {
        public static Dictionary<AnimationType,Animation> CreateAnimations(Texture2D spriteSheet, Dictionary<AnimationType, int> sheetLayout ,int fps = 20)
        {
            Dictionary<AnimationType,Animation> animations = new();
            int animationCount = sheetLayout.Keys.Count();
            int frameWidth = spriteSheet.Width/sheetLayout.Values.Max();
            int frameHeight = spriteSheet.Height/animationCount;
            int currentRow = 0;
            foreach (var animation in sheetLayout)
            {
                List<Rectangle> frames = new();
                for (int column = 0; column < animation.Value; column++)
                {
                    frames.Add(new Rectangle(frameWidth * column, frameHeight * currentRow, frameWidth, frameHeight));
                }
                animations.Add(animation.Key,new Animation(frames, fps));
                currentRow++;
            }
            return animations;
        }
        public static Animation CreateSingleAnimation(Texture2D spriteSheet, int layout, int fps)
        {
            int frameWidth = spriteSheet.Width / layout;
            List<Rectangle> frames = new();
            for (int i = 0; i<layout; i++)
            {
                frames.Add(new Rectangle(i*frameWidth,0,frameWidth, spriteSheet.Height));
            }
            return new Animation(frames, fps);
        }
    }
}
