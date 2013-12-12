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
    class Unite                                             //In development, DO NOT EDIT WITHOUT PERMISSION
    {
        public enum Etat
        {
            Alive,
            Attack,
            Dead,
            Attacked,
            Moving
        }
        protected SpriteBatch unitbatch;                    //The SpriteBatch
        public string Name { get; set; }                    //Name of the unit (type of unit)
        protected int maxhp;                                //Maximum hp, initialized at the creation of the object, cannot be changed
        public int Hp { get; set; }                         //Actual hp
        public int Attack { get; set; }                     //Unit attack
        protected int basecooldown;                         //base cooldown
        public int Cooldown { get; set; }                   //Actual unit cooldown before attacking again
        public Vector2 Position { get; set; }               //Actual position of the unit
        public Vector2 Moving;                              //Actual direction of the unit
        protected Etat etat;
        public virtual Etat State                           //State of the unit (Walking/Attacking/Dead)
        { 
            get
            {
                return this.etat;
            }

            set
            {
                if (this.Hp <= 0)
                    this.etat = Etat.Dead;
                else
                    this.etat = Etat.Alive;
            }
        
        }
        public Unite(string name, int hp, int attack, int cooldown, Vector2 position)       //Creation of an unit, taking his name, his max hp and his attack. Unit initial position will be his spawn point
        {
            this.Name = name;
            this.maxhp = hp;
            this.Hp = hp;
            this.Attack = attack;
            this.basecooldown = cooldown;
            this.Cooldown = cooldown;
            this.Position = position;
            this.State = Etat.Alive;
        }
    }
}
