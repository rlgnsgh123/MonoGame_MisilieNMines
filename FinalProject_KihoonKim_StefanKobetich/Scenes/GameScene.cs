using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Scenes
{
    public abstract class GameScene : DrawableGameComponent
    {
       /// <summary>
       /// Kihoon comment this class please ****************************************************************************************
       /// </summary>
        public List<GameComponent> Components { get; set; }
        public virtual void hide()
        {
            this.Visible = false;
            this.Enabled = false;
        }

        public virtual void show()
        {
            this.Visible = true;
            this.Enabled = true;
        }

        public GameScene(Game game) : base(game)
        {
            Components = new List<GameComponent>();
            hide();
        }

        public override void Update(GameTime gameTime)
        {
          
            foreach (GameComponent component in Components)
            {
                if (component.Enabled)
                {
                    component.Update(gameTime);
                }
            }
           base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (GameComponent component in Components)
            {
                if (component is DrawableGameComponent)
                {
                    DrawableGameComponent comp = (DrawableGameComponent)component;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }
            base.Draw(gameTime);
        }
    }
}
