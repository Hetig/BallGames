using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallGameWindowsFormsApp
{
    public class MoveBall : RandomPointBall
    {
        private Timer timer;
        public MoveBall(MainForm form) : base(form)
        {
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            vx += random.Next(-5, 7);
            vy += random.Next(-5, 6);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Move();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();   
        }
    }
}
