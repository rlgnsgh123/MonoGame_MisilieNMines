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

        

        private MenuComponent menu;
        public MenuComponent Menu { get => menu; set => menu = value; }

        private SpriteBatch _spriteBatch;
        private Texture2D image;
        SpriteFont normalFont;

        Game1 g;


        // Loads the selection screen for if the user wants hard mode or easy mode
        public PlayMenuScene(Game game) : base(game)
        {
            g = (Game1)game;
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);

            image = g.Content.Load<Texture2D>("Intro");

            easyModeScene = new EasyModeScene(g);
            game.Components.Add(easyModeScene);
           
            hardModeScene = new HardModeScene(g);
            g.Components.Add(hardModeScene);
            

            g = (Game1)game;
            normalFont = game.Content.Load<SpriteFont>("fonts/ExpainFont");
            SpriteFont modelNormalFont = g.Content.Load<SpriteFont>("fonts/GameModeNormalFont");
            SpriteFont modeSelectedFont = g.Content.Load<SpriteFont>("fonts/GameModeSelectedFont");
            string[] menuItems = { "Easy Mode","Hard Mode" };
            Menu = new MenuComponent(g, g._spriteBatch, modelNormalFont, modeSelectedFont, menuItems,"PlayMenu");
            this.Components.Add(Menu);
        }

        // Handles updating the users mouse
        public override void Update(GameTime gameTime)
        {
            if (easyModeScene!=null)
            {
                easyModeScene = new EasyModeScene(g);
                Game.Components.Add(easyModeScene);
            }
            else if (hardModeScene != null)
            {
                hardModeScene = new HardModeScene(g);
                Game.Components.Add(hardModeScene);
            }
            if (this.Enabled)
            {
                HandleInput();
                base.Update(gameTime);
            }
        }

        // Draws the play menu to the user
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            string info = "Please click space to choose Game Mode";
            _spriteBatch.DrawString(normalFont,info, new Vector2(50, 50), Color.Black);
            _spriteBatch.Draw(image, new Vector2(45, 130), Color.White);
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
                PlayMusic();

            }
            else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Space))
            {
                this.hide();
                hardModeScene.show();
                PlayMusic();

            }

        }
        
        // Method for playing the game music when loading into a level
        public void PlayMusic()
        {
            Song backgroundMusic = g.Content.Load<Song>("audio/daftyMusic");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
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