using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Input
{
    internal class MouseReader
    {
        private bool mousePressed;

        public MouseReader() 
        {
            mousePressed= false;
        }
        public Vector2 ReadInput() 
        {
            Vector2 position = new(-1,-1);
            MouseState mouse = Mouse.GetState();
            if(mouse.LeftButton == ButtonState.Pressed && mouse.X >=0 && CheckBoundaries(mouse) && !mousePressed)
            {
                mousePressed = true;
                return new Vector2 (mouse.X, mouse.Y);
            }
            if(mouse.LeftButton == ButtonState.Released) mousePressed = false;
            return position;
        }
        private bool CheckBoundaries(MouseState mouse)
        {
            return mouse.X >= 0 && mouse.X <= Game1.ScreenWidth 
                && mouse.Y >= 0 && mouse.Y <= Game1.ScreenHeight;
        }
    }
}
