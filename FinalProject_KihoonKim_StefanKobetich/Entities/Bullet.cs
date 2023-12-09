using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MissilesNMinesEscape.Entities
{
    /// <summary>
    /// Bullet Class that allows the creation of a bullet and handles all bullet logic
    /// </summary>
    public class Bullet : DrawableGameComponent
    {
        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position;
        private int delay;
        private int speed;

        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;

        private int delayCounter;

        private const int ROWS = 1;
        private const int COLS = 3;
        private const int HITBOXSHRINK = 5;

        public Vector2 Position { get => position; set => position = value; }
        private Game g;

        // Constructor for bullet, allows for a somewhat customizable bullet
        public Bullet(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, int delay, int speed) : base(game)
        {
            this.g = game;
            this.sb = sb;
            this.tex = tex;
            this.Position = position;
            this.delay = delay;
            this.speed = speed;
            this.dimension = new Vector2(tex.Width / COLS, tex.Height / ROWS);
            CreateFrames();
            Hide();
        }

        // Method that preps the spritelocation for the bullet
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

        // Handles any of the updating and animation and bullet deleation
        public override void Update(GameTime gameTime)
        {
            position += new Vector2(speed, 0);

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

            if (position.X >= 750)
            {
                Hide();
            }

            base.Update(gameTime);
        }

        // Draws the bullet into frame with all the class variables
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

        // Hides the bullet
        public void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        // Shows the bullet
        public void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        // Method to get the boundry / hitbox of the bullet
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y - HITBOXSHRINK, (int)dimension.X - HITBOXSHRINK * 2, (int)dimension.Y);
        }
    }
}
