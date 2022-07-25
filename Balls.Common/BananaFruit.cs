using Balls.Common;
using System.Drawing;
using System.Windows.Forms;

namespace FruitNinjaWindowsFormsApp
{
    public class BananaFruit : FruitBall
    {
        public BananaFruit(Form form) : base(form)
        {
            brush = new SolidBrush(Color.Yellow);
        }
    }
}
