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
using System.Security.Cryptography;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    /// <summary>
    /// Easy gamemode game class: The class that houses the easy version of the game
    /// </summary>
    public class EasyModeScene : GameScene
    {
        private SpriteBatch _spriteBatch;
        private Texture2D missileTex;
        private Texture2D groundBombTex;
        private Texture2D airBombTex;
        private Missile missile;
        private MineBomb mineBomb;
        private Game g;

        // Constructor to load the game materials
        public EasyModeScene(Game game) : base(game)
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            g = game;


            int airMinePos = 800;
            int groundMinePos = 700;
            int airMineCount = 10;
            int groundMineCount = 10;

            for (int i = 0; i < airMineCount; i++)
            {
                int randomPosAway = RandomNumberGenerator.GetInt32(200, 350);
                int randomPosHigh = RandomNumberGenerator.GetInt32(2, 250);

                airMinePos = airMinePos + randomPosAway;
                // Addition of MineBomb air
                airBombTex = game.Content.Load<Texture2D>("images/floatingMineBomb");
                mineBomb = new MineBomb(game, _spriteBatch, airBombTex, new Vector2(airMinePos, randomPosHigh), 10);
                this.Components.Add(mineBomb);
                mineBomb.Show();
            }

            for (int i = 0; i < groundMineCount; i++)
            {
                int randomPosAway = RandomNumberGenerator.GetInt32(250, 400);
                int randomPosHigh = RandomNumberGenerator.GetInt32(210, 375);

                groundMinePos = groundMinePos + randomPosAway;
                // Addition of MineBomb ground
                groundBombTex = game.Content.Load<Texture2D>("images/mineBombGroundHigh");
                mineBomb = new MineBomb(game, _spriteBatch, groundBombTex, new Vector2(groundMinePos, randomPosHigh), 10);
                this.Components.Add(mineBomb);
                mineBomb.Show();
            }

            //CollisionManager cm = new CollisionManager(g, missile, mineBomb);
            //this.Components.Add(cm);
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
