using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario_Version_3_Part_2._5
{
    public partial class Form1 : Form
    {
        

        //Gameloop
        private Timer gameTimer = new Timer();

        //Player
        private int playerX = 100;
        private int playerY = 300;
        private int playerW = 40;
        private int playerH = 40;

        //Platform Boundary

        private int playerSpd = 7;

        private int clear = 0;

        //Physics - gravity, jumpForce, Velocity
        private int gravity = 1;
        private int force = -15;
        private int vvelocity = 0;

        //Boolean
        private bool moveLeft = false;
        private bool moveRight = false;
        private bool moveUp = false;

        //Level object
        private Rectangle ground;
        private List<Rectangle> platform = new List<Rectangle>();
        private List<Rectangle> Vplatform = new List<Rectangle>();

        //Coin
        private List<Rectangle> coins = new List<Rectangle>();

        //Scoring
        private int score = 0;

        //Enemies
        private List<Rectangle> Enemies = new List<Rectangle>();
        private List<int> EnemiesSpd = new List<int>();

        //Platform Movement
        private List<int> platformSpd = new List<int>();
        private List<int> VplatformSpd = new List<int>();

        //lives
        private int lives = 3;

        //HUD
        private Font hudFont = new Font("Arial", 16);

        //Timer
        private int timeFrames = 0;
        private double timeSeconds = 0;

        //best time
        //private double bestTime = 0;


        // Invincibility Frames
        private bool invincible;
        private int invincibleTime = 0;
        private int invincibleDuration = 60; // ~1 second
        public Form1()
        {
            InitializeComponent();

            CreateLevel1();

            //Game Loop Setup
            gameTimer.Interval = 16;
            gameTimer.Tick += GameLoop;
            
                gameTimer.Start();
            
        }


        private void CreateLevel1()
        {
            ground = new Rectangle(0, 350, 800, 100);

            //Platforms
            platform.Clear();
            platform.Add(new Rectangle(150, 280, 120, 20));
            platform.Add(new Rectangle(330, 240, 120, 20));
            platform.Add(new Rectangle(520, 200, 120, 20));
            platform.Add(new Rectangle(580, 300, 100, 20));
            platform.Add(new Rectangle(400, 160, 140, 20));

            //Platform
            Vplatform.Add(new Rectangle(100, 280, 120, 20));

            //Coins
            coins.Clear();
            coins.Add(new Rectangle(180, 250, 20, 20));
            coins.Add(new Rectangle(360, 210, 20, 20));
            coins.Add(new Rectangle(550, 170, 20, 20));
            coins.Add(new Rectangle(600, 270, 20, 20));
            coins.Add(new Rectangle(450, 130, 20, 20));

            //Enemies
            Enemies.Clear();
            EnemiesSpd.Clear();

            //Enemies on Ground
            Enemies.Add(new Rectangle(600, ground.Y - 35, 35, 35));
            EnemiesSpd.Add(2);

            //Enemies on Platform 1 
            Enemies.Add(new Rectangle(170, 280 - 35, 35, 35));
            EnemiesSpd.Add(2);

            //platforms speed
            platformSpd.Add(1);
            VplatformSpd.Add(2);

            timeFrames = 0;
            timeSeconds = 0;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            UpdateGame();
            Invalidate();
        }

        private void UpdateGame()
        {
            timeSeconds = timeFrames / 60.0;
            timeFrames++;
            

            // Invincibility countdown
            if (invincible == true)
            {
                invincibleTime--;
                if (invincibleTime <= 0)
                    invincible = false;
            }

            //Horizontal Movement
            if (moveLeft)
                playerX -= playerSpd;

            if (moveRight)
                playerX += playerSpd;

            //Player boundary
            if (playerX < 0)
                playerX = 0;

            if (playerX + playerW > this.ClientSize.Width)
                playerX = this.ClientSize.Width - playerW;

            //Gravity and Physics(vertical)
            vvelocity += gravity;
            playerY += vvelocity;

            Rectangle playerRec = new Rectangle(playerX, playerY, playerW, playerH);
            Rectangle RectangleRec = new Rectangle(playerX, playerY, playerW, playerH);

            //Collision with Ground
            if (playerRec.IntersectsWith(ground) && vvelocity >= 0)
            {
                playerY = ground.Y - playerH;
                vvelocity = 0;
                moveUp = false;
                playerRec = new Rectangle(playerX, playerY, playerW, playerH);
            }

            //Platform collisions
            foreach (Rectangle plat in platform)
            {
                if (playerRec.IntersectsWith(plat) && vvelocity >= 0)
                {
                    playerY = plat.Y - playerH;
                    vvelocity = 0;
                    moveUp = false;
                    playerRec = new Rectangle(playerX, playerY, playerW, playerH);
                }
            }

            foreach (Rectangle plat in Vplatform)
            {
                if (playerRec.IntersectsWith(plat) && vvelocity >= 0)
                {
                    playerY = plat.Y - playerH;
                    vvelocity = 0;
                    moveUp = false;
                    playerRec = new Rectangle(playerX, playerY, playerW, playerH);
                }
            }

            //coin Collection
            for (int i = coins.Count - 1; i >= 0; i--)
            {
                if (playerRec.IntersectsWith(coins[i]))
                {
                    coins.RemoveAt(i);
                    score += 10;
                }
            }

            //Enemies Movement
            for (int i = 0; i < Enemies.Count; i++)
            {
                Rectangle e = Enemies[i];
                e.X += EnemiesSpd[i];

                if (e.X <= 0 || e.X + e.Width >= this.ClientSize.Width)
                    EnemiesSpd[i] = -EnemiesSpd[i];

                Enemies[i] = e;
            }

            //Moving left and Right Platform
            for (int i = 0; i < platform.Count; i++)
            {
                Rectangle e = platform[0];
                e.X += platformSpd[0];

                if (e.X <= 0 || e.X + e.Height >= this.ClientSize.Height)
                    platformSpd[0] = -platformSpd[0];

                platform[0] = e;
            }

            //Up and Down Platform
            for (int i = 0; i < Vplatform.Count; i++)
            {
                Rectangle e = Vplatform[0];
                e.Y += VplatformSpd[0];

                if (e.Y <= 0 || e.Y + e.Height >= this.ground.Y)
                    VplatformSpd[0] = -VplatformSpd[0];

                Vplatform[0] = e;
            }

            //Player vs Enemies
            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Rectangle e = Enemies[i];
                if (playerRec.IntersectsWith(e))
                {
                    bool stomp = vvelocity > 0 && (playerY + playerH - vvelocity <= e.Y);

                    if (stomp)
                    {
                        Enemies.RemoveAt(i);
                        EnemiesSpd.RemoveAt(i);

                        vvelocity = force / 2;
                        score += 50;
                    }
                    else
                    {
                        if (invincible == false)
                        {


                            lives--;
                            ResetPlayer();

                            invincible = true;
                            invincibleTime = invincibleDuration;

                            if (lives <= 0)
                                Gameover();

                            break;
                        }
                    }
                }
            }
        }

        private void Gameover()
        {
            gameTimer.Stop();
            MessageBox.Show("Game Over");
        }

        private void KeyisDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                moveLeft = true;
            if (e.KeyCode == Keys.D)
                moveRight = true;
            if (e.KeyCode == Keys.Space && !moveUp)
            {
                vvelocity = force;
                moveUp = true;
            }

            if (e.KeyCode == Keys.P)
            {
                PauseGame();
            }

            if (e.KeyCode == Keys.U)
            {
                UnpauseGame();
            }

            if (e.KeyCode == Keys.R)
            {

                if (clear == 0)
                {
                    RestartLevel1();
                }
                else if (clear == 1)
                {
                    RestartLevel2();
                }
            }
        }



        private void KeyisUp(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                moveLeft = false;
            if (e.KeyCode == Keys.D)
                moveRight = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.Brown, ground);

            foreach (Rectangle plat in platform)
                g.FillRectangle(Brushes.Blue, plat);

            foreach (Rectangle plat in Vplatform)
                g.FillRectangle(Brushes.Red, plat);

            foreach (Rectangle c in coins)
                g.FillEllipse(Brushes.Gold, c);

            foreach (Rectangle enemy in Enemies)
                g.FillEllipse(Brushes.Red, enemy);

            // Flashing effect when invincible
            if (invincible && (invincibleTime % 10 < 5))
            {
                g.FillRectangle(Brushes.Yellow, playerX, playerY, playerW, playerH);
            }
            else
            {
                g.FillRectangle(Brushes.Orange, playerX, playerY, playerW, playerH);
            }
            
            g.DrawString("Score: " + score, hudFont, Brushes.Orange, 10, 30);

            g.DrawString("Lives: " + lives, hudFont, Brushes.Orange, 10, 50);

            g.DrawString("Time: " + timeSeconds.ToString("0.00"), hudFont, Brushes.Orange, 10, 70);

            if (clear == 0)
            {
                if (coins.Count == 0 && Enemies.Count == 0)
                {
                    timeFrames++;
                    ResetPlayer();
                    Enemies.Clear();
                    coins.Clear();
                    platform.Clear();
                    CreateLevel2();
                    clear = 1;
                }
            }

            if (clear == 1)
            {
                if (coins.Count == 0 && Enemies.Count == 0)
                {


                    gameTimer.Stop();
                    ResetPlayer();
                    Enemies.Clear();

                    //if (timeSeconds < bestTime)
                   // {
                    //    bestTime = timeSeconds;
                    //}
                    if (timeSeconds < Properties.Settings.Default.bestTime)
                    {
        
                        Properties.Settings.Default.bestTime = timeSeconds;
                        Properties.Settings.Default.Save();
                        
                    }

                    //g.DrawString("BestTime: " + bestTime.ToString("0.00"), hudFont, Brushes.Orange, 10, 90);
                    g.DrawString("Best Time: " + Properties.Settings.Default.bestTime.ToString("0.00"), hudFont, Brushes.Purple, 10, 100);
                    MessageBox.Show("You Win!"+ timeSeconds+"\nBest Time:  " + Properties.Settings.Default.bestTime.ToString("0.00"));

                    //g.DrawString("Best Time: " + Properties.Settings.Default.bestTime.ToString("0.00"), hudFont, Brushes.Purple, 10, 120);
                    
                    coins.Clear();
                    platform.Clear();


                }
            }
        }

        private void ResetPlayer()
        {
            playerX = 100;
            playerY = 300;
            vvelocity = 0;
            moveLeft = false;
            moveRight = false;
            moveUp = false;
           // timeFrames = 0;
           // timeSeconds = 0;
        }

        void Start_Game()
        {
            menuPanel.Visible = false;
            gameTimer.Start();
            
        }

        private void CreateLevel2()
        {
            ground = new Rectangle(0, 350, 800, 100);

            platform.Clear();
            platform.Add(new Rectangle(160, 120, 120, 20));
            platform.Add(new Rectangle(330, 220, 120, 20));
            platform.Add(new Rectangle(500, 180, 120, 20));
            platform.Add(new Rectangle(430, 300, 100, 20));
            platform.Add(new Rectangle(600, 100, 140, 20));




            coins.Clear();
            coins.Add(new Rectangle(180, 250, 20, 20));
            coins.Add(new Rectangle(360, 180, 20, 20));
            coins.Add(new Rectangle(550, 160, 20, 20));
            coins.Add(new Rectangle(650, 80, 20, 20));
            coins.Add(new Rectangle(450, 260, 20, 20));

            Enemies.Clear();
            EnemiesSpd.Clear();

            Enemies.Add(new Rectangle(600, ground.Y - 35, 35, 35));
            EnemiesSpd.Add(2);

            Enemies.Add(new Rectangle(180, 80 - 35, 35, 35));
            EnemiesSpd.Add(2);

            Enemies.Add(new Rectangle(360, 130 - 35, 35, 35));
            EnemiesSpd.Add(2);

            Enemies.Add(new Rectangle(560, 270 - 35, 35, 35));
            EnemiesSpd.Add(2);

            Enemies.Add(new Rectangle(460, 230 - 35, 35, 35));
            EnemiesSpd.Add(2);

        }

        void PauseGame()
        {
            gameTimer.Stop();
        }

        void UnpauseGame()
        {
            gameTimer.Start();
        }

        void RestartLevel1()
        {
            Enemies.Clear();
            platform.Clear();
            Vplatform.Clear();
            coins.Clear();
            ResetPlayer();
            CreateLevel1();
            score = 0;
            lives = 3;
            Start_Game();

        }
        void RestartLevel2()
        {
            Enemies.Clear();
            platform.Clear();
            coins.Clear();
            ResetPlayer();
            CreateLevel2();
            score = 150;
            lives = 3;
            Start_Game();

        }
        //Enter Button
        private void button1_Click_1(object sender, EventArgs e)
        {
            //timeFrames = 0;
            //timeSeconds = 0;
            UpdateGame();
            Start_Game();
        }
        // Quit Button
        private void button2_Click(object sender, EventArgs e)
        {
            Gameover();
        }
    }
}

