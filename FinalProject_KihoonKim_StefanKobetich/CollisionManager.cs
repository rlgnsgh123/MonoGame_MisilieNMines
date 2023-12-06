using FinalProject_KihoonKim_StefanKobetich.Entities;
using FinalProject_KihoonKim_StefanKobetich.Scenes;
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
        private EasyModeScene easyModeScene {  get; set; }
        private Missile missile;
        private Airplane airplane;
        private MineBomb mineBomb;
        public CollisionManager(Game game, Missile missile, MineBomb mineBomb, Airplane airplane) : base(game)
        {
            this.airplane = airplane;
            this.mineBomb = mineBomb;
            this.missile = missile;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle missileRect = missile.getBounds();
            Rectangle airplaneRect = airplane.getBounds();
            Rectangle bombRect = mineBomb.getBounds();



            if (airplaneRect.Intersects(missileRect))
            {
                // Put code for what happens on an inersection here
                airplane.Visible = false;
                airplane.Enabled = false;
            }

            base.Update(gameTime);
        }


    }
}
