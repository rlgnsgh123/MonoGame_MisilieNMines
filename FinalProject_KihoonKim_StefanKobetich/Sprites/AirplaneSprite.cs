using FinalProject_KihoonKim_StefanKobetich.Manager;
using FinalProject_KihoonKim_StefanKobetich.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Sprites
{
    public class AirplaneSprite
    {
        protected AirplaneAnimationManager _airplaneAnimationManager;

        protected Dictionary<string, AirplaneAnimation> _airplaneAnimation;

        protected Vector2 _position;

        protected Texture2D _texture;
        public AirplaneInput Input;
        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value; if (_airplaneAnimationManager != null)
                {
                    _airplaneAnimationManager.Position = _position;
                } 
            } 
        }
                                                               
        public float Speed = 1f;
        public Vector2 Velocity;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
            {
                spriteBatch.Draw(_texture, Position, Color.White);
            }
            else if (_airplaneAnimationManager !=null) {
                _airplaneAnimationManager.Draw(spriteBatch);
            }
           
        }

        public virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = -Speed;
            }
        }

        public AirplaneSprite(Dictionary<string, AirplaneAnimation> airplaneAnimations)
        {
            _airplaneAnimation = airplaneAnimations;
            _airplaneAnimationManager = new AirplaneAnimationManager(_airplaneAnimation.First().Value);
        }

        public AirplaneSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<AirplaneSprite> sprites)
        {
            Move();

            if (Velocity.X > 0)
            {
                _airplaneAnimationManager.Play(_airplaneAnimation["AirPlane"]);
            }
            else if (Velocity.X < 0)
            {
                _airplaneAnimationManager.Play(_airplaneAnimation["AirPlane"]);
            }
            else if (Velocity.Y > 0)
            {
                _airplaneAnimationManager.Play(_airplaneAnimation["AirPlane"]);
            }
            else if (Velocity.Y < 0)
            {
                _airplaneAnimationManager.Play(_airplaneAnimation["AirPlane"]);
            }

            _airplaneAnimationManager.Update(gameTime);
            Position += Velocity;
            Velocity = Vector2.Zero;

        }
    }
}
