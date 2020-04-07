using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders2
{
    public partial class Form1 : Form
    {
        public bool goLeft;
        public bool goRight;
        public int playerSpeed = 6;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                GameTimer.Enabled =true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }

            if (e.KeyCode == Keys.Space)
            {
                Missile();
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    goLeft = false;
                    break;
                case Keys.Right:
                    goRight = false;
                    break;
            }
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (goLeft)
            {
                player.Left -= playerSpeed;
            }
            else if (goRight)
            {
                player.Left += playerSpeed;
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        private void Missile()
        {
            PictureBox bullet = new PictureBox();
            bullet.Padding = new Padding(0);
            bullet.Location = new Point(player.Location.X - 20, player.Location.Y - 60);
            bullet.Size = new Size(100, 100);
            bullet.BackgroundImage = Properties.Resources.kugel;
            bullet.BackgroundImageLayout = ImageLayout.Stretch;
            bullet.Name = "Bullet";
            this.Controls.Add(bullet);
            for (int i = 0; i < 200; i++)
            {
                bullet.Top = i;
            }
        }
    }
}