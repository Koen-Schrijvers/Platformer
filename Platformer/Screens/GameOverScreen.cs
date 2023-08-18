using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Platformer.Managers;
using Platformer.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Screens
{
    internal class GameOverScreen : BasicMenuScreen
    {
        public GameOverScreen()
        {
            backgroundTexture = ContentManager.Instance().GameOverBackgroundTexture;
            title = ContentManager.Instance().GameOver;
            titlePosition = new Vector2((Game1.ScreenWidth - title.Width) / 2,
               90);
            int menuWidth = 176;
            int menuHeight = 100;
            menu = new Menu(new Dictionary<string, Action>()
                {
                    {"menu", () => GameManager.Instance().ChangeScreen(new StartScreen()) },
                    { "quit", ()=>{ GameManager.Instance().QuitGame(); } },
                },
                new Rectangle((Game1.ScreenWidth - menuWidth) / 2, (Game1.ScreenHeight - menuHeight) / 2 + 50, menuWidth, menuHeight),
                ContentManager.Instance().ButtonTexture, 10);
            MediaPlayer.Play(ContentManager.Instance().DefeatSoundtrack);
            MediaPlayer.IsRepeating = false;
        }
    }
}
