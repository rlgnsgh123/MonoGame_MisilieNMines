
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Addition of missile
            missileTex = game.Content.Load<Texture2D>("images/MissileFire");
            missile = new Missile(game, _spriteBatch, missileTex, Vector2.Zero, 5);
            this.Components.Add(missile);

            Random r = new Random();

            int airMinePos = 800;
            int mineCount = 10;

            for (int i = 0; i < mineCount; i++)
            {
                int randomPosAway = r.Next(200, 350);
                int randomPosHigh = r.Next(2, 300);

                airMinePos = airMinePos + randomPosAway;
                // Addition of MineBomb air
                airBombTex = game.Content.Load<Texture2D>("images/floatingMineBomb");
                mineBomb = new MineBomb(game, _spriteBatch, airBombTex, new Vector2(airMinePos, randomPosHigh), 10);
                this.Components.Add(mineBomb);
                mineBomb.Show();
            }



            // Addition of MineBomb ground
            groundBombTex = game.Content.Load<Texture2D>("images/mineBombGroundHigh");
            mineBomb = new MineBomb(game, _spriteBatch, groundBombTex, new Vector2(800, 325), 10);
            this.Components.Add(mineBomb);
            mineBomb.Show();
            mineBomb = new MineBomb(game, _spriteBatch, groundBombTex, new Vector2(1100, 260), 10);
            this.Components.Add(mineBomb);
            mineBomb.Show();
            mineBomb = new MineBomb(game, _spriteBatch, groundBombTex, new Vector2(1400, 210), 10);
            this.Components.Add(mineBomb);
            mineBomb.Show();


            CollisionManager cm = new CollisionManager(g, missile, mineBomb);
            this.Components.Add(cm);
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
