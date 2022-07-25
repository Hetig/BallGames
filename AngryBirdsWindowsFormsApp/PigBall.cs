using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngryBirdsWindowsFormsApp
{
    public class PigBall:BirdBall
    {
        public PigBall(Form form):base(form)
        {
            brush = Brushes.Green;
            centerX = form.ClientSize.Width / 2;
            centerY = form.ClientSize.Height / 2;
        }

        public override void TakeStandartPosition()
        {
            g = 0.0f;

            vx = 0;
            vy = 0;

            centerX = form.ClientSize.Width / 2;
            centerY = form.ClientSize.Height / 2;

            Start();
        }        
    }
}
