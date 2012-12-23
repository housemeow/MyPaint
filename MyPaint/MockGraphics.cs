using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace MyPaint
{
    public class MockGraphics : IGraphics
    {
        //mock object constructor
        public MockGraphics(Canvas canvas)
            : base(canvas)
        {
        }

        //draw ellipse
        protected override void DoDrawEllipse(Point topLeftPoint, Point bottomRightPoint)
        {
        }

        //draw rectangle
        protected override void DoDrawRectangle(Point topLeftPoint, Point bottomRightPoint)
        {
        }
    }
}
