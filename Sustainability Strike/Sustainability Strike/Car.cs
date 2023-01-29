using Microsoft.Xna.Framework.Graphics;
using Sustainability_Strike.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike
{
    internal class Car : Enemy
    {
        public static Texture2D texture;
        public static int health = 400;
        public static int speed = 8;
        public static int cashReward = 100;
        
        public Car() : base(texture, health, speed, cashReward)
        {

        }
    }
}
