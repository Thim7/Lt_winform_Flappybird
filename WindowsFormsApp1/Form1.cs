using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       
        private Random random;
        private int point = 0;
        private int gravity = 20;
        private int pipeSpeed = 15;
        
        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FlappyBird.Image = WindowsFormsApp1.Properties.Resources.down1;
            FlappyBird.Top += gravity;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && timer1.Enabled == true)
            {
                FlappyBird.Top -= gravity;
                FlappyBird.Image = WindowsFormsApp1.Properties.Resources.up1;
                SoundPlayer sound = new SoundPlayer(WindowsFormsApp1.Properties.Resources.tap);
                sound.Play();
            }
            if(e.KeyCode == Keys.Enter)
            {
                FlappyBird.Location = new Point(115, 162);
                
                pipeBottom.Location = new Point(359, 241);
                pipeBottom2.Location = new Point(559, 241);
                pipeBottom3.Location = new Point(759, 241);

                pipeTop.Location = new Point(359, 0);
                pipeTop2.Location = new Point(559, 0);
                pipeTop3.Location = new Point(759, 0);

                pipeBottom.Height = 140;
                pipeTop.Height = 140;
                pipeBottom2.Height = 140;
                pipeTop2.Height = 140;
                pipeBottom3.Height = 141;
                pipeTop3.Height = 141;
                this.Invalidate();
                
                point = 0;
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            pipeBottom.Left -= pipeSpeed;
            if (pipeBottom.Left <= 0)
            {
                pipeBottom.Height = random.Next(5, 20) * 10;
                this.Invalidate();
                pipeBottom.Location = new Point(559, 225 + (140 - pipeBottom.Height));
                point++;
                SoundPlayer sound = new SoundPlayer(WindowsFormsApp1.Properties.Resources.pointup);
                sound.Play();
            }

            pipeBottom2.Left -= pipeSpeed;
            if (pipeBottom2.Left <= 0)
            {
                pipeBottom2.Height = random.Next(5, 20) * 10;
                this.Invalidate();
                pipeBottom2.Location = new Point(559, 225 + (140 - pipeBottom2.Height));
                point++;
                SoundPlayer sound = new SoundPlayer(WindowsFormsApp1.Properties.Resources.pointup);
                sound.Play();
            }

            pipeBottom3.Left -= pipeSpeed;
            if (pipeBottom3.Left <= 0)
            {
                pipeBottom3.Height = random.Next(5, 20) * 10;
                this.Invalidate();
                pipeBottom3.Location = new Point(559, 225 + (140 - pipeBottom3.Height));
                point++;
                SoundPlayer sound = new SoundPlayer(WindowsFormsApp1.Properties.Resources.pointup);
                sound.Play();
            }

            pipeTop.Left -= pipeSpeed;
            if (pipeTop.Left <= 0)
            {
                pipeTop.Height = 281 - pipeBottom.Height;
                this.Invalidate();
                pipeTop.Location = new Point(559, 0);
            }

            pipeTop2.Left -= pipeSpeed;
            if (pipeTop2.Left <= 0)
            {
                pipeTop2.Height = 281 - pipeBottom2.Height;
                this.Invalidate();
                pipeTop2.Location = new Point(559, 0);
            }

            pipeTop3.Left -= pipeSpeed;
            if (pipeTop3.Left <= 0)
            {
                pipeTop3.Height = 281 - pipeBottom3.Height;
                this.Invalidate();
                pipeTop3.Location = new Point(559, 0);
            }

            pointText.Text = "Point: "+ point.ToString();
            
            if (pipeBottom.Bounds.IntersectsWith(FlappyBird.Bounds) || pipeTop.Bounds.IntersectsWith(FlappyBird.Bounds) 
                || pipeBottom2.Bounds.IntersectsWith(FlappyBird.Bounds) || pipeTop2.Bounds.IntersectsWith(FlappyBird.Bounds)
                || pipeBottom3.Bounds.IntersectsWith(FlappyBird.Bounds) || pipeTop3.Bounds.IntersectsWith(FlappyBird.Bounds)
                || FlappyBird.Top < -25 || FlappyBird.Bottom >500)
            {
                SoundPlayer sound = new SoundPlayer(WindowsFormsApp1.Properties.Resources.gameover);
                sound.Play();
                timer1.Enabled = false;
                timer2.Enabled = false;
                MessageBox.Show("\tGame Over !\n\n\tYour Score: " + point + "\n\n\t" + "Press Enter to Play again", "Inform");
                
            }
            if (point >5)
            {
                pipeSpeed = 20;
            }
            if (point > 10)
            {
                pipeSpeed = 22;
            }
            if (point > 15)
            {
                pipeSpeed = 25;
            }
        }

        
    }
}
