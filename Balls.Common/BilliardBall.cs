using System;
using System.Drawing;
using System.Windows.Forms;

namespace Balls.Common
{
    public class BilliardBall : MoveBall
    {
        public event EventHandler<HitEventArgs> OnHited;
        public BilliardBall(Form form, Brush brush) : base(form)
        {
            this.brush = brush;

            this.radius = 10;
        }

        protected override void Go()
        {
            base.Go();

            if (centerX <= LeftSide())
            {
                vx = -vx;
                OnHited.Invoke(this, new HitEventArgs(Side.Left));
            }
            if (centerX >= RightSide())
            {
                vx = -vx;
                OnHited.Invoke(this, new HitEventArgs(Side.Right));
            }
            if (centerY <= UpSide())
            {
                vy = -vy;
                OnHited.Invoke(this, new HitEventArgs(Side.Up));
            }
            if (centerY >= DownSide())
            {
                vy = -vy;
                OnHited.Invoke(this, new HitEventArgs(Side.Down));
            }
        }

        public bool LeftOfCenter()
        {
            return centerX + radius > LeftSide() && centerX + radius < form.ClientSize.Width / 2;
        }

        public bool RightOfCenter()
        {
            return centerX + radius < RightSide() && centerX - radius > form.ClientSize.Width / 2;
        }
        
    }
}
