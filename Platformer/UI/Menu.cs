using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Platformer.Managers;
using Platformer.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.UI
{
    internal class Menu
    {
        private List<MenuOption> options;
        private int selectedOption;
        private bool button1Pressed;
        private bool button2Pressed;
        private bool button3Pressed;

        public Menu(Dictionary<string, Action> options, Rectangle destRect, 
            Texture2D optionTexture = null, int buffer = 5)
        {
            int height = (destRect.Height - buffer * (options.Count-1))/options.Count;
            int currentY = destRect.Y;
            this.options = new List<MenuOption>();
            foreach(var option in options)
            {
                this.options.Add(
                    new MenuOption(
                        optionTexture, 
                        option.Value, 
                        new Rectangle(
                            destRect.X,
                            currentY,
                            destRect.Width,
                            height
                            ),
                        option.Key)
                    );
                currentY += height + buffer;
                button1Pressed = true;
                button2Pressed = true;
                button3Pressed= true;
            }
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if ((keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S)) && !button1Pressed)
            {
                button1Pressed = true;
                selectedOption += 1;
                if (selectedOption >= options.Count)
                {
                    selectedOption = 0;
                }
                ContentManager.Instance().MenuSelectionSoundEffect.Play();
            }
            if ((keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.Z)) && !button2Pressed)
            {
                button2Pressed = true;
                selectedOption -= 1;
                if (selectedOption < 0)
                {
                    selectedOption = options.Count - 1;
                }
                ContentManager.Instance().MenuSelectionSoundEffect.Play();
            }
            if (keyboard.IsKeyDown(Keys.Enter) && !button3Pressed)
            {
                button3Pressed = true;
                options[selectedOption].Execute();
            }
            if (keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.S))
            {
                button1Pressed = false;
            }
            if (keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Z))
            {
                button2Pressed = false;
            }
            if (keyboard.IsKeyUp(Keys.Enter))
            {
                button3Pressed = false;
            }
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < options.Count; i++) 
            {
                options[i].Draw(spriteBatch, i == selectedOption);
            }
        }
    }
}
