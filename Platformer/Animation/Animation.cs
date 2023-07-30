using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.AnimationUtil
{
    internal class Animation
    {
        private List<Rectangle> frames;
        private int currentFrameIndex;
        private double elapsedTime;
        public int Fps { get; set; }
        public bool IsLastFrame { 
            get
            {
                return currentFrameIndex == frames.Count - 1; 
            }
        }
        public Rectangle CurrentFrame { 
            get{
                return frames[currentFrameIndex];
            } 
        }
        public Animation(List<Rectangle> frames, int fps = 20){
            this.Fps = fps;
            this.frames = frames;
            this.currentFrameIndex = 0;
            this.elapsedTime = 0;
        }
        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if(elapsedTime >= 1d/Fps) {
                currentFrameIndex++;
                elapsedTime= 0;
            }
            if (currentFrameIndex >= frames.Count)
            {
                currentFrameIndex = 0;
            }
        }
        public void ResetAnimation()
        {
            this.currentFrameIndex = 0;
            this.elapsedTime = 0;
        }
    }
}
