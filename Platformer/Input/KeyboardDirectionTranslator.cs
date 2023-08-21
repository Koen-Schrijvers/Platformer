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
            Vector2 direction = new Vector2(0,0);
            if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
            {
                direction.X = 1;
            }
            else if(keyboard.IsKeyDown(Keys.Q) || keyboard.IsKeyDown(Keys.Left))
            {
                direction.X = -1;
            }


            if ((keyboard.IsKeyDown(Keys.Space) || keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.Down)) && !spacebar)
            { 
                direction.Y = -1; 
                spacebar = true;
            }
            if(keyboard.IsKeyUp(Keys.Space) && keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Down)) 
            {
                spacebar =  false;
            }
            return direction;
        }

    }
}
