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
        protected float Range { get; set; }                    //Range of attack of the tower
        public override string State
        {
            get
            {
                return base.State;
            }
            set
            {
                if (this.Hp <= 0)
                    this.State = "Dead";
                foreach (Unite unite in virus)
                {
                    if (Vector2.Distance(this.Position, unite.Position) <= Range & this.State == "Alive")
                    {
                        this.target = unite;
                        this.State = "Attack";
                        break;
                    }
                    else
                        this.State = "Alive";
                }
            }
        }
        public Tower(string name, int hp, int attack, Vector2 position, float range) : base(name, hp, attack, position)
        {
            this.Range = range;
        }
    }
}
