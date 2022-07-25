using Balls.Common;
using System;
using System.Windows.Forms;

namespace Balls.Common
{
    public class MoveBall : RandomPointBall
    {
        public MoveBall(Form form) : base(form)
        {
            vx += random.Next(-5, 6);
            vy += random.Next(-5, 6);

            while (vx == 0)
            {
                vx += random.Next(-5, 6);
            }

            while (vy == 0)
            {
                vy += random.Next(-5, 6);
            }
        }                             
    }
}
