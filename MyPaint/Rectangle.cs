using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    public class Rectangle : Shape
    {
        //rectangle draw
        protected override void DoDrawShape(IGraphics graphics)
        {
            graphics.DrawRectangle(TopLeftPoint, BottomRightPoint);
        }
    }
}
