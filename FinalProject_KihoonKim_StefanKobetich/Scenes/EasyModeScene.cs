using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using FinalProject_KihoonKim_StefanKobetich.Entities;
using System.Diagnostics;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    public class EasyModeScene : GameScene
    {
        private SpriteBatch _spriteBatch;
        private Texture2D tex;
        private Missile missile;
        private Game g;

        public EasyModeScene(Game game) : base(game)
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tex = game.Content.Load<Texture2D>("images/MissileFire");
            missile = new Missile(game, _spriteBatch, tex, Vector2.Zero, 5);
            this.Components.Add(missile);
            g = game;

        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                g.Exit();
            }

            // TODO: Add your update logic here
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                Vector2 pos = new Vector2(ms.X - 32, ms.Y - 32);
                //explosion.Position = pos;
                //explosion.Show();

                Missile missile = new Missile(g, _spriteBatch, tex, pos, 8);
                missile.Show();
                this.Components.Add(missile);

                Debug.Print(this.Components.Count.ToString());
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
