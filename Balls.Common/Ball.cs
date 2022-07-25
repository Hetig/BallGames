using System;
using System.Drawing;
using System.Windows.Forms;

namespace Balls.Common
{
    public class Ball
    {
        public Form form;
        private static Random random = new Random();
        public Timer timer;
        protected Brush brush = Brushes.Red;
        public float vx = 5;
        public float vy = 5;

        public float centerX = 100;
        public float centerY = 100;
        public int radius = 25;
        public Ball(Form form)
        {
            this.form = form;

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            Move();
        }

        public void Show()
        {            
            Draw(brush);
        }

        public Brush GetBrush()
        {
            return brush;
        }

        protected virtual void Go()
        {
            centerX += vx;
            centerY += vy;
        }

        public void Clear()
        {            
            var brush = new SolidBrush(form.BackColor);
            Draw(brush);
        }

        private void Draw(Brush brush)
        {
            var graphics = form.CreateGraphics();
            var rectangle = new RectangleF(centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            graphics.FillEllipse(brush, rectangle);
        }

        public int LeftSide()
        {
            return radius;
        }

        public int RightSide()
        {
            return form.ClientSize.Width - radius;
        }

        public int UpSide()
        {
            return radius;
        }

        public int DownSide()
        {
            return form.ClientSize.Height - radius;
        }

        public virtual void Move()
        {
            Clear();
            Go();
            Show();
        }

        public virtual bool OnForm()
        {
            return centerX >= LeftSide() && centerX <= RightSide() && centerY >= UpSide() && centerY <= DownSide();
        }

        public bool Contains(float pointX, float pointY)
        {
            var dx = centerX - pointX;
            var dy = centerY - pointY;  
            return dx * dx + dy * dy <= radius * radius;
        }

        public bool IsMoveble()
        {
            return timer.Enabled == true;
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
