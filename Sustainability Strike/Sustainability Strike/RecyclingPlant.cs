using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sustainability_Strike
{
    internal class RecyclingPlant : Tower
    {
        public static Texture2D texture;
        public static int cost = 100;
        public static int damage = 50;
        public static int cooldown = 60;
        
        public RecyclingPlant() : base(texture, cost, damage, cooldown)
        {
        }
    }
}
