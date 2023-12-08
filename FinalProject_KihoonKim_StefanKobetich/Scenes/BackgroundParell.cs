using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    public class BackgroundParell : DrawableGameComponent
    {
        /// <summary>
        /// Class to support the background of the game
        /// </summary>

        private SpriteBatch sb;
        private Texture2D tex;
        // 우리는 2개의 position이 필요해왜냐하면 두개의 이미지가 이동하면서 계속 보여줘야하니까
        private Vector2 position1, position2;
        // Desistination 내가 
        private Rectangle srcRect;
        private Vector2 speed;

        // Constructor to make the background
        public BackgroundParell(Game game, SpriteBatch sb, Texture2D tex, Vector2 position, Rectangle srcRect, Vector2 speed) : base(game)
        {
            this.sb = sb;
            this.tex = tex;
            this.srcRect = srcRect;

            this.position1 = position;
            this.position2 = new Vector2(position1.X + srcRect.Width, position1.Y);
            this.speed = speed;

        }

        // Updates the speed and position of the animation
        public override void Update(GameTime gameTime)
        {
            position1 -= speed;
            position2 -= speed;

            if (position1.X < -srcRect.Width)
            {
                position1.X = position2.X + srcRect.Width;
            }

            if (position2.X < -srcRect.Width)
            {
                position2.X = position1.X + srcRect.Width;
            }
            base.Update(gameTime);
        }

        // Draws the background to the user
        public override void Draw(GameTime gameTime)
        {
            sb.Begin();

            sb.Draw(tex, position1, srcRect, Color.White);
            sb.Draw(tex, position2, srcRect, Color.White);

            sb.End();
            base.Draw(gameTime);
        }
    }
}
