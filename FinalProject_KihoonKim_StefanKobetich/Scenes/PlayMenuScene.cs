using FinalProject_KihoonKim_StefanKobetich.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.IO;



namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    /// <summary>
    /// Menu that is brought up after selecting to play a game
    /// </summary>
    public class PlayMenuScene : GameScene
    {
        private bool isKeyInputHandled = false;

        private SpriteBatch spriteBatch; 

        private Button easyModeButton;
        private Button hardModeButton;
        private MouseState previousMouseState;

        // Loads the selection screen for if the user wants hard mode or easy mode
        public PlayMenuScene(Game game) : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            previousMouseState = Mouse.GetState();


            SpriteFont spriteFont = game.Content.Load<SpriteFont>("fonts/NormalFont");

            easyModeButton = new Button(new Vector2(160, 230), "Easy Mode", Color.SkyBlue, Color.AliceBlue, spriteFont, GraphicsDevice);
            hardModeButton = new Button(new Vector2(450, 230), "Hard Mode", Color.SkyBlue, Color.AliceBlue, spriteFont, GraphicsDevice);
        }

        // Handles updating the users mouse
        public override void Update(GameTime gameTime)
        {
            HandleInput();
            previousMouseState = Mouse.GetState();
            base.Update(gameTime);
        }

        // Draws the easy or hard menu to the user, with input for the name
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            // Draw background or other elements

            easyModeButton.Draw(spriteBatch);
            hardModeButton.Draw(spriteBatch);

            // Draw user name input
            spriteBatch.DrawString(
                Game.Content.Load<SpriteFont>("fonts/NormalFont"), $"Player Name: {PlayerInfo.PlayerName}", new Vector2(170, 130), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Handles the imput for the easy or hard menu
        private void HandleInput()
        {

            if (easyModeButton.IsClicked(Mouse.GetState().Position))
            {
                StartGame("Easy");
            }
            else if (hardModeButton.IsClicked(Mouse.GetState().Position))
            {
                StartGame("Hard");
            }

            // 키보드 입력 처리
            KeyboardState keyboardState = Keyboard.GetState();

            // 키 입력이 감지되고, 아직 키 입력이 처리되지 않은 경우
            if (keyboardState.GetPressedKeys().Length > 0 && !isKeyInputHandled)
            {
                foreach (Keys key in keyboardState.GetPressedKeys())
                {
                    // 키 입력 처리
                    if ((key >= Keys.A && key <= Keys.Z) || (key >= Keys.D0 && key <= Keys.D9))
                    {
                        PlayerInfo.PlayerName += key.ToString();
                    }
                    else if (key == Keys.Back && PlayerInfo.PlayerName.Length > 0)
                    {
                        PlayerInfo.PlayerName = PlayerInfo.PlayerName.Substring(0, PlayerInfo.PlayerName.Length - 1);
                    }
                }

                // 키 입력이 처리되었음을 표시
                isKeyInputHandled = true;
            }
            else if (keyboardState.GetPressedKeys().Length == 0)
            {
                // 키가 떼어진 경우 처리되지 않은 상태로 변경
                isKeyInputHandled = false;
            }

            // 엔터 키로 게임 시작
            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                StartGame(PlayerInfo.GameMode);
            }
        
        }

        // After the user selects witch game version they want, this function loads it
        private void StartGame(string gameMode)
        {
            PlayerInfo.PlayerScore = 0;
            PlayerInfo.GameMode = gameMode;

            // 기존 코드에서 PlayScene으로 바로 전환하던 부분을 수정
            // 게임 모드에 따라서 EasyModeScene 또는 HardModeScene으로 전환
            if (gameMode == "Easy")
            {
                // Easy Mode로 전환
                Game.Components.Remove(this);
                EasyModeScene easyModeScene = new EasyModeScene(Game);
                Game.Components.Add(easyModeScene);
                easyModeScene.show();
            }
            else if (gameMode == "Hard")
            {
                // Hard Mode로 전환
                Game.Components.Remove(this);
                HardModeScene hardModeScene = new HardModeScene(Game);
                Game.Components.Add(hardModeScene);
                hardModeScene.show();
            }
        }

        // Method to see if easy mode is selected
        public bool IsEasyModeSelected()
        {
            return easyModeButton.IsClicked(Mouse.GetState().Position);
        }

        // Method to see if hard mode is selected
        public bool IsHardModeSelected()
        {
            return hardModeButton.IsClicked(Mouse.GetState().Position);
        }
    }
}

//public void EndGame()
//{
//    SaveScoreToFile(PlayerInfo.PlayerName, PlayerInfo.PlayerScore);
//}

//private void SaveScoreToFile(string playerName, int score)
//{
//    string filePath = "scores.txt";
//    using (StreamWriter writer = new StreamWriter(filePath, true))
//    {
//        writer.WriteLine($"{playerName}: {score}");
//    }
//}