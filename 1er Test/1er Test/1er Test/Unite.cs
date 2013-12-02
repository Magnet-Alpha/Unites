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
        protected SpriteBatch unitbatch;                    //The SpriteBatch
        public string Name { get; set; }                    //Name of the unit (type of unit)
        protected int maxhp;                                //Maximum hp, initialized at the creation of the object, cannot be changed
        public int Hp { get; set; }                         //Actual hp
        public int Attack { get; set; }                     //Unit attack
        public Vector2 Position { get; set; }               //Actual position of the unit
        public virtual string State                                 //State of the unit (Walking/Attacking/Dead)
        { 
            get
            {
                return this.State;
            }

            set
            {
                if (this.Hp <= 0)
                    this.State = "Dead";
                else
                    this.State = "Alive";
            }
        
        }
        public Unite(string name, int hp, int attack, Vector2 position)       //Creation of an unit, taking his name, his max hp and his attack. Unit initial position will be his spawn point
        {
            this.Name = name;
            this.maxhp = hp;
            this.Hp = hp;
            this.Attack = attack;
            this.Position = position;
            this.State = "Alive";
        }
    }
}
