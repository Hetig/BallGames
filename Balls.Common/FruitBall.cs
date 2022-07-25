using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balls.Common
{
    public class FruitBall : MoveBall
    {
        protected float g = 0.8f;
        public FruitBall(Form form) : base(form)
        {
            radius = random.Next(15, 20);
            centerY = DownSide();
            centerX = random.Next(LeftSide(), RightSide());

            vy = -20;
            vx = random.Next(-2, 3);
            timer.Interval = 35;
        }

        protected override void Go()
        {
            base.Go();

            vy += g;

            if (centerY > DownSide() + 2 * radius)
            {
                Stop();
            }
        }
    }
}
