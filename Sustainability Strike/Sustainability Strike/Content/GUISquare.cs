using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sustainability_Strike.Content
{
    internal class GUISquare
    {
        public static Texture2D selectedTexture;
        public static SpriteFont moneyFont;

        public Tower tower;
        public Rectangle rect;
        public bool isSelected;

        public GUISquare(Tower tower, Rectangle rect)
        {
            this.tower = tower;
            this.rect = rect;
            this.isSelected = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (tower != null)
            {
                tower.Draw(spriteBatch, rect);
                if(tower.cost != -1) // Trash can
                {
                    spriteBatch.DrawString(moneyFont, "$" + tower.cost.ToString(), new Vector2(rect.X, rect.Y), Color.LimeGreen);
                }
            }
            if(isSelected)
            {
                spriteBatch.Draw(selectedTexture, rect, Color.White);
            }
        }
    }
}
