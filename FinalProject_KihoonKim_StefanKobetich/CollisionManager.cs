using FinalProject_KihoonKim_StefanKobetich.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich
{
    public class CollisionManager : GameComponent
    {
        private Missile missile;
        private Airplane airplane;
        public CollisionManager(Game game, Missile missile, Airplane airplane) : base(game)
        {
            this.missile = missile;
            this.airplane = airplane;   
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle missileRect = missile.getBounds();
            Rectangle airplaneRect = airplane.getBounds();

            if (airplaneRect.Intersects(missileRect))
            {
                // Put code for what happens on an inersection here

            }

            base.Update(gameTime);
        }


    }
}
