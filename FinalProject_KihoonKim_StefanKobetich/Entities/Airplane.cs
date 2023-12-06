
using FinalProject_KihoonKim_StefanKobetich.Shared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject_KihoonKim_StefanKobetich.Entities
{
    public class Airplane : DrawableGameComponent
    {

        private SpriteBatch sb;
        private Texture2D tex;

        private Vector2 position;
        private int delay;

        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;
        private int delayCounter;

        private const int ROWS = 1;
        private const int COLS = 8;

        private Vector2 xSpeed;
        private Vector2 ySpeed;
        private Vector2 stage;


        public Vector2 Position { get; set; }

        public Airplane(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, Vector2 xSpeed, Vector2 ySpeed, Vector2 stage, int delay) : base(game)
        {
            this.sb = sb;
            this.tex = tex;
            this.position = position;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
            this.stage = stage;
            this.delay = delay;
            this.dimension = new Vector2(tex.Width / COLS, tex.Height / ROWS);
            CreateFrames();
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
            KeyboardState ks = Keyboard.GetState();

            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                // 만약에 이게 인덱스를 넘어가면 -1로 만들고 안되게하라
                if (frameIndex > ROWS * COLS - 1)
                {
                    frameIndex = 0;
                }


                delayCounter = 0;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                position -= xSpeed;
                if (position.X < 0)
                {
                    position.X = 0;
                }
                if (position.X > stage.X - tex.Width)
                {
                    position.X = stage.X - tex.Width;
                }
                if (position.X > SharingComponent.stage.X - frames[frameIndex].Width)
                {
                    position.X = SharingComponent.stage.X - frames[frameIndex].Width;
                }
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                position += xSpeed;
                if (position.X > stage.X - tex.Width)
                {
                    position.X = stage.X - tex.Width;
                }
                if (position.X > SharingComponent.stage.X - frames[frameIndex].Width)
                {
                    position.X = SharingComponent.stage.X - frames[frameIndex].Width;
                }
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                position -= ySpeed;
                if (position.Y < 0)
                {
                    position.Y = 0;
                }

                if (position.Y > SharingComponent.stage.Y - frames[frameIndex].Height)
                {
                    position.Y = SharingComponent.stage.Y - frames[frameIndex].Height;
                }
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                position += ySpeed;
                if (position.Y > stage.Y - tex.Height)
                {
                    position.Y = stage.Y - tex.Height;
                }
                if (position.Y > SharingComponent.stage.Y - frames[frameIndex].Height)
                {
                    position.Y = SharingComponent.stage.Y - frames[frameIndex].Height;
                }
            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {

            if (frameIndex >= 0)
            {
                sb.Begin();
                // version 4
                sb.Draw(tex, position, frames[frameIndex], Color.White);
                sb.End();
            }
            base.Draw(gameTime);
        }
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}