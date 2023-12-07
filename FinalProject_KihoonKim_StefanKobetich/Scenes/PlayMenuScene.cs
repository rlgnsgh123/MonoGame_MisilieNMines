using FinalProject_KihoonKim_StefanKobetich.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System.IO;



namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    /// <summary>
    /// Menu that is brought up after selecting to play a game
    /// </summary>
    public class PlayMenuScene : GameScene
    {
        bool isFirst = true;
        EasyModeScene easyModeScene;
        HardModeScene hardModeScene;
        private Game g = new Game();

        private MenuComponent menu;
        public MenuComponent Menu { get => menu; set => menu = value; }

        private SpriteBatch _spriteBatch;
        SpriteFont normalFont;

        // Loads the selection screen for if the user wants hard mode or easy mode
        public PlayMenuScene(Game game) : base(game)
        {
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
           
            easyModeScene = new EasyModeScene(game);
            game.Components.Add(easyModeScene);
           
            hardModeScene = new HardModeScene(game);
            game.Components.Add(hardModeScene);
            

            Game1 g = (Game1)game;
            normalFont = game.Content.Load<SpriteFont>("fonts/NormalFont");
            SpriteFont selectedFont = game.Content.Load<SpriteFont>("fonts/SelectedFont");
            string[] menuItems = { "EasyMode","HardMode" };
            Menu = new MenuComponent(g, g._spriteBatch, normalFont, selectedFont, menuItems,"PlayMenu");
            this.Components.Add(Menu);
        }

        // Handles updating the users mouse
        public override void Update(GameTime gameTime)
        {

            if (this.Enabled)
            {
                HandleInput();
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(normalFont, $"To choose game mode, please click space", new Vector2(100, 100), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        // Handles the imput for the easy or hard menu
        private void HandleInput()
        {
            int selectedIndex = -1;
            KeyboardState ks = Keyboard.GetState();

            
             
            selectedIndex = Menu.SelectedIndex;

            
            if (selectedIndex == 0 && ks.IsKeyDown(Keys.Space))
            {
                this.hide();
                easyModeScene.show();

                Song backgroundMusic = g.Content.Load<Song>("audio/daftyMusic");
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(backgroundMusic);
            }
            else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Space))
            {
                this.hide();
                hardModeScene.show();
            }

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