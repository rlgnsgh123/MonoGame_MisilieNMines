using FinalProject_KihoonKim_StefanKobetich.Entities;
using FinalProject_KihoonKim_StefanKobetich.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    /// <summary>
    /// Highscore scene to display the users highscore after game end
    /// </summary>
    public class HighScoreScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private List<PlayerInfo> highScores;

        // Constructor for highscore
        public HighScoreScene(Game game) : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            spriteFont = game.Content.Load<SpriteFont>("fonts/NormalFont");

            SavingScoreManager.MakingFile();
            LoadAndDisplayHighScores();
        }

        private void LoadAndDisplayHighScores()
        {
            // Load high scores using SavingScoreManager
            highScores = SavingScoreManager.LoadGameScores();
            DisplayHighScores();
        }

        private void DisplayHighScores()
        {
            spriteBatch.Begin();

            // Display header
            spriteBatch.DrawString(spriteFont, "High Scores", new Vector2(100, 50), Color.White);

            // Display each high score entry
            for (int i = 0; i < highScores.Count; i++)
            {
                spriteBatch.DrawString(spriteFont, $"{i + 1}. {highScores[i].PlayerName}: {highScores[i].PlayerScore}", new Vector2(100, 100 + i * 30), Color.White);
            }

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            LoadAndDisplayHighScores();
           
        }
    }
}
