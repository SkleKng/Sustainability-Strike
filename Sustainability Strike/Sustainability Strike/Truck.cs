using Microsoft.Xna.Framework.Graphics;
using Sustainability_Strike.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike
{
    internal class Truck : Enemy
    {
        public static Texture2D texture;
        public static int health = 800;
        public static int speed = 4;
        public static int cashReward = 200;

        public Truck() : base(texture, health, speed, cashReward)
        {

        }
    }
}
