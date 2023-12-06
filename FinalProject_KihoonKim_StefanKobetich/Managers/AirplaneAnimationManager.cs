using FinalProject_KihoonKim_StefanKobetich.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Manager
{
    public class AirplaneAnimationManager
    {

        private AirplaneAnimation _airplaneAnimation;

        private float _timer;

        public Vector2 Position { get; set; }

        public AirplaneAnimationManager(AirplaneAnimation airplaneAnimation)
        {
            _airplaneAnimation = airplaneAnimation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rec = new Rectangle(_airplaneAnimation.CurrentFrame*_airplaneAnimation.FrameWidth,0,_airplaneAnimation.FrameWidth,_airplaneAnimation.FrameHeight);
            spriteBatch.Draw(_airplaneAnimation.Texture, Position, rec, Color.White);
                            
        }


        public void Play(AirplaneAnimation airplaneAnimation)
        {
            if (_airplaneAnimation == airplaneAnimation)
            {
                return;
            }

            _airplaneAnimation = airplaneAnimation;
            _airplaneAnimation.CurrentFrame = 0;
            _timer = 0;
        }

        public void Stop()
        {
            _timer = 0f;
            _airplaneAnimation.CurrentFrame =0;
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _airplaneAnimation.FrameSpeed)
            {
                _timer = 0f;
                _airplaneAnimation.CurrentFrame++;

                if (_airplaneAnimation.CurrentFrame >= _airplaneAnimation.FrameCount)
                {
                    _airplaneAnimation.CurrentFrame = 0;
                }
            }
        }
    }
}
