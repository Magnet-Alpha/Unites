﻿using System;
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
        protected double Range { get; set; }                    //Range of attack of the tower
        private double p2;
        public override Etat State
        {
            get
            {
                return this.etat;
            }
            set
            {
                this.etat = value;
            }
        }
        public Tower(string name, int hp, int attack, int cooldown, Vector2 position, double range, ContentManager content, SpriteBatch sb, Etat e) : base(name, hp, attack, cooldown, position, content, sb, e)
        {
            this.Range = range;
            this.p2 = Math.Pow(range, 2);
        }
        public void Attacking()
        {
            if (this.State == Etat.Attack & this.Cooldown <= 0)
            {
                this.Cooldown = this.basecooldown;
                target.Hp = target.Hp - this.Attack;
            }
        }
        public void Stating(List<Unite> virus)
        {
            if (this.Hp <= 0)
                this.etat = Etat.Dead;
            foreach (Unite unite in virus)
            {
                if (Math.Pow((unite.Position.X - this.Position.X), 2) + 4 * Math.Pow((-(unite.Position.Y - this.Position.Y)), 2) <= p2 && (this.State == Etat.Alive || this.State == Etat.Attack) && unite.State != Etat.Dead)
                {
                    this.target = unite;
                    unite.State = Etat.Attacked;
                    this.etat = Etat.Attack;
                    break;
                }
                else
                    this.etat = Etat.Alive;
            }
        }
    } ///Vector2.Distance(this.Position, unite.Position) <= Range
    ///Math.Pow((unite.Position.X - this.Position.X), 2) + 4 * Math.Pow((-(unite.Position.Y - this.Position.Y)), 2) <= p2 
}
