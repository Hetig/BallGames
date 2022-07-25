using System;
using System.Collections.Generic;
using Balls.Common;
using System.Windows.Forms;

namespace Balls.Common
{
    public partial class MainForm : Form
    {
        List<Ball> balls;
        public MainForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            balls = new List<Ball>();
            for (int i = 0; i < 10; i++)
            {
                var moveBall = new MoveBall(this);

                balls.Add(moveBall);
                moveBall.Start();
            }
            createButton.Enabled = false;
            stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            var countCathBalls = 0;
            foreach (var ball in balls)
            {
                if (ball.OnForm())
                {
                    countCathBalls++;
                }
                ball.Stop();
            }
            MessageBox.Show($"Вы поймали {countCathBalls} мячей");

            stopButton.Enabled = false;
            clearButton.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            clearButton.Enabled = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach(var ball in balls)
            {
                ball.Clear();
            }

            clearButton.Enabled = false;
            createButton.Enabled = true;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            var ball = new PointBall(this, e.X, e.Y);
            ball.Start();
        }
    }
}
