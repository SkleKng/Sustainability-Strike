using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike.Content
{
    internal class Enemy
    {
        public Rectangle position;
        private Texture2D texture;
        public static Texture2D pixel;
        public int health;
        public int speed;
        public int direction; // 0 - up, 1 - right, 2 - down, 3 - left
        public int currentSquareIndex;

        public int cashReward;

        public int maxHealth;


        int row = 4;
        int col = 0;

        public static Square[,] grid;

        public static SpriteFont debugFont;

        private int totalDistance;

        public Enemy(Texture2D texture, int health, int speed, int cashReward)
        {
            this.texture = texture;
            position = new Rectangle(-120, 480, 120, 120);
            this.health = health;
            this.speed = speed;
            this.direction = 1;
            this.currentSquareIndex = 0;
            this.totalDistance = -120;
            this.cashReward = cashReward;
            this.maxHealth = health;
        }

        public void move()
        {
            if (direction == 0)
            {
                position.Y -= speed;
            }
            else if (direction == 1)
            {
                position.X += speed;
            }
            else if (direction == 2)
            {
                position.Y += speed;
            }
            else if (direction == 3)
            {
                position.X -= speed;
            }

            totalDistance += speed;
            if (totalDistance > 0 && totalDistance % 120 == 0)
            {
                currentSquareIndex++;
                checkIfDirectionChanges();
                checkIfShouldBeDamaged();
            }
        }

        private void checkIfDirectionChanges()
        {
            switch(currentSquareIndex)
            {
                case 2:
                    direction = 2;
                    break;
                case 4:
                    direction = 1;
                    break;
                case 8:
                    direction = 0;
                    break;
                case 10:
                    direction = 3;
                    break;
                case 12:
                    direction = 0;
                    break;
                case 14:
                    direction = 3;
                    break;
                case 17:
                    direction = 0;
                    break;
                case 19:
                    direction = 1;
                    break;
                case 26:
                    direction = 2;
                    break;
                case 29:
                    direction = 1;
                    break;
                case 31:
                    direction = 2;
                    break;
                case 33:
                    direction = 3;
                    break;
                case 35:
                    direction = 2;
                    break;
                case 37:
                    direction = 1;
                    break;
                case 44:
                    direction = 0;
                    break;
                case 46:
                    direction = 3;
                    break;
                case 49:
                    direction = 0;
                    break;
                case 53:
                    direction = 1;
                    break;
                case 55:
                    Game1.gameState = Game1.GameState.GameOver;
                    break;
                default:
                    break;
            }
        }

        private void checkIfShouldBeDamaged()
        {
            row = position.Y / 120;
            col = position.X / 120;
            //check all surrounding squares
            for(int r = row-1; r < row+2; r++)
            {
                for (int c = col - 1; c < col + 2; c++)
                {
                    if (r >= 0 && r <= 7 && c >= 0 && c <= 15)
                    {
                        if (grid[r, c].isInUse && grid[r, c].tower.cooldown <= 0)
                        {
                            health -= grid[r, c].tower.damage;
                            grid[r, c].tower.cooldown = grid[r, c].tower.DEFAULT_COOLDOWN;
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(pixel, new Rectangle(position.X, position.Y, (int)(120 * ((float)health / maxHealth)), 10), Color.Red);
            // spriteBatch.DrawString(debugFont, health.ToString(), new Vector2(position.X, position.Y + 40), Color.White);
        }
    }
}
