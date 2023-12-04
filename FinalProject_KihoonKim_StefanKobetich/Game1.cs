using FinalProject_KihoonKim_StefanKobetich.Scene;
using FinalProject_KihoonKim_StefanKobetich.Scenes;
using FinalProject_KihoonKim_StefanKobetich.Shared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject_KihoonKim_StefanKobetich
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        // Decare all scenes
        private StartScene startScene;
        private HelpScene helpScene;
        private PlayMenuScene playMenuScene;
        private PlayScene playScene;
        private HighScoreScene highScoreScene;

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
            // Vector2 pos2 = new Vector2(0, stage.Y - srcRect.Height -50);
            BackgroundParell sb1 = new BackgroundParell(this, _spriteBatch, tex, pos1, srcRect, speed1);
            //ScrollingBackground sb2 = new ScrollingBackground(this, _spriteBatch, tex, pos2, srcRect, speed2);
            //this.Components.Add(sb2);
            this.Components.Add(sb1);


            // TODO: use this.Content to load your game content here
            // instantiate all scenes here
            startScene = new StartScene(this);
            this.Components.Add(startScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            playScene = new PlayScene(this);
            this.Components.Add(playScene);


            // make ONLY strart active
            startScene.show();
            //helpScene.show();



        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //   Exit();

            // TODO: Add your update logic here

            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();
                    playScene.show();
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
            if (playScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    playScene.hide();
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