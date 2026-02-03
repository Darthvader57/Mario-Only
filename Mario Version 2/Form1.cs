using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario_Version_2
{
    public partial class Form1 : Form
    {
        //Gameloop
        private Timer gameTimer = new Timer();

        //Players
        private int playerX = 100;
        private int playerY = 300;
        private int playerW = 40;
        private int playerH = 40;

        private int playerSpd = 5;

        //Physics - gravity, jumpForce, Velocity
        private int gravity = 1;
        private int force = -15;
        private int vvelocity = 0;

        //Boolean
        private bool moveLeft = false;
        private bool moveRight = false;
        private bool moveUp = false;    //Meant for Jumping Blackest Adam in the Bronks 

        //Level object
        private Rectangle ground;
        private List<Rectangle> platform = new List<Rectangle>();

        //Coin
        private List<Rectangle> coins = new List<Rectangle>();

        //Scoring
        private int score = 0;

        //Enemies
        private List<Rectangle> Enemies = new List<Rectangle>();
        private List<int> EnemiesSpd = new List<int>();

        //lives
        private int lives = 3;

        //HUD
        private Font hudFont = new Font("Arial",16);
        public Form1()
        {
            InitializeComponent();

            CreateLevel();


            //Game Loop Setup
            gameTimer.Interval = 16;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        private void CreateLevel()
        {
            ground = new Rectangle(0, 350, 800, 100);

            //Platforms
            platform.Clear();
            platform.Add(new Rectangle(150, 280, 120, 20));
            platform.Add(new Rectangle(330, 240, 120, 20));
            platform.Add(new Rectangle(520, 200, 120, 20));
            platform.Add(new Rectangle(550, 300, 100, 20));
            platform.Add(new Rectangle(400, 160, 140, 20));

            //Coins
            coins.Clear();
            coins.Add(new Rectangle(180, 250, 20, 20));
            coins.Add(new Rectangle(360, 210, 20, 20));
            coins.Add(new Rectangle(550, 170, 20, 20));
            coins.Add(new Rectangle(680, 270, 20, 20));
            coins.Add(new Rectangle(450, 130, 20, 20));

            //Enemies
            Enemies.Clear();
            EnemiesSpd.Clear();


            //Enemies on Ground
            Enemies.Add(new Rectangle(600, ground.Y - 35, 35, 35));
            EnemiesSpd.Add(2);

            //Enemies on Platform 1 
            Enemies.Add(new Rectangle(170 , 280 - 35 , 35 , 35));
            EnemiesSpd.Add(2);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            UpdateGame();
            Invalidate();
        }

        private void UpdateGame()
        {
            //Horizontal Movement
            if (moveLeft)
                playerX -=playerSpd;

            if (moveRight)
                playerX += playerSpd;

            //Player boundary
            if(playerX  < 0)
            {
                playerX = 0; 
            }
               
            if(playerX + playerY > this.ClientSize.Width)
            {
                playerX = this.ClientSize.Width - playerW;
            }
            //Gravity and Physics(vertical)
            vvelocity += gravity;
            playerY += vvelocity;

            Rectangle playerRec = new Rectangle(playerX, playerY, playerW, playerH);

            //Collision with Ground = vvelocity >= 0;
            if (playerRec.IntersectsWith(ground)  && vvelocity >= 0)
            {
                playerY = ground.Y - playerH;
                vvelocity = 0;
                moveUp = false;
                playerRec = playerRec = new Rectangle(playerX, playerY, playerW, playerH);
            }

            foreach(Rectangle plat in platform)
            {
                if
                {

                }
            }
        }
    }
}
