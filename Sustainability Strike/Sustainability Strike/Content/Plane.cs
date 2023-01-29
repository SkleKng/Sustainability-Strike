using Microsoft.Xna.Framework.Graphics;
using Sustainability_Strike.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike
{
    internal class Plane : Enemy
    {
        public static Texture2D texture;
        public static int health = 1200;
        public static int speed = 12;
        public static int cashReward = 600;

        public Plane() : base(texture, health, speed, cashReward)
        {

        }
    }
}
