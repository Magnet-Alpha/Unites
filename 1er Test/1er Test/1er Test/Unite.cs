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
    public enum Etat
    {
        Alive,
        Attack,
        Dead,
        Attacked,
        Moving
    }

    class Unite                                             //In development, DO NOT EDIT WITHOUT PERMISSION
    {
       
        protected SpriteBatch unitbatch;                    //The SpriteBatch
        public string Name { get; set; }                    //Name of the unit (type of unit)
        protected int maxhp;                                //Maximum hp, initialized at the creation of the object, cannot be changed
        public int Hp { get; set; }                         //Actual hp
        public int Attack { get; set; }                     //Unit attack
        protected int basecooldown;                         //base cooldown
        public int Cooldown { get; set; }                   //Actual unit cooldown before attacking again
        public Vector2 Position { get; set; }               //Actual position of the unit
        public Vector2 moving;                              //Actual direction of the unit
        protected Etat etat;
        protected List<Texture2D> imgs = new List<Texture2D>();
        protected int img;
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
        public Unite(string name, int hp, int attack, int cooldown, Vector2 position, ContentManager content, SpriteBatch sb, Etat e)       //Creation of an unit, taking his name, his max hp and his attack. Unit initial position will be his spawn point
        {
            this.Name = name;
            this.maxhp = hp;
            this.Hp = hp;
            this.Attack = attack;
            this.basecooldown = cooldown;
            this.Cooldown = cooldown;
            this.Position = position;
            this.State = Etat.Alive;
            this.moving = new Vector2(1,0);
            this.unitbatch = sb;
            this.etat = e;
            imgs.Add(content.Load<Texture2D>("test wait 1" + this.Name));
            imgs.Add(content.Load<Texture2D>("test attack 1" + this.Name));
            imgs.Add(content.Load<Texture2D>("test dead 1" + this.Name));
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
