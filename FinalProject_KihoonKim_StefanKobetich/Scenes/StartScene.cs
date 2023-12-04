
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    public class StartScene : GameScene
    {
        private MenuComponent menu;

        public MenuComponent Menu { get => menu; set => menu = value; }

        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            SpriteFont normalFont = game.Content.Load<SpriteFont>("fonts/NormalFont");
            SpriteFont selectedFont = game.Content.Load<SpriteFont>("fonts/SelectedFont");
            string[] menuItems = { "Start Game", "Help", "High Score", "Credit", "Quit" };
            Menu = new MenuComponent(g, g._spriteBatch, normalFont, selectedFont, menuItems);
            this.Components.Add(Menu);
        }
    }
}
