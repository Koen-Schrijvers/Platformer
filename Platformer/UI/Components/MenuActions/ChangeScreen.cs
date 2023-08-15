using Platformer.Managers;
using Platformer.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.UI.Components.MenuActions
{
    internal class ChangeToScreen : IMenuAction
    {
        private IScreen target;
        public ChangeToScreen(IScreen targetScreen) 
        {
            target= targetScreen;
        }
        public void Execute()
        {
            GameManager.Instance().ChangeScreen(target);
        }
    }
}
