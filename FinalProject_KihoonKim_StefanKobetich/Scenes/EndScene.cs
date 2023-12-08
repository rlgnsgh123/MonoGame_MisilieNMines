using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using FinalProject_KihoonKim_StefanKobetich.Entities;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using FinalPlayerNameInput;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    /// <summary>
    /// EndScene class that is used when the player etheir wins or dies. Dislpays the users game stats and allows replay
    /// </summary>
    public class EndScene : GameScene
    {
        private static bool isFormShown = false;
        private static bool isSubmitName = false;
        private Form1 finalPlayerNameInput;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;
        StartScene startScene;

        private PlayerInfo playerInfo;
        private int finalScore;
        private int timeScore = 0;
        private int coinScore = 0;
        private int bonusScore = 0;

        private Texture2D kaboomTex;
        private Kaboom kaboom;
        private SoundEffect kaboomSound;
        private int kaboomMoveSize = 50;

        private Rectangle retryRect;
        private Rectangle exitRect;
        private string bonusMsg = string.Empty;
        private bool passed;
        Game1 g;

        // Constructor to build the end scene. Notice passed for indicating if they acually won the level or not
        public EndScene(Game game, int timeScore, int coinScore, string mode, Vector2 location, bool passed) : base(game)
        {
            playerInfo = new PlayerInfo();
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
            _spriteFont = game.Content.Load<SpriteFont>("fonts/NormalFont");
            this.timeScore = timeScore;
            this.coinScore = coinScore;
            playerInfo.GameMode = mode;
            kaboomTex = game.Content.Load<Texture2D>("images/kaboom");
            kaboomSound = game.Content.Load<SoundEffect>("audio/kaboomSound");
            g = (Game1)game;
            this.passed = passed;
            startScene = g.StartScene;


            if (passed == false)
            {
                kaboomSound.Play();
                //kaboom = new Kaboom(game, _spriteBatch, kaboomTex, location, 5); // Doesnt work
                //this.Components.Add(kaboom);
                //kaboom.Show();
                //location.Y = location.Y + kaboomMoveSize;
                //kaboom = new Kaboom(game, _spriteBatch, kaboomTex, location, 5);
                //this.Components.Add(kaboom);
                //kaboom.Show();
                //location.Y = location.Y - (kaboomMoveSize * 2);
                //kaboom = new Kaboom(game, _spriteBatch, kaboomTex, location, 5);
                //this.Components.Add(kaboom);
                //kaboom.Show();
                //location.X = location.X + kaboomMoveSize;
                //location.Y = location.Y + kaboomMoveSize;
                //kaboom = new Kaboom(game, _spriteBatch, kaboomTex, location, 5);
                //this.Components.Add(kaboom);
                //kaboom.Show();
                //location.X = location.X - (kaboomMoveSize * 2);
                //kaboom = new Kaboom(game, _spriteBatch, kaboomTex, location, 5);
                //this.Components.Add(kaboom);
                //kaboom.Show();
            }
            else
            {
                bonusMsg = "+200 Bonus!";
                bonusScore = 200;
            }

            finalScore = timeScore + coinScore + bonusScore;
            //

            //
            retryRect = new Rectangle(100, 400, 200, 50);
            exitRect = new Rectangle(400, 400, 200, 50);
            hide();
        }

        // Draws the endScene to the user
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_spriteFont, $"Game Over\nSurvival Score: {timeScore}\nCoins Collected: {coinScore}\nFinal Score: {finalScore} {bonusMsg}", new Vector2(100, 100), Color.White);
            _spriteBatch.DrawString(_spriteFont, "Retry", new Vector2(retryRect.X, retryRect.Y), Color.White);
            _spriteBatch.DrawString(_spriteFont, "Exit", new Vector2(exitRect.X, exitRect.Y), Color.White);

            _spriteBatch.End();

            //base.Draw(gameTime);
        }

        // If the endscene is enabled, call the handle input class
        public override void Update(GameTime gameTime)
        {
            if (this.Enabled)
            {
                HandleInput();
                //base.Update(gameTime);
            }
        }

        // Method that hadles the user input to save a score
        private void HandleInput()
        {
            KeyboardState ks = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            if (!isFormShown)
            {
                finalPlayerNameInput = new Form1();
                isFormShown = true;

                do
                {
                    finalPlayerNameInput.ShowDialog();
                    string tempName = finalPlayerNameInput.UserName;
                    if (tempName != null)
                    {
                        playerInfo.PlayerName = tempName;
                        isSubmitName = true;
                        break;
                    }
                } while (true);


            }
            if (retryRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && isSubmitName == true)
            {
                PlayMusic();
                Game.Components.Remove(this);
                g.PlayMenuScene.show();
                isFormShown = false;
                isSubmitName = false;
            }

            if (exitRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && isSubmitName == true)
            {
                PlayMusic();
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

        // Method to play music, here to reduce redundancy
        private void PlayMusic()
        {
            Song backgroundMusic = g.Content.Load<Song>("audio/Nio");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
        }
    }
}
