using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    public class EndScene : GameScene
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;
        private int finalScore;

        public EndScene(Game game, int score) : base(game)
        {
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
            _spriteFont = game.Content.Load<SpriteFont>("fonts/NormalFont");
            finalScore = score;
            hide(); // 처음에는 화면에 보이지 않도록 숨김
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_spriteFont, $"Game Over\nFinal Score: {finalScore}", new Vector2(100, 100), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
