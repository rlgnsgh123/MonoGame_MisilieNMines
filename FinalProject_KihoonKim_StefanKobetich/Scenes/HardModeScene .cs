using FinalProject_KihoonKim_StefanKobetich.Entities;
using FinalProject_KihoonKim_StefanKobetich.Shared;
using FinalProject_KihoonKim_StefanKobetich.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
    public class HardModeScene : GameScene
    {
        private Game g;
        private CollisionManager _collisionManager;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont spriteFont;
        private Texture2D missileTex;
        private Texture2D groundBombTex;
        private Texture2D airBombTex;
        private Texture2D coinTex;
        private Texture2D bombTex;
        private Texture2D airplaneTex;
        private Texture2D airplaneTex1;
        private Texture2D heliTex;
        private Missile missile;
        private Helli helli;
        private MineBomb mineBomb;
        private Coin coin;
        private Airplane airplane;
        private SoundEffect nearMiss;
        private SoundEffect coinCollectSound;
        private EndScene endScene;
        private List<AirplaneSprite> _airplaneSprites;
        private List<Missile> missileList;
        private List<MineBomb> mineBombList;
        private List<Coin> coinList;
        private List<Helli> helliList;
        private int coinListCount = 0;
        private int coinSoundCount = 0;
        private int score = 0;
        private int coinPos = 800;
        private int airMinePos = 650;
        private int groundMinePos = 650;
        private int missilePos = 1150;
        private int airMineCount = 24;
        private int groundMineCount = 35;
        private int missileCount = 27;
        private const int coinAmount = 50;
        private float scoreUpdateInterval = 0.05f;
        private float scoreTimer = 0.0f;
        private bool passed = false;
        public bool isGameDone = false;


        // Constructor to load the game materials
        public HardModeScene(Game game) : base(game)
        {
            g = game;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            coinCollectSound = g.Content.Load<SoundEffect>("audio/coinCollect");
            KeyboardState ks = Keyboard.GetState();
            Vector2 stage = new Vector2(SharingComponent.stage.X, SharingComponent.stage.Y);

            // Addition of airplane
            //Texture2D airplaneTex = game.Content.Load<Texture2D>("images/AirPlane1");
            Texture2D airplaneTex = game.Content.Load<Texture2D>("images/Airplane");
            Vector2 airplaneInitPos = new Vector2(200, 200);
            Vector2 airplaneXSpeed = new Vector2(6, 0);
            Vector2 airplaneYSpeed = new Vector2(0, 6);

            //airplane = new Airplane(game, _spriteBatch, airplaneTex, airplaneInitPos, airplaneXSpeed, airplaneYSpeed, stage);
            //this.Components.Add(airplane);
            airplane = new Airplane(game, _spriteBatch, airplaneTex, airplaneInitPos, airplaneXSpeed, airplaneYSpeed, stage, 3);
            this.Components.Add(airplane);

            // Addition of Missile
            for (int i = 0; i < missileCount; i++)
            {
                int randomPosAway = RandomNumberGenerator.GetInt32(375, 700);
                int randomPosHigh = RandomNumberGenerator.GetInt32(20, 400);
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
                int randomPosAway = RandomNumberGenerator.GetInt32(250, 375);
                int randomPosHigh = RandomNumberGenerator.GetInt32(5, 200);

                airMinePos = airMinePos + randomPosAway;
                airBombTex = game.Content.Load<Texture2D>("images/floatingMineBomb");
                mineBomb = new MineBomb(game, _spriteBatch, airBombTex, new Vector2(airMinePos, randomPosHigh), 10);
                this.Components.Add(mineBomb);
                mineBomb.Show();
            }

            // Addition of coins
            for (int i = 0; i < coinAmount; i++)
            {
                int randomPosAway = RandomNumberGenerator.GetInt32(50, 400);
                int randomPosHigh = RandomNumberGenerator.GetInt32(50, 150);

                coinPos = coinPos + randomPosAway;
                coinTex = game.Content.Load<Texture2D>("images/coin");
                coin = new Coin(game, _spriteBatch, coinTex, new Vector2(coinPos, randomPosHigh), 8);
                this.Components.Add(coin);
                coin.Show();
            }

            // Addition of MineBomb ground
            for (int i = 0; i < groundMineCount; i++)
            {
                int randomPosAway = RandomNumberGenerator.GetInt32(275, 400);
                int randomPosHigh = RandomNumberGenerator.GetInt32(210, 345);

                groundMinePos = groundMinePos + randomPosAway;
                groundBombTex = game.Content.Load<Texture2D>("images/mineBombGroundHigh");
                mineBomb = new MineBomb(game, _spriteBatch, groundBombTex, new Vector2(groundMinePos, randomPosHigh), 10);
                this.Components.Add(mineBomb);
                mineBomb.Show();
            }

            missileList = this.Components.OfType<Missile>().ToList();
            mineBombList = this.Components.OfType<MineBomb>().ToList();
            coinList = this.Components.OfType<Coin>().ToList();
            helliList = this.Components.OfType<Helli>().ToList();

            _collisionManager = new CollisionManager(g, missileList, mineBombList, helliList, coinList, mineBomb, airplane, this, helli); // 수정된 부분
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
            if (score == 1500)
            {
                passed = true;
                EndGame();
            }

            coinList = this.Components.OfType<Coin>().ToList();
            foreach (Coin coin in coinList)
            {
                if (coin.Enabled == false)
                {
                    coinListCount++;
                }
            }
            if (coinListCount != coinSoundCount)
            {
                coinSoundCount++;
                coinCollectSound.Play();
            }
            coinListCount = 0;

            double time = gameTime.ElapsedGameTime.TotalSeconds;

            if (time == 0.02)
            {
                heliTex = g.Content.Load<Texture2D>("images/heli");
                helli = new Helli(g, _spriteBatch, heliTex, new Vector2(50, 75), 5);
                this.Components.Add(helli);
                helli.Show();
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
            coinList = this.Components.OfType<Coin>().ToList();
            foreach (Coin coin in coinList)
            {
                if (coin.Enabled == false)
                {
                    coinListCount++;
                }
            }
            PlayerInfo.PlayerCoinScore = coinListCount;
            Rectangle airplaneBox = airplane.getBounds();
            int x = airplaneBox.X;
            int y = airplaneBox.Y;
            isGameDone = true;
            // 게임이 종료되면 EndScene을 보여줄 수 있습니다.
            EndScene endScene = new EndScene(g, score, new Vector2(x, y), passed);
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