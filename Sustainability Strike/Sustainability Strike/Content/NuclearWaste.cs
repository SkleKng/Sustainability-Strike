using Microsoft.Xna.Framework.Graphics;
using Sustainability_Strike.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike
{
    internal class NuclearWaste : Enemy
    {
        public static Texture2D texture;
        public static int health = 5000;
        public static int speed = 2;
        public static int cashReward = 2000;

        public NuclearWaste() : base(texture, health, speed, cashReward)
        {

        }
    }
}
