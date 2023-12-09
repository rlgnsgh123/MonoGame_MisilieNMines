﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics; 
using System.Threading.Tasks;

namespace MissilesNMinesEscape.Entities
{
    /// <summary>
    /// Coin Class that allows the creation of collectable Coins and handles all Coin logic
    /// </summary>
    public class Coin : DrawableGameComponent
    {
        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position;
        private int delay;

        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;

        private int delayCounter;

        private const int ROWS = 2;
        private const int COLS = 5;

        public Vector2 Position { get => position; set => position = value; }

        private Game g;

        // Constructor for MineBomb, allows for a somewhat customizable MineBomb
        public Coin(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, int delay) : base(game)
        {
            this.g = game;
            this.sb = sb;
            this.tex = tex;
            this.Position = position;
            this.delay = delay;
            this.dimension = new Vector2(tex.Width / COLS, tex.Height / ROWS);
            CreateFrames();
            Hide();
        }
        // Method that preps the spritelocation for the MineBomb
        private void CreateFrames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    frames.Add(r);
                }
            }
        }

        // Handles any of the updating and animation
        public override void Update(GameTime gameTime)
        {
            position += new Vector2(-2, 0);

            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex == ROWS * COLS)
                {
                    frameIndex = 1;
                }
                if (frameIndex > ROWS * COLS - 1)
                {
                    frameIndex = -1;
                }

                delayCounter = 0;
            }

            if (position.X <= -100)
            {
                Hide();
            }

            base.Update(gameTime);
        }

        // Draws the missile into frame with all the class variables
        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                sb.Begin();
                sb.Draw(tex, Position, frames[frameIndex], Color.White);
                sb.End();
            }

            base.Draw(gameTime);
        }

        // Hides the MineBomb
        public void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        // Shows the MineBomb
        public void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        // Method to get the boundry / hitbox of the MineBomb
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y);
        }
    }
}
