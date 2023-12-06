using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Models
{
    public class AirplaneAnimation
    {

        public int CurrentFrame { get; set; }

        public int FrameCount { get; set; }

        public int FrameHeight { get { return Texture.Height; } }

        public int FrameWidth { get {return Texture.Width/FrameCount; } }

        public float FrameSpeed { get; set; }

        public bool IsLooping { get; set; }

        public Texture2D Texture { get; set; }

        public AirplaneAnimation(Texture2D texture, int frameCount) 
        {
            Texture = texture;
            FrameCount = frameCount;
            IsLooping = true;
            FrameSpeed = 0.2f;
        }
    }
}
