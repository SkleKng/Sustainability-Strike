using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike.Content
{
    internal class Trash : Tower
    {

        public static Texture2D texture;
        public static int cost = -1;
        public static int damage = -1;
        public static int cooldown = -1;
        public Trash() : base(texture, cost, damage, cooldown)
        {
        }
    }
}
