using FinalProject_KihoonKim_StefanKobetich.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich
{
    public class CollisionManager : GameComponent
    {
        private Missile missile;
        private Airplane airplane;
        private MineBomb mineBomb;
        public CollisionManager(Game game, Missile missile, MineBomb mineBomb) : base(game)
        {
            this.mineBomb = mineBomb;
            this.missile = missile;
            //this.airplane = airplane;   
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle missileRect = missile.getBounds();
            //Rectangle airplaneRect = airplane.getBounds();
            Rectangle bombRect = mineBomb.getBounds();

            if (missileRect.Intersects(bombRect))
            {
                // Put code for what happens on an inersection here
                mineBomb.Enabled = false;
                mineBomb.Visible = false;
            }

            base.Update(gameTime);
        }


    }
}
