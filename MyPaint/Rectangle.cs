using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class MyRectangle : MyShape
    {
        //rectangle draw
        protected override void DoDrawShape(IGraphics graphics)
        {
            graphics.DrawRectangle(TopLeftPoint, BottomRightPoint);
        }
    }
}
