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

namespace AngryBirdsWindowsFormsApp
{
    public partial class MainForm : Form
    {
        private BirdBall bird;
        private PigBall pig;

        private Timer checkHitTimer = new Timer();
        private Timer respawnTimer = new Timer();

        private int score = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bird = new BirdBall(this);
            pig = new PigBall(this);

            bird.Start();
            pig.Start();

            respawnTimer.Interval = 3000;
            respawnTimer.Tick += RespawnTimer_Tick;
            respawnTimer.Start();

            checkHitTimer.Interval = 35;
            checkHitTimer.Tick += Timer_Tick;
            checkHitTimer.Start();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            bird.Throw(e.X, e.Y);

            checkHitTimer.Start();
        }

        private void RespawnTimer_Tick(object sender, EventArgs e)
        {
            if (!pig.IsMoveble())
            {
                pig.TakeStandartPosition();               
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CheckTheHit();
        }

        public void CheckTheHit()
        {
            var dx = bird.centerX - pig.centerX;
            var dy = bird.centerY - pig.centerY;

            if (dx * dx + dy * dy <= (bird.radius + pig.radius) * (bird.radius + pig.radius))
            {
                pig.Stop();
                pig.Clear();
                checkHitTimer.Stop();
                score += 1;
                scoreLabel.Text = score.ToString();
            }
        }
    }
}
