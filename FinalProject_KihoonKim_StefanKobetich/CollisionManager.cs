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
        private Game game;
        private EasyModeScene easyModeScene { get; set; }
        private List<Missile> missileList;
        private List<MineBomb> mineBombList;
        private Airplane airplane;
        private MineBomb mineBomb;
        private GameScene gameScene;

        public CollisionManager(Game game, List<Missile> missileList, List<MineBomb> mineBombList, MineBomb mineBomb, Airplane airplane, GameScene gameScene) : base(game)
        {
            this.game = game;
            this.airplane = airplane;
            this.mineBomb = mineBomb;
            this.missileList = missileList;
            this.mineBombList = mineBombList;
            this.gameScene = gameScene;
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
                    HandleCollision();
                    break;
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
                    HandleCollision();
                    break;
                }
            }




            base.Update(gameTime);
        }
        private void HandleCollision()
        {
            // 게임 모드에 따른 처리를 수행합니다.
            if (gameScene is EasyModeScene)
            {
                EasyModeScene easyModeScene = (EasyModeScene)gameScene;
                easyModeScene.EndGame();
            }
            else if (gameScene is HardModeScene)
            {
                HardModeScene hardModeScene = (HardModeScene)gameScene;
                // Hard Mode에서의 처리 추가
                // 예: hardModeScene.EndGame();
            }



        }
    }
}