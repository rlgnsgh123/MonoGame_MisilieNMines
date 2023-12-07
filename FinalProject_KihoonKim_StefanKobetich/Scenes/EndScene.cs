using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FinalProject_KihoonKim_StefanKobetich.Entities;
using Microsoft.Xna.Framework.Audio;
using FinalPlayerNameInput;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    public class EndScene : GameScene
    {
        private static bool isFormShown = false;
        private static bool isSubmitName = false;
        private Form1 finalPlayerNameInput;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;
        StartScene startScene;
        private int finalScore;
        private Texture2D kaboomTex;
        private Kaboom kaboom;
        private SoundEffect kaboomSound;
        private int kaboomMoveSize = 50;
        private Rectangle retryRect;
        private Rectangle exitRect;
        Game1 g;

        public EndScene(Game game, int score, Vector2 location) : base(game)
        {
            int gameWindowX = ((Game1)game).Window.ClientBounds.X;
            int gameWindowY = ((Game1)game).Window.ClientBounds.Y;

            g = (Game1) game;

            kaboomSound = game.Content.Load<SoundEffect>("audio/kaboomSound");
            kaboomSound.Play();

            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
            _spriteFont = game.Content.Load<SpriteFont>("fonts/NormalFont");
            finalScore = score;

            startScene = g.StartScene;

            kaboomTex = game.Content.Load<Texture2D>("images/kaboom");
            kaboom = new Kaboom(game, _spriteBatch, kaboomTex, location, 5);
            this.Components.Add(kaboom);
            kaboom.Show();
            location.Y = location.Y + kaboomMoveSize;
            kaboom = new Kaboom(game, _spriteBatch, kaboomTex, (location), 5);
            this.Components.Add(kaboom);
            kaboom.Show();
            location.Y = location.Y - (kaboomMoveSize * 2);
            kaboom = new Kaboom(game, _spriteBatch, kaboomTex, (location), 5);
            this.Components.Add(kaboom);
            kaboom.Show();
            location.X = location.X + kaboomMoveSize;
            location.Y = location.Y + kaboomMoveSize;
            kaboom = new Kaboom(game, _spriteBatch, kaboomTex, (location), 5);
            this.Components.Add(kaboom);
            kaboom.Show();
            location.X = location.X - (kaboomMoveSize * 2);
            kaboom = new Kaboom(game, _spriteBatch, kaboomTex, (location), 5);
            this.Components.Add(kaboom);
            kaboom.Show();

            //
            
            //
            retryRect = new Rectangle(100, 400, 200, 50);
            exitRect = new Rectangle(400, 400, 200, 50);
            hide();
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_spriteFont, $"Game Over\nSurvival Score: {finalScore}\nCoins Collected: {PlayerInfo.PlayerCoinScore}\nFinal Score: {finalScore + PlayerInfo.PlayerCoinScore}", new Vector2(100, 100), Color.White);
            _spriteBatch.DrawString(_spriteFont, "Retry", new Vector2(retryRect.X, retryRect.Y), Color.White);
            _spriteBatch.DrawString(_spriteFont, "Exit", new Vector2(exitRect.X, exitRect.Y), Color.White);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (this.Enabled)
            {
                HandleInput();
                base.Update(gameTime);
            }
        }

        

        private void HandleInput()
        {
            KeyboardState ks = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            
            if (!isFormShown)
            {
                finalPlayerNameInput = new Form1();
                isFormShown = true;
                finalPlayerNameInput.ShowDialog();
                isSubmitName = true;
            }
            if (retryRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && isSubmitName ==true)
            {
                Game.Components.Remove(this);
                g.PlayMenuScene.show();
                isFormShown = false;
                isSubmitName = false;

            }

            if (exitRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && isSubmitName == true)
            {
                Game.Components.Remove(this);
                startScene.show();
                isFormShown = false;
                isSubmitName = false;
            }

            if (ks.IsKeyDown(Keys.Escape) && isSubmitName == true)
            {
                Game.Components.Remove(this);
                startScene.show();
                isFormShown = false;
                isSubmitName = false;
            }
        }
    }
}
