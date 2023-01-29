using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sustainability_Strike
{
    internal class Tesla : Tower
    {
        public static Texture2D texture;
        public static int cost = 750;
        public static int damage = 30;
        public static int cooldown = 1;

        public Tesla() : base(texture, cost, damage, cooldown)
        {
        }
    }
}
