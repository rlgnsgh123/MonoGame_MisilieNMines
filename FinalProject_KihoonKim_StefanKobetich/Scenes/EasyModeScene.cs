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
    /// <summary>
    /// Easy gamemode game class: The class that houses the easy version of the game
    /// </summary>
    public class EasyModeScene : GameScene
    {
        private SpriteBatch _spriteBatch;
        private Texture2D missileTex;
        private Texture2D bombTex;
        private Missile missile;
        private MineBomb mineBomb;
        private Game g;

        // Constructor to load the game materials
        public EasyModeScene(Game game) : base(game)
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Addition of missile
            missileTex = game.Content.Load<Texture2D>("images/MissileFire");
            missile = new Missile(game, _spriteBatch, missileTex, Vector2.Zero, 5);
            this.Components.Add(missile);

            // Addition of MineBomb
            bombTex = game.Content.Load<Texture2D>("images/floatingMineBomb");
            mineBomb = new MineBomb(game, _spriteBatch, bombTex, Vector2.Zero, 10);
            this.Components.Add(mineBomb);

            g = game;

        }

        // Controls what makes the game objects appear
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

                Missile missile = new Missile(g, _spriteBatch, missileTex, pos, 8);
                missile.Show();
                this.Components.Add(missile);

                MineBomb mineBomb = new MineBomb(g, _spriteBatch, bombTex, pos, 5);
                mineBomb.Show();
                this.Components.Add(mineBomb);

                Debug.Print(this.Components.Count.ToString());
            }

            base.Update(gameTime);
        }

        // Allows the game to be drawn to the user
        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
