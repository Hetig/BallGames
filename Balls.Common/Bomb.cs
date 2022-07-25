using Balls.Common;
using System.Drawing;
using System.Windows.Forms;

namespace FruitNinjaWindowsFormsApp
{
    public class Bomb : FruitBall
    {
        public Bomb(Form form) : base(form)
        {
            brush = new SolidBrush(Color.Black);
        }
    }
}
