using Microsoft.Xna.Framework.Graphics;
using Sustainability_Strike.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike
{
    internal class WaterBottle : Enemy
    {
        public static Texture2D texture;
        public static int health = 100;
        public static int speed = 6;
        public static int cashReward = 20;

        public WaterBottle() : base(texture, health, speed, cashReward)
        {
            
        }
    }
}
