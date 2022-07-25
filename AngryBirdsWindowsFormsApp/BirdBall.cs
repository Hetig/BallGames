using Balls.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngryBirdsWindowsFormsApp
{
    public class BirdBall : MoveBall
    {
        protected float g = 0.0f;
        protected float elastic = 0.4f;
        public BirdBall(Form form) : base(form)
        {
            vx = 0;
            vy = 0;
            radius = 15;

            centerX = 2 * radius;
            centerY = form.ClientSize.Height - 2 * radius;
        }

        protected override void Go()
        {
            centerX += vx;
            centerY += vy;

            vy += g;

            if (centerY >= DownSide())
            {                
                vy = -Math.Abs(vy * elastic);                
            }
        }

        public override void Move()
        {
            base.Move();           

            if (Math.Abs(vy) <= 0.25f && vy!=0 || !OnForm())
            {
                Stop();
                Clear();
                TakeStandartPosition();
            }
        }

        public void Throw(int pointX, int pointY)
        {
            g = 2.0f;

            vx = pointX / 10;
            vy = -(form.ClientSize.Height - pointY) / 10;
        }

        public virtual void TakeStandartPosition()
        {
            g = 0.0f;

            vx = 0;
            vy = 0;

            centerX = 2 * radius;
            centerY = form.ClientSize.Height - 2 * radius;

            Start();
        }

        public override bool OnForm()
        {
            return centerX >= LeftSide() && centerX <= RightSide() && centerY >= UpSide();
        }
    }
}
