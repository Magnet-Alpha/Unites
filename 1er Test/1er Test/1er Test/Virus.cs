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
        protected float Speed { get; set; }
        public Virus(string name, int hp, int attack, int cooldown, Vector2 position, float speed, ContentManager content, SpriteBatch sb, Etat e) : base(name, hp, attack, cooldown, position, content, sb, e)
        {
            this.Speed = speed;
        }
        public void NewPosition()
        {
            this.Position = this.Position + this.moving * this.Speed;
        }
    }
}
