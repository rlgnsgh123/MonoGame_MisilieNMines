
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
        private Vector2 xSpeed;
        private Vector2 ySpeed;
        private Vector2 stage;

        public Airplane(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, Vector2 xSpeed, Vector2 ySpeed, Vector2 stage) : base(game)
        {
            this.sb = sb;
            this.tex = tex;
            this.position = position;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
            this.stage = stage;
        }


        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();



            if (ks.IsKeyDown(Keys.Left))
            {
                position -= xSpeed;
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                position += xSpeed;
                if (position.X > stage.X - tex.Width)
                {
                    position.X = stage.X - tex.Width;
                }
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                position -= ySpeed;
                if (position.Y < 0)
                {
                    position.Y = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                position += ySpeed;
                if (position.Y > stage.Y - tex.Height)
                {
                    position.Y = stage.Y - tex.Height;
                }
            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {

            sb.Begin();
            sb.Draw(tex, position, Color.White);
            sb.End();

            base.Draw(gameTime);
        }
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
