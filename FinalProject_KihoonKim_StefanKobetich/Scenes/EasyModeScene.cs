using FinalProject_KihoonKim_StefanKobetich.Entities;
using FinalProject_KihoonKim_StefanKobetich.Shared;
using FinalProject_KihoonKim_StefanKobetich.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    /// <summary>
    /// Easy gamemode game class: The class that houses the easy version of the game
    /// </summary>
    public class EasyModeScene : GameScene
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D missileTex;
        private Texture2D groundBombTex;
        private Texture2D airBombTex;
        private Missile missile;
        private MineBomb mineBomb;
        private Airplane airplane;
        private Texture2D bombTex;
        private Texture2D airplaneTex;
        private Texture2D airplaneTex1;
        private Game g;
        private SoundEffect nearMiss;
        private SpriteFont spriteFont;

        private int score = 0;
        private float scoreUpdateInterval = 0.05f;
        private float scoreTimer = 0.0f;
        public bool isGameDone = false;

        private EndScene endScene;

        private CollisionManager _collisionManager;
        private List<AirplaneSprite> _airplaneSprites;

        // Constructor to load the game materials
        public EasyModeScene(Game game) : base(game)
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            g = game;

            KeyboardState ks = Keyboard.GetState();

            Vector2 stage = new Vector2(SharingComponent.stage.X,
                SharingComponent.stage.Y);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            nearMiss = game.Content.Load<SoundEffect>("audio/whoosh");

            // Addition of airplane
            //Texture2D airplaneTex = game.Content.Load<Texture2D>("images/AirPlane1");
            Texture2D airplaneTex = game.Content.Load<Texture2D>("images/Airplane");
            Vector2 airplaneInitPos = new Vector2(70, 200);
            Vector2 airplaneXSpeed = new Vector2(6, 0);
            Vector2 airplaneYSpeed = new Vector2(0, 6);

            //airplane = new Airplane(game, _spriteBatch, airplaneTex, airplaneInitPos, airplaneXSpeed, airplaneYSpeed, stage);
            //this.Components.Add(airplane);
            airplane = new Airplane(game, _spriteBatch, airplaneTex, airplaneInitPos, airplaneXSpeed, airplaneYSpeed, stage, 3);
            this.Components.Add(airplane);

          

            int airMinePos = 800;
            int groundMinePos = 700;
            int missilePos = 1200;
            int airMineCount = 20;
            int groundMineCount = 20;
            int missileCount = 20;

            // Addition of Missile
            for (int i = 0; i < missileCount; i++)
            {
                int randomPosAway = RandomNumberGenerator.GetInt32(250, 775);
                int randomPosHigh = RandomNumberGenerator.GetInt32(25, 400);
                int randomSpeed = RandomNumberGenerator.GetInt32(-5, -2);

                missilePos = missilePos + randomPosAway;
                if (randomSpeed == -3 || randomSpeed == -2)
                {
                    missileTex = game.Content.Load<Texture2D>("images/smallMissile");
                }
                else
                {
                    missileTex = game.Content.Load<Texture2D>("images/MissileFire");
                }
                missile = new Missile(game, _spriteBatch, missileTex, new Vector2(missilePos, randomPosHigh), 5, randomSpeed);
                this.Components.Add(missile);
                missile.Show();
            }

            // Addition of MineBomb air
            for (int i = 0; i < airMineCount; i++)
            {
                int randomPosAway = RandomNumberGenerator.GetInt32(200, 350);
                int randomPosHigh = RandomNumberGenerator.GetInt32(5, 200);

                airMinePos = airMinePos + randomPosAway;
                airBombTex = game.Content.Load<Texture2D>("images/floatingMineBomb");
                mineBomb = new MineBomb(game, _spriteBatch, airBombTex, new Vector2(airMinePos, randomPosHigh), 10);
                this.Components.Add(mineBomb);
                mineBomb.Show();
            }

            // Addition of MineBomb ground
            for (int i = 0; i < groundMineCount; i++)
            {
                int randomPosAway = RandomNumberGenerator.GetInt32(250, 400);
                int randomPosHigh = RandomNumberGenerator.GetInt32(210, 375);

                groundMinePos = groundMinePos + randomPosAway;
                groundBombTex = game.Content.Load<Texture2D>("images/mineBombGroundHigh");
                mineBomb = new MineBomb(game, _spriteBatch, groundBombTex, new Vector2(groundMinePos, randomPosHigh), 10);
                this.Components.Add(mineBomb);
                mineBomb.Show();
            }

            List<Missile> missileList = this.Components.OfType<Missile>().ToList();
            List<MineBomb> mineBombList = this.Components.OfType<MineBomb>().ToList();

            _collisionManager = new CollisionManager(g, missileList, mineBombList, mineBomb, airplane, this); // 수정된 부분
            this.Components.Add(_collisionManager);
        }

        // Controls what makes the game objects appear
        public override void Update(GameTime gameTime)
        {
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            UpdateScore(elapsedSeconds);
            // TODO: Add your update logic here
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                g.Exit();
            }
            if (isGameDone)
            {
                EndGame();
                return;
            }



            base.Update(gameTime);
        }

        private void UpdateScore(float elapsedSeconds)
        {
            scoreTimer += elapsedSeconds;

            if (scoreTimer >= scoreUpdateInterval)
            {
                // 경과 시간 누적
                score += 1;

                // initialize scoreTimertimer
                scoreTimer = 0.0f;

            }
        }

        private void DrawScore()
        {
            spriteFont = g.Content.Load<SpriteFont>("fonts/NormalFont");
            _spriteBatch.Begin();
            _spriteBatch.DrawString(spriteFont, "Score: " + score, new Vector2(10, 10), Color.White);
            _spriteBatch.End();
        }

        public void EndGame()
        {
            Rectangle airplaneBox = airplane.getBounds();
            int x = airplaneBox.X;
            int y = airplaneBox.Y;
            isGameDone = true;
            // 게임이 종료되면 EndScene을 보여줄 수 있습니다.
            EndScene endScene = new EndScene(g, score, new Vector2(x, y));
            Game.Components.Add(endScene);
            endScene.show();
            Game.Components.Remove(this);
        }

        // Allows the game to be drawn to the user
        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            DrawScore();
            base.Draw(gameTime);
        }
    }
}