using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platform_Mario
{
    public partial class PlatformerV1 : Form
    {
        //variables for the player 
        int playerX = 100;
        int playerY = 300;

        //player size
        int playerWidth = 40;
        int playerHeight = 40;

        int playerSpeed = 5;

        //vertical Jumping 
        int jump = -15;
        int gravity = 1;
        int velocity = 0;

        //boolean variables
        bool moveLeft = false;
        bool moveRight = false;
        bool isJumping = false;

        //Game objects
        Rectangle ground;
        Rectangle platform1;
        Rectangle platform2;
            
        //GAME TIMER 
        Timer gameTimer = new Timer();
        public PlatformerV1()
        {
            InitializeComponent();

            //Level creation
            ground = new Rectangle(0, 350, 800 , 100);
            platform1 = new Rectangle(300, 280, 120, 20);
            platform2 = new Rectangle(500, 220, 120, 20);

            gameTimer.Interval = 16;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            //Input Event
            this.KeyDown += KeyisDown;
            this.KeyUp += KeyisUp;
        }
      
        private void GameLoop(object sender, EventArgs e)
        {
            UpdatePlayer();
            Invalidate();
        }

        private void UpdatePlayer()
        {
            if (moveLeft)
                playerX -= playerSpeed;

            if (moveRight)
                playerX += playerSpeed;

            velocity += gravity;
            playerY += velocity;
            
            //Player hitbox
            Rectangle playerRec = new Rectangle(playerX, playerY, playerWidth, playerHeight);

            //Collision Ground
            if (playerRec.IntersectsWith(ground) && velocity >= 0)
            {
                playerY = ground.Y - playerHeight;
                velocity = 0;
                isJumping = false;
            }
            
            if (playerRec.IntersectsWith(platform1) && velocity >= 0)
            {
                playerY = platform1.Y - playerHeight;
                velocity = 0;
                isJumping = false;
            }

            if (playerRec.IntersectsWith(platform2) && velocity >= 0)
            {
                playerY = platform2.Y - playerHeight;
                velocity = 0;
                isJumping = false;
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); 

            Graphics g = e.Graphics;

            //Draw ground
            g.FillRectangle(Brushes.Red, ground);
            g.FillRectangle(Brushes.Orange, platform1);
            g.FillRectangle(Brushes.Brown, platform2);

            //Draw the Mariga
            g.FillRectangle(Brushes.Black, playerX, playerY, playerWidth, playerHeight);
        }

        //input handling
        private void KeyisDown(object sender, KeyEventArgs e)
        {
            //left movement
            if (e.KeyCode == Keys.A)
                moveLeft = true;
            
            //Right Movement
            if (e.KeyCode == Keys.D)
                moveRight = true;
            
            //Jump
            if (e.KeyCode == Keys.Space && !isJumping)
            {
                velocity = jump;
                isJumping = true;
            }
                
        }


        private void KeyisUp(object sender, KeyEventArgs e)
        {
            //left movement
            if (e.KeyCode == Keys.A)
                moveLeft = false;

            //Right Movement
            if (e.KeyCode == Keys.D)
                moveRight = false;
        }
    }
}
