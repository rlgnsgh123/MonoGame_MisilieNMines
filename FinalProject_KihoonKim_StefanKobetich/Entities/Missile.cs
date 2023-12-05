using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Entities
{
    public class Missile : DrawableGameComponent
    {
        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position;
        private int delay;

        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;

        private int delayCounter;

        private const int ROWS = 3;
        private const int COLS = 1;

        public Vector2 Position { get => position; set => position = value; }

        private Game g;

        public Missile(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, int delay) : base(game)
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

        public override void Update(GameTime gameTime)
        {
            position += new Vector2(-3, 0);

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

            base.Update(gameTime);
        }

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
        public void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }
        public void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
