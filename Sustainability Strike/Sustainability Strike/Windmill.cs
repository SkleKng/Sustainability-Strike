using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sustainability_Strike
{
    internal class Windmill : Tower
    {
        public static Texture2D texture;
        public static int cost = 250;
        public static int damage = 100;
        public static int cooldown = 20;


        public Windmill() : base(texture, cost, damage, cooldown)
        {
        }
    }
}
