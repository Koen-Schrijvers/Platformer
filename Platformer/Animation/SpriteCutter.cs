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
        public static List<Animation> CreateAnimations(Texture2D spriteSheet, int[] sheetLayout, int fps = 20)
        {
            List<Animation> animations = new();
            int frameWidth = spriteSheet.Width/sheetLayout.Max();
            int frameHeight = spriteSheet.Height/sheetLayout.Length;
            for (int row = 0; row < sheetLayout.Length; row++)
            {
                List<Rectangle> frames = new();
                for (int column = 0; column < sheetLayout[row]; column++)
                {
                    frames.Add(new Rectangle(frameWidth*column, frameHeight*row,frameWidth,frameHeight));
                }
                animations.Add(new Animation(frames, fps));
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
