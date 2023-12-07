
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using System.Drawing;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    /// <summary>
    /// Opening secene that contains the menu. First thing the user sees when program opens
    /// </summary>
    public class StartScene : GameScene
    {
        private MenuComponent menu;

        public MenuComponent Menu { get => menu; set => menu = value; }

        // Adding the menu to the start screen
        public StartScene(Game game) : base(game)
        {
            Song backgroundMusic = game.Content.Load<Song>("audio/Nio");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);

            Game1 g = (Game1)game;
            SpriteFont normalFont = game.Content.Load<SpriteFont>("fonts/NormalFont");
            SpriteFont selectedFont = game.Content.Load<SpriteFont>("fonts/SelectedFont");
            string[] menuItems = { "Start Game", "Help", "High Score", "Credit", "Quit" };
            Menu = new MenuComponent(g, g._spriteBatch, normalFont, selectedFont, menuItems, "Start");
            this.Components.Add(Menu);
        }
    }
}
