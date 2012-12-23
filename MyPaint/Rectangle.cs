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
        public override void DrawShape(IGraphics graphics)
        {
            graphics.DrawRectangle(TopLeftPoint, BottomRightPoint);
        }
    }
}
