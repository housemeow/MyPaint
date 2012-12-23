using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace MyPaint
{
    public class ExceptionGraphis:IGraphics
    {
        //exception object constructor
        public ExceptionGraphis(Canvas canvas)
            : base(canvas)
        {
        }

        //draw ellipse
        protected override void DoDrawEllipse(Windows.Foundation.Point topLeftPoint, Windows.Foundation.Point bottomRightPoint)
        {
            throw new Exception();
        }

        //draw rectangle
        protected override void DoDrawRectangle(Windows.Foundation.Point topLeftPoint, Windows.Foundation.Point bottomRightPoint)
        {
            throw new Exception();
        }

        //draw border
        protected override void DoBorderRectangle(Windows.Foundation.Point topLeftPoint, Windows.Foundation.Point bottomRightPoint)
        {
            throw new Exception();
        }
    }
}
