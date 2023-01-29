using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sustainability_Strike.Content;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sustainability_Strike
{
    public class Game1 : Game
    {
        public enum GameState
        {
            TitleScreen,
            Playing,
            Won,
            GameOver
        }

        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Textures
        private Texture2D background;
        private Texture2D gameOverScreen;
        private Texture2D startScreen;
        private Texture2D pixel;
        
        private Texture2D pathBlock;
        private Texture2D SelectedBorderTx;
        //Towers
        private Texture2D RecyclingPlantTx;
        private Texture2D SolarPanelTx;
        private Texture2D WindMillTx;
        private Texture2D TeslaTx;

        //Enemies
        private Texture2D WaterBottleTx;
        private Texture2D CarTx;
        private Texture2D TruckTx;
        private Texture2D PlaneTx;
        private Texture2D NuclearWasteTx;
        
        private Texture2D TrashTx;

        private SpriteFont moneyFont;
        private SpriteFont moneyFontBig;

        //Fields
        private Square[,] grid;
        private GUISquare[] gui;
        private List<Square> path;
        private MouseState oldMouseState;
        private GUISquare selectedGUI;

        public static GameState gameState;

        private List<Enemy> enemies;

        private int money;
        private int time;

        private int timeBeforeNextBottle;
        private int timeBeforeNextCar;
        int timeBeforeNextTruck;
        private int timeBeforeNextPlane;
        private int timeBeforeNextWaste;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            IsMouseVisible = true;
            oldMouseState = Mouse.GetState();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            grid = new Square[8, 16];
            gui = new GUISquare[16];
            path = new List<Square>();
            gameState = GameState.TitleScreen;
            enemies = new List<Enemy>();
            money = 100;
            time = 1;
            timeBeforeNextBottle = 120;
            timeBeforeNextCar = 1200;
            timeBeforeNextTruck = 2400;
            timeBeforeNextPlane = 3600;
            timeBeforeNextWaste = 7200;


            base.Initialize();
            InitializeGrid();
            InitializeGUI();

            Enemy.grid = grid;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("BackgroundEarly2");
            pixel = Content.Load<Texture2D>("1x1pixel");
            pathBlock = Content.Load<Texture2D>("Path Block");
            RecyclingPlantTx = Content.Load<Texture2D>("RecyclingTower");
            SelectedBorderTx = Content.Load<Texture2D>("selectedBorder");
            SolarPanelTx = Content.Load<Texture2D>("SolarPanel");
            gameOverScreen = Content.Load<Texture2D>("game over Screen");
            startScreen = Content.Load<Texture2D>("Start Screen");
            WindMillTx = Content.Load<Texture2D>("Windmill");
            CarTx = Content.Load<Texture2D>("Car");
            TruckTx = Content.Load<Texture2D>("Truck");
            PlaneTx = Content.Load<Texture2D>("Plane");
            NuclearWasteTx = Content.Load<Texture2D>("nuclear waste");
            TeslaTx = Content.Load<Texture2D>("Tesla");

            WaterBottleTx = Content.Load<Texture2D>("WaterBottle");

            TrashTx = Content.Load<Texture2D>("Trash");

            moneyFont = Content.Load<SpriteFont>("MoneyFont");
            moneyFontBig = Content.Load<SpriteFont>("MoneyFontBig");

            //Static vars
            Square.PATH_TEXTURE = pathBlock;
            
            //Towers
            RecyclingPlant.texture = RecyclingPlantTx;
            SolarPanel.texture = SolarPanelTx;
            Windmill.texture = WindMillTx;
            Tesla.texture = TeslaTx;

            //Enemies
            WaterBottle.texture = WaterBottleTx;
            Car.texture = CarTx;
            Truck.texture = TruckTx;
            Plane.texture = PlaneTx;
            NuclearWaste.texture = NuclearWasteTx;
            Enemy.pixel = pixel;

            Trash.texture = TrashTx;

            GUISquare.selectedTexture = SelectedBorderTx;
            GUISquare.moneyFont = moneyFont;

            Enemy.debugFont = moneyFont;

            // TODO: use this.Content to load your game content here
        }

        private void InitializeGrid() {
            //iterate through the grid and initialize square objects
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    grid[i, j] = new Square(new Vector2(j * Square.WIDTH, i * Square.HEIGHT));
                }
            }
            path.Add(grid[4, 0]);
            path.Add(grid[4,2]);
            path.Add(grid[4,1]);
            path.Add(grid[5,2]);
            path.Add(grid[6,2]);
            path.Add(grid[6,3]);
            path.Add(grid[6,4]);
            path.Add(grid[6,3]);
            path.Add(grid[6,2]);
            path.Add(grid[6,3]);
            path.Add(grid[6,4]);
            path.Add(grid[6,5]);
            path.Add(grid[6,6]);
            path.Add(grid[5,6]);
            path.Add(grid[4,6]);
            path.Add(grid[4,5]);
            path.Add(grid[4,4]);
            path.Add(grid[3,4]);
            path.Add(grid[2,4]);
            path.Add(grid[2,3]);
            path.Add(grid[2,2]);
            path.Add(grid[2,1]);
            path.Add(grid[1, 1]);
            for(int i = 1; i < 9; i++)
            {
                path.Add(grid[0, i]);
            }
            for(int i = 1; i < 4; i++)
            {
                path.Add(grid[i, 8]);
            }
            path.Add(grid[3, 9]);
            path.Add(grid[3, 10]);
            path.Add(grid[4, 10]);
            path.Add(grid[5, 10]);
            path.Add(grid[5, 9]);
            path.Add(grid[5, 8]);
            path.Add(grid[6, 8]);
            path.Add(grid[7, 8]);
            path.Add(grid[7, 9]);
            path.Add(grid[7, 10]);
            for(int i = 11; i < 16; i++)
            {
                path.Add(grid[7, i]);
            }
            path.Add(grid[6, 15]);
            path.Add(grid[5, 15]);
            for(int i = 15; i > 11; i--)
            {
                path.Add(grid[5, i]);
            }
            for(int i = 1; i < 6; i++)
            {
                path.Add(grid[i, 12]);
            }
            path.Add(grid[1, 13]);


            foreach (Square square in path)
            {
                square.makePath();
            }

            //House
            grid[0, 14].canPlace = false;
            grid[0,15].canPlace = false;
            grid[1,14].canPlace = false;
            grid[1,15].canPlace = false;
        }

        public void InitializeGUI()
        {
            for(int i = 0; i < 16; i++)
            {
                gui[i] = new GUISquare(null, new Rectangle(120 * i, 960, 120, 120));
            }
            gui[0].tower = new RecyclingPlant();
            gui[1].tower = new Windmill();
            gui[2].tower = new Tesla();
            gui[3].tower = new SolarPanel();
            gui[15].tower = new Trash();
        }
            
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseState newMouseState = Mouse.GetState();

            if(gameState == GameState.Playing)
            {
                if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    //check if the mouse clicked on any of the guisquares
                    foreach (GUISquare square in gui)
                    {
                        if (square.rect.Contains(newMouseState.Position))
                        {
                            if (square.tower != null)
                            {
                                if (selectedGUI != null)
                                {
                                    selectedGUI.isSelected = false;
                                }
                                if (selectedGUI != square)
                                {
                                    selectedGUI = square;
                                    square.isSelected = true;
                                }
                                else
                                {
                                    selectedGUI = null;
                                }
                            }
                        }
                    }
                    //check if the mouse clicked on any of the squares
                    foreach (Square square in grid)
                    {
                        if (square.rect.Contains(newMouseState.Position))
                        {
                            if (selectedGUI != null)
                            {
                                if (selectedGUI.tower.GetType() == typeof(Trash))
                                {
                                    if (square.isInUse)
                                    {
                                        money += square.tower.cost / 2;
                                        square.removeTower();
                                    }
                                }
                                else if (square.canPlace)
                                {
                                    if (money >= selectedGUI.tower.cost)
                                    {
                                        square.addTower(selectedGUI.tower);
                                        money -= selectedGUI.tower.cost;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int r = 0; r < 8; r++)
                {
                    for (int c = 0; c < 16; c++)
                    {
                        if (grid[r, c].isInUse)
                        {
                            grid[r, c].tower.cooldown--;
                        }
                    }
                }

                //Make enemies move
                for (int i = enemies.Count - 1; i >= 0; i--)
                {
                    enemies[i].move();
                    if (enemies[i].health <= 0)
                    {
                        money += enemies[i].cashReward;
                        enemies.RemoveAt(i);
                    }
                }


                if (time % timeBeforeNextBottle == 0)
                {
                    enemies.Add(new WaterBottle());
                }
                if (time % timeBeforeNextCar == 0)
                {
                    enemies.Add(new Car());
                }
                if(time % timeBeforeNextTruck == 0)
                {
                    enemies.Add(new Car());
                }
                if(time % timeBeforeNextPlane == 0)
                {
                    enemies.Add(new Plane());
                }
                if(time % timeBeforeNextWaste == 0)
                {
                    enemies.Add(new NuclearWaste());
                }
                if(time % 600 == 0)
                {
                    timeBeforeNextBottle-=20;
                    if (timeBeforeNextBottle < 1) timeBeforeNextBottle = 1;
                }
                if(time % 1200 == 0)
                {
                    timeBeforeNextCar-=10;
                    if (timeBeforeNextCar < 1) timeBeforeNextCar = 1;
                }
                if(time % 1800 == 0)
                {
                    timeBeforeNextTruck-=5;
                    if (timeBeforeNextTruck < 1) timeBeforeNextTruck = 1;
                }
                if(time % 2400 == 0)
                {
                    timeBeforeNextPlane-=2;
                    if (timeBeforeNextPlane < 1) timeBeforeNextPlane = 1;
                }
                if(time % 3000 == 0)
                {
                    timeBeforeNextWaste--;
                    if (timeBeforeNextWaste < 1) timeBeforeNextWaste = 1;
                }
                


                time++;
            }
            if(gameState == GameState.GameOver)
            {
                KeyboardState key = Keyboard.GetState();
                if (key.IsKeyDown(Keys.R))
                    Initialize();
            }
            if(gameState == GameState.TitleScreen)
            {
                if (newMouseState.LeftButton == ButtonState.Pressed)
                    gameState = GameState.Playing;
            }
            oldMouseState = newMouseState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if(gameState == GameState.Playing)
            {
                _spriteBatch.Draw(background, new Rectangle(0, 0, 1920, 1080), Color.White);
                foreach (Square square in grid)
                {
                    square.Draw(_spriteBatch);
                }
                foreach (GUISquare square in gui)
                {
                    square.Draw(_spriteBatch);
                }
                foreach (Enemy enemy in enemies)
                {
                    enemy.Draw(_spriteBatch);
                }

                _spriteBatch.DrawString(moneyFontBig, "Cash: \n" + money, new Vector2(0, 0), Color.Black);
            }
            if(gameState == GameState.GameOver)
            {
                _spriteBatch.Draw(gameOverScreen, new Rectangle(0, 0, 1920, 1080), Color.White);
            }
            if(gameState == GameState.TitleScreen)
            {
                _spriteBatch.Draw(startScreen, new Rectangle(0, 0, 1920, 1080), Color.White);
            }
           

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}