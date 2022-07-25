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

namespace BilliardBallsWindowsFormsApp
{
    public partial class MainForm : Form
    {
        private List<BilliardBall> balls = new List<BilliardBall>();
        private Timer timer = new Timer();

        private int ballsCount = 20;
        public MainForm()
        {
            InitializeComponent();

            timer.Interval = 50;
            timer.Tick += Timer_Tick;
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            ShowVerticalCenterLine();
            var rightOfCenterRedCount = 0;
            var rightOfCenterBlueCount = 0;

            var leftOfCenterRedCount = 0;
            var leftOfCenterBlueCount = 0;

            foreach (var ball in balls)
            {
                ball.Move();
                if (ball.RightOfCenter())
                {
                    if (ball.GetBrush() == Brushes.Red)
                    {
                        rightOfCenterRedCount++;
                    }
                    else
                    {
                        rightOfCenterBlueCount++;
                    }
                }

                if (ball.LeftOfCenter())
                {
                    if (ball.GetBrush() == Brushes.Red)
                    {
                        leftOfCenterRedCount++;
                    }
                    else
                    {
                        leftOfCenterBlueCount++;
                    }
                }
            }

            if (leftOfCenterBlueCount == leftOfCenterRedCount && rightOfCenterBlueCount == rightOfCenterRedCount
                && leftOfCenterBlueCount + leftOfCenterRedCount == rightOfCenterBlueCount + rightOfCenterRedCount
                && leftOfCenterBlueCount + leftOfCenterRedCount + rightOfCenterBlueCount + rightOfCenterRedCount == ballsCount)
            {
                StopBalls();
            }
        }

        private void StopBalls()
        {
            timer.Stop();
        }

        private void StartBalls()
        {
            timer.Start();
        }

        private void ShowVerticalCenterLine()
        {
            var graphics = CreateGraphics();
            graphics.DrawLine(Pens.Black, ClientSize.Width / 2, 0, ClientSize.Width / 2, ClientSize.Height);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ballsCount / 2; i++)
            {
                var ball = new BilliardBall(this, Brushes.Red);
                ball.OnHited += Ball_OnHited_Red;
                balls.Add(ball);
                StartBalls();

                ball = new BilliardBall(this, Brushes.Blue);
                ball.OnHited += Ball_OnHited_Blue;
                balls.Add(ball);
                StartBalls();
            }

        }

        private void Ball_OnHited_Red(object sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftSideRedLabel.Text = (Convert.ToInt32(leftSideRedLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightSideRedLabel.Text = (Convert.ToInt32(rightSideRedLabel.Text) + 1).ToString();
                    break;
                case Side.Up:
                    upSideRedLabel.Text = (Convert.ToInt32(upSideRedLabel.Text) + 1).ToString();
                    break;
                case Side.Down:
                    downSideRedLabel.Text = (Convert.ToInt32(downSideRedLabel.Text) + 1).ToString();
                    break;
            }
        }

        private void Ball_OnHited_Blue(object sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftSideBlueLabel.Text = (Convert.ToInt32(leftSideBlueLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightSideBlueLabel.Text = (Convert.ToInt32(rightSideBlueLabel.Text) + 1).ToString();
                    break;
                case Side.Up:
                    upSideBlueLabel.Text = (Convert.ToInt32(upSideBlueLabel.Text) + 1).ToString();
                    break;
                case Side.Down:
                    downSideBlueLabel.Text = (Convert.ToInt32(downSideBlueLabel.Text) + 1).ToString();
                    break;
            }
        }        
    }
}