using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balls.Common
{
    public class SaluteBall : MoveBall
    {
        private float g = 0.2f;
        public SaluteBall(Form form, float centerX, float centerY) : base(form)
        {
            vx = random.Next(-4, 5);
            vy = random.Next(-4, 5);

            while (vx == 0)
            {
                vx = random.Next(-4, 5);
            }

            while (vy == 0)
            {
                vy = random.Next(-4, 5);
            }

            this.centerX = centerX;
            this.centerY = centerY;

            radius = 10;
            timer.Interval = 30;
            vy = - Math.Abs(vy);
        }

        public SaluteBall(Form form):base(form)
        {
            centerX = form.ClientSize.Width / 2;
            centerY = DownSide();

            vx = 0;
            vy = -25;

            radius = 10;
        }

        protected override void Go()
        {
            base.Go();

            vy += g;
        }

        public bool AtTheTop()
        {
            return centerY < form.ClientSize.Height / 3;
        }        
    }
}
