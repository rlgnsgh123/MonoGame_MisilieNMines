﻿
using FinalProject_KihoonKim_StefanKobetich.Scenes;
using FinalProject_KihoonKim_StefanKobetich.Shared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace FinalProject_KihoonKim_StefanKobetich
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        // Decare all scenes
        private StartScene startScene;
        private HelpScene helpScene;
        private PlayMenuScene playMenuScene;
        private HardModeScene hardModeScene;
        private EasyModeScene easyModeScene;
        private HighScoreScene highScoreScene;
        
        private string playerName;
        private int score;
        private GameTime gameTime;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // stage가 static여서 이렇게 불러오고 preffered로 하면된다.

            SharingComponent.stage = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Vector2 stage = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Texture2D tex = this.Content.Load<Texture2D>("images/background");
            Vector2 speed1 = new Vector2(2, 0);
            Rectangle srcRect = new Rectangle(0, 0, tex.Width, tex.Height);
            Vector2 pos1 = new Vector2(0, stage.Y - srcRect.Height);
            BackgroundParell sb1 = new BackgroundParell(this, _spriteBatch, tex, pos1, srcRect, speed1);
            this.Components.Add(sb1);


            // TODO: use this.Content to load your game content here
            // instantiate all scenes here
            startScene = new StartScene(this);
            this.Components.Add(startScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            playMenuScene = new PlayMenuScene(this);
            this.Components.Add(playMenuScene);

            easyModeScene = new EasyModeScene(this);
            this.Components.Add(easyModeScene);


            startScene.show();

        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here

            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();
                    playMenuScene.show();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();
                    helpScene.show();
                }
                else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }
            if (playMenuScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    playMenuScene.hide();
                    startScene.show();
                }

            }

            if (helpScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    helpScene.hide();
                    startScene.show();
                }

            }

            if (playMenuScene.Enabled && playMenuScene.IsEasyModeSelected())
            {
                playMenuScene.hide();             
                easyModeScene.show();
            }
            else if (playMenuScene.Enabled && playMenuScene.IsHardModeSelected())
            {
                playMenuScene.hide();
                hardModeScene.show();
            }


            // same way other scenes

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}