using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sustainability_Strike
{
    internal class Square
    {

        public static int WIDTH = 120;
        public static int HEIGHT = 120;
        public static Texture2D PATH_TEXTURE;
        public Rectangle rect;
        public bool canPlace;
        public bool isPath;
        public bool isInUse;
        public Tower tower;

        public Square(Vector2 location)
        {
            this.rect = new Rectangle((int)location.X, (int)location.Y, WIDTH, HEIGHT);
            this.canPlace = true;
            this.isInUse = false;
            isPath = false;
            tower = null;
        }

        public void addTower(Tower tower)
        {
            isInUse = true;
            this.tower = tower;
        }

        public void removeTower()
        {
            isInUse = false;
            this.tower = null;
        }

        public void makePath()
        {
            isPath = true;
            canPlace = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isPath)
            {
                spriteBatch.Draw(PATH_TEXTURE, rect, Color.White);
            }
            else if (isInUse)
            {
                tower.Draw(spriteBatch, rect);
            }
        }
    }
}
