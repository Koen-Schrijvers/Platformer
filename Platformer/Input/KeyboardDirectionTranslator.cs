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
        private bool spacebar;
        public bool InputIsDisabled { get; set; }
        public double InputDisabledTimeCount { get; set; }
        public double InputDisabledTimeLimit { get; set; }
        public KeyboardDirectionTranslator() 
        { 
            spacebar = false;
            InputIsDisabled = false;
            InputDisabledTimeCount = 0;
            InputDisabledTimeLimit = 0;
        }

        public Vector2 Translate(GameTime gameTime)
        {
            if (InputIsDisabled)
            {
                InputDisabledTimeCount += gameTime.ElapsedGameTime.TotalSeconds;
                if (InputDisabledTimeCount >= InputDisabledTimeLimit)
                {
                    InputIsDisabled = false;
                    InputDisabledTimeCount = 0;
                    InputDisabledTimeLimit = 0;
                }
                return new Vector2(0, 0);
             
            }
            return TranslateInputToDirection();
        }
        private Vector2 TranslateInputToDirection()
        {
            KeyboardState keyboard = Keyboard.GetState();
            Vector2 direction = new Vector2(0,0); // is altijd 1 wegens zwaartekracht
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
