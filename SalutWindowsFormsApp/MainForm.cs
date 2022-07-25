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

namespace SalutWindowsFormsApp
{
    public partial class MainForm : Form
    {
        private Timer saluteTimer = new Timer();
        public SaluteBall saluteBall;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            var random = new Random();
            var count = random.Next(1, 11);

            for (int i = 0; i < count; i++)
            {
                var salut = new SaluteBall(this, e.X, e.Y);
                salut.Start();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            saluteBall = new SaluteBall(this);
            saluteTimer.Start();
            saluteTimer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(saluteBall.AtTheTop())
            {
                StopBall();

                var random = new Random();
                var count = random.Next(5, 11);

                for (int i = 0; i < count; i++)
                {
                    var salute = new SaluteBall(this, saluteBall.centerX, saluteBall.centerY);
                    salute.Start();
                }
            }
            else
            {
                saluteBall.Move();
            }
        }        

        private void StopBall()
        {
            saluteTimer.Stop();
            saluteBall.Clear();
        }       
    }
}
