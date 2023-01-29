using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike
{
    internal class Tower
    {
        private Texture2D texture;
        
        public int damage;

        public int cost;

        public int cooldown;

        public int DEFAULT_COOLDOWN;
        

        public Tower(Texture2D texture, int cost, int damage, int cooldown)
        {
            this.texture = texture;
            this.cost = cost;
            this.damage = damage;
            this.cooldown = cooldown;
            this.DEFAULT_COOLDOWN = cooldown;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle location)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }
    }
}
