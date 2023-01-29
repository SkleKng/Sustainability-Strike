using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike
{
    internal class SolarPanel : Tower
    {
        public static Texture2D texture;
        public static int cost = 1000;
        public static int damage = 750;
        public static int cooldown = 60;

        public SolarPanel() : base(texture, cost, damage, cooldown)
        {
        }
    }
}
