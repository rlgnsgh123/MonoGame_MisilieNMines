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
        private List<Missile> missileList;
        private List<MineBomb> mineBombList;
        private Airplane airplane;
        private MineBomb mineBomb;
        public CollisionManager(Game game, List<Missile> missileList, List<MineBomb> mineBombList, MineBomb mineBomb, Airplane airplane) : base(game)
        {
            this.airplane = airplane;
            this.mineBomb = mineBomb;
            this.missileList = missileList;
            this.mineBombList = mineBombList;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle missileRect = new Rectangle();
            Rectangle bombRect = new Rectangle();
            Rectangle airplaneRect = airplane.getBounds();

            foreach (Missile m in missileList)
            {
                missileRect = m.getBounds();
                if (airplaneRect.Intersects(missileRect))
                {
                    // Put code for what happens on an inersection here
                    airplane.Visible = false;
                    airplane.Enabled = false;
                }
            }
            foreach (MineBomb b in mineBombList)
            {
                bombRect = b.getBounds();
                if (airplaneRect.Intersects(bombRect))
                {
                    // Put code for what happens on an inersection here
                    airplane.Visible = false;
                    airplane.Enabled = false;
                }
            }




            base.Update(gameTime);
        }


    }
}
