using System.Windows.Forms;

namespace Balls.Common
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(Form form) : base(form)
        {
            radius = random.Next(10, 70);
        }
    }
}
