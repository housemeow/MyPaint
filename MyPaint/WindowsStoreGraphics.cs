using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace MyPaint
{
    public class WindowsStoreGraphics : IGraphics
    {
        //windows store graphics constructor
        public WindowsStoreGraphics(Canvas canvas)
            : base(canvas)
        {
        }

        //draw a ellipse using windows store graphics
        protected override void DoDrawEllipse(Point topLeftPoint, Point bottomRightPoint)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Fill = new SolidColorBrush(Colors.Blue);
            ellipse.Width = bottomRightPoint.X - topLeftPoint.X;
            ellipse.Height = bottomRightPoint.Y - topLeftPoint.Y;
            Canvas.SetLeft(ellipse, topLeftPoint.X);
            Canvas.SetTop(ellipse, topLeftPoint.Y);
            _canvas.Children.Add(ellipse);
        }

        //draw a rectangle using windows store graphics
        protected override void DoDrawRectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Fill = new SolidColorBrush(Colors.Green);
            rectangle.Width = bottomRightPoint.X - topLeftPoint.X;
            rectangle.Height = bottomRightPoint.Y - topLeftPoint.Y;
            Canvas.SetLeft(rectangle, topLeftPoint.X);
            Canvas.SetTop(rectangle, topLeftPoint.Y);
            _canvas.Children.Add(rectangle);
        }

        //draw a border using windows store graphics
        protected override void DoBorderRectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = bottomRightPoint.X - topLeftPoint.X;
            rectangle.Height = bottomRightPoint.Y - topLeftPoint.Y;
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(rectangle, topLeftPoint.X);
            Canvas.SetTop(rectangle, topLeftPoint.Y);
            _canvas.Children.Add(rectangle);
        }

    }
}
