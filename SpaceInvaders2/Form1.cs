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
        public bool isPressed;
        public int playerSpeed = 6;
        public int enemySpeed = 6;
        public int score = 0;

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
            
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;
                makeBullet();
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

            if (isPressed)
            {
                isPressed = false;
            }
        }

        private void gameover()
        {
            GameTimer.Stop();
            label1.Text += "yeeted";
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

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "invader")
                {
                    if (((PictureBox) x).Bounds.IntersectsWith(player.Bounds))
                    {
                        gameover();
                    }

                    ((PictureBox) x).Left += enemySpeed;


                    if (((PictureBox) x).Left > 600)
                    {
                        ((PictureBox) x).Top += ((PictureBox) x).Height + 10;
                        enemySpeed = -6;
                    }
                    
                    if (((PictureBox) x).Left < 0)
                    {
                        ((PictureBox) x).Top += ((PictureBox) x).Height + 10;
                        enemySpeed = 6;
                    }
                    
                }
            }



            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "bullet")
                {
                    y.Top -= 20;
                }
            }

            foreach (Control i in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "invader")
                    {
                        if (j is PictureBox && j.Tag == "bullet")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                score++;
                                this.Controls.Remove(i);
                                this.Controls.Remove(j);
                            }
                        }
                    }
                }
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void makeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.kugel;
            bullet.Size = new Size(5,20);
            bullet.Tag = "bullet";
            bullet.Left = player.Left + player.Width / 2;
            bullet.Top = player.Top - 20;
            bullet.ForeColor = Color.Black;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }
    }
}