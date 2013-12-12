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
    class Tower : Unite
    {
        protected Unite target;                                //Target of the tower
        public List<Unite> virus = new List<Unite>();
        protected double Range { get; set; }                    //Range of attack of the tower
        public override Etat State
        {
            get
            {
                return this.etat;
            }
            set
            {
                if (this.Hp <= 0)
                    this.etat = Etat.Dead;
                foreach (Unite unite in virus)
                {
                    if (Vector2.Distance(this.Position, unite.Position) <= Range & this.State == Etat.Alive)
                    {
                        this.target = unite;
                        this.etat = Etat.Attack;
                        break;
                    }
                    else
                        this.etat = Etat.Alive;
                }
            }
        }
        public Tower(string name, int hp, int attack, int cooldown, Vector2 position, double range) : base(name, hp, attack, cooldown, position)
        {
            this.Range = range;
        }
        public void Attacking()
        {
            if (this.State == Etat.Attack & this.Cooldown <= 0)
            {
                this.Cooldown = this.basecooldown;
                target.Hp = target.Hp - this.Attack;
            }
        }
    }
}
