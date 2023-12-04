using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_KihoonKim_StefanKobetich.Entities;
using System.Reflection.Metadata;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    public class PlayScene : GameScene
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D tex;
        private Missile missle;

        public PlayScene(Game game) : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
