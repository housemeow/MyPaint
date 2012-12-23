using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace MyPaint
{
    class Ellipse : Shape
    {
        //rectangle draw
        protected override void DoDrawShape(IGraphics graphics)
        {
            graphics.DrawEllipse(TopLeftPoint, BottomRightPoint);
        }

        //ellipse selected
        public override bool CheckIsSelected(Windows.Foundation.Point point)
        {
            Point centerPoint;
            centerPoint.X = (BottomRightPoint.X + TopLeftPoint.X) / 2;
            centerPoint.Y = (BottomRightPoint.Y + TopLeftPoint.Y) / 2;
            double halfWidth = (TopLeftPoint.X- BottomRightPoint.X)/2;
            double halfHeight = (TopLeftPoint.Y-BottomRightPoint.Y)/2;
            double xRadius = Math.Pow((point.X - centerPoint.X) / halfWidth, 2);
            double yRadius = Math.Pow((point.Y - centerPoint.Y)/halfHeight, 2);
            return xRadius + yRadius <= 1;
        }
    }
}
