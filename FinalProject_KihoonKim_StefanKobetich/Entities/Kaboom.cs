using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissilesNMinesEscape.Entities
{
    public class Kaboom : DrawableGameComponent
    {
        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position;
        private int delay;

        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;

        private int delayCounter;

        private const int ROWS = 4;
        private const int COLS = 4;

        public Vector2 Position { get => position; set => position = value; }

        private Game g;

        // Constructor for kaboom, allows for a somewhat customizable explosion(kaboom) 
        public Kaboom(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, int delay) : base(game)
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

        // Hides kaboom
        public void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        // Shows kaboom
        public void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        // Handles any of the updating and animation
        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > ROWS * COLS - 1)
                {
                    frameIndex = -1;
                    Hide();
                    g.Components.Remove(this);
                }

                delayCounter = 0;
            }

            base.Update(gameTime);
        }

        // Draws the kaboom into frame
        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                sb.Begin();
                // Version 4 of the draw function
                sb.Draw(tex, Position, frames[frameIndex], Color.White);
                sb.End();

            }

            base.Draw(gameTime);
        }

    }
}
