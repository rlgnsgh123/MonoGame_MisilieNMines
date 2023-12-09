using MissilesNMinesEscape.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace MissilesNMinesEscape.Scenes
{
    /// <summary>
    /// Help scene to display the credits
    /// </summary>
    public class CreditsScene : GameScene
    {
        private Texture2D tex;
        private SpriteBatch sb;
        private Texture2D image;
        private SpriteBatch _spriteBatch;
        private Game g;

        // HelpScene constructor
        public CreditsScene(Game game) : base(game)
        {
            g = game;
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            image = game.Content.Load<Texture2D>("credits");

        }

        // Checks if user wants to exit the credits
        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                g.Exit();
            }

            base.Update(gameTime);
        }

        // Draws the help screen to the user
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(image, new Vector2(0, 0), Color.White);
            _spriteBatch.End();
        }
    }
}
