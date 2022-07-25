using Balls.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruitNinjaWindowsFormsApp
{
    public partial class MainForm : Form
    {
        private Random random = new Random();
        private Timer timer = new Timer();
        private Timer bananaTimer = new Timer();
        private List<FruitBall> fruits = new List<FruitBall>();
        private int standartSpeedInterval = 35;
        private int normal = 35;
        private int slow = 80;

        public MainForm()
        {
            InitializeComponent();
        }

        private void FruitTimer_Tick(object sender, EventArgs e)
        {
            ChangeFruitsSpeed(normal);

            for (int i = 0; i < random.Next(4, 10); i++)
            {
                var bombNumber = random.Next(10);
                var ball = bombNumber == 0 ? new Bomb(this) : new FruitBall(this);

                ball.timer.Interval = standartSpeedInterval;
                fruits.Add(ball);
                ball.Start();
            }
            timer.Interval = random.Next(2000, 5000);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += FruitTimer_Tick;
            timer.Start();

            bananaTimer.Interval = 6000;
            bananaTimer.Tick += BananaTimer_Tick;
            bananaTimer.Start();
        }

        private void BananaTimer_Tick(object sender, EventArgs e)
        {
            var banana = new BananaFruit(this);
            banana.Start();
            fruits.Add(banana);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var ball in fruits)
            {
                if (ball.IsMoveble() && ball.Contains(e.X, e.Y))
                {
                    ball.Stop();

                    if (ball is Bomb)
                    {
                        EndGame();
                        ball.Clear();
                        return;
                    }

                    if (ball is BananaFruit)
                    {
                        ChangeFruitsSpeed(slow);
                    }

                    ball.Clear();
                    scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 1).ToString();
                }
            }
        }

        private void ChangeFruitsSpeed(int interval)
        {
            this.standartSpeedInterval = interval;
            foreach (var fruit in fruits)
            {
                fruit.timer.Interval = interval;
            }
        }

        private void EndGame()
        {
            timer.Stop();
            bananaTimer.Stop();
            MessageBox.Show("Вы взорвали бомбу. Игра окончена");
        }
    }
}
