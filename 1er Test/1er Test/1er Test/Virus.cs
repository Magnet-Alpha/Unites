using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _1er_Test
{
    class Virus : Unite
    {
        public List<Unite> virus = new List<Unite>();
        protected double Speed { get; set; }
        List<Texture2D> imgs = new List<Texture2D>();
        int img;
        public Virus(string name, int hp, int attack, int cooldown, Vector2 position, double speed, ContentManager content, SpriteBatch sb, Etat e) : base(name, hp, attack, cooldown, position)
        {
            this.Speed = speed;
            content.RootDirectory = "Content";
            imgs.Add(content.Load<Texture2D>("test wait 1"));
            imgs.Add(content.Load<Texture2D>("test attack 1"));
            imgs.Add(content.Load<Texture2D>("test dead 1"));
            this.unitbatch = sb;
            this.etat = e;
        }
        public void StateDraw()
        {
            if (this.State == Etat.Alive)
                img = 0;
            else if (this.State == Etat.Attack)
                img = 1;
            else if (this.State == Etat.Dead)
                img = 2;
            StateDrawing();
        }
        public void StateDrawing()
        {
            unitbatch.Draw(imgs[img], this.Position, Color.White);
        }
    }
}
