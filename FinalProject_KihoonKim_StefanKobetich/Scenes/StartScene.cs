
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    /// <summary>
    /// Opening secene that contains the menu. First thing the user sees when program opens
    /// </summary>
    public class StartScene : GameScene
    {
        private MenuComponent menu;

        public MenuComponent Menu { get => menu; set => menu = value; }

        private Texture2D image;
        private SpriteBatch _spriteBatch;
        private Game1 g;

        // Adding the menu to the start screen
        public StartScene(Game game) : base(game)
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            image = game.Content.Load<Texture2D>("Image");


            Song backgroundMusic = game.Content.Load<Song>("audio/Nio");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);

            g = (Game1)game;
            SpriteFont normalFont = game.Content.Load<SpriteFont>("fonts/NormalFont");
            SpriteFont selectedFont = game.Content.Load<SpriteFont>("fonts/SelectedFont");
            string[] menuItems = { "Start Game", "Help", "High Score", "Credit", "Quit" };
            Menu = new MenuComponent(g, g._spriteBatch, normalFont, selectedFont, menuItems, "Start");
            
            this.Components.Add(Menu);
        }
        // Draws the icon to the user
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(image, new Vector2(360, 70), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
 

    }
}
