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

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    public class EndScene : GameScene
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;
        StartScene startScene;
        private int finalScore;
        private Texture2D kaboomTex;
        private Kaboom kaboom;
        private SoundEffect kaboomSound;
        private int kaboomMoveSize = 50;
        public EndScene(Game game, int score, Vector2 location) : base(game)
        {
            kaboomSound = game.Content.Load<SoundEffect>("audio/kaboomSound");
            kaboomSound.Play();

            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
            _spriteFont = game.Content.Load<SpriteFont>("fonts/NormalFont");
            finalScore = score;
            startScene = new StartScene(game);
            game.Components.Add(startScene);

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
            hide(); // 처음에는 화면에 보이지 않도록 숨김
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_spriteFont, $"Game Over\nFinal Score: {finalScore}\nCoins Collected: {PlayerInfo.PlayerCoinScore}", new Vector2(100, 100), Color.White);
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

        // Handles the imput for the easy or hard menu
        private void HandleInput()
        {
            KeyboardState ks = Keyboard.GetState();


            if (ks.IsKeyDown(Keys.Escape))
            {
                this.hide();
                startScene.show();

            }

        }
    }
}
