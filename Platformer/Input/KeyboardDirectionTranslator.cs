using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Input
{
    internal class KeyboardDirectionTranslator
    {
        private bool spacebar = false;
        public Vector2 TranslateInputToDirection()
        {
            KeyboardState keyboard = Keyboard.GetState();
            Vector2 direction = new Vector2(0,1); // is altijd 1 wegens zwaartekracht
            if (keyboard.IsKeyDown(Keys.D))
            {
                direction.X = 1;
            }
            else if(keyboard.IsKeyDown(Keys.Q))
            {
                direction.X = -1;
            }


            if (keyboard.IsKeyDown(Keys.Space) && !spacebar)
            { 
                direction.Y = -1; 
                spacebar = true;
            }
            if(keyboard.IsKeyUp(Keys.Space)) 
            {
                spacebar =  false;
            }
            return direction;
        }
    }
}
