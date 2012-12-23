using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class MyEllipse : MyShape
    {
        //rectangle draw
        protected override void DoDrawShape(IGraphics graphics)
        {
            graphics.DrawEllipse(TopLeftPoint, BottomRightPoint);
        }
    }
}
