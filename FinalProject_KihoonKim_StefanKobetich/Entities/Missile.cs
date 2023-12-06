using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FinalProject_KihoonKim_StefanKobetich.Entities
{
    /// <summary>
    /// Missile Class that allows the creation of a missle and handles all missile logic
    /// </summary>
    public class Missile : DrawableGameComponent
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

        private const int ROWS = 3;
        private const int COLS = 1;

        public Vector2 Position { get => position; set => position = value; }
        private Game g;

        // Constructor for missile, allows for a somewhat customizable missile
        public Missile(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, int delay, int speed) : base(game)
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

        // Method that preps the spritelocation for the missile
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

        // Hides the missile
        public void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        // Shows the missile
        public void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        // Method to get the boundry / hitbox of the missile
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
