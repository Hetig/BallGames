using Balls.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SecondBallGameWindowsFormsApp
{   
    public partial class MainForm : Form
    {
        private List<Ball> balls = new List<Ball>();

        private int countCatchBalls = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            clearButton.Enabled = false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < 10; i++)
            {
                var moveBall = new MoveBall(this);

                balls.Add(moveBall);
                moveBall.Start();
            }
            createButton.Enabled = false;
            clearButton.Enabled = true;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var ball in balls)
            {
                if(ball.IsMoveble() && ball.Contains(e.X, e.Y))
                {
                    countCatchBalls++;                   
                    ball.Stop();
                }
            }
            countCatchBallsLabel.Text = countCatchBalls.ToString();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach(var ball in balls)
            {
                ball.Clear();
            }

            createButton.Enabled = true;
            clearButton.Enabled = false;
            countCatchBalls = 0;
            countCatchBallsLabel.Text = "0";
        }
    }
}
