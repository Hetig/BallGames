using Balls.Common;
using System;
using System.Windows.Forms;

namespace Balls.Common
{
    public class RandomPointBall : Ball
    {
        protected static Random random = new Random();

        public RandomPointBall(Form form) : base(form)
        {
            centerX = random.Next(LeftSide(), RightSide());
            centerY = random.Next(UpSide(), DownSide());
        }
    }
}
