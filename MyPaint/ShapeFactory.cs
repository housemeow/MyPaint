using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Shapes;
using MyPaint;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace MyPaint
{
    public class ShapeFactory
    {
        //a factory method to get a shape
        public static Shape GetShape(PaintModel.ShapeEnum shapeType)
        {
            const String NAMESPACE = "MyPaint.";
            String className = shapeType.ToString();
            Type type = Type.GetType(NAMESPACE + className);
            Shape shape = (Shape)Activator.CreateInstance(type);
            return shape;
        }

        ////a factory method to get a shape
        //public static Shape GetShape(PaintModel.ShapeEnum shapeType, Point startPoint, Point endPoint)
        //{
        //    Shape shape = null;
        //    switch (shapeType)
        //    {
        //        case PaintModel.ShapeEnum.Line:
        //            Line line = GetLine(ref startPoint, ref endPoint);
        //            shape = line;
        //            break;
        //        case PaintModel.ShapeEnum.Ellipse:
        //            GetEllipse(ref startPoint, ref endPoint, ref shape);
        //            break;
        //        case PaintModel.ShapeEnum.Rectangle:
        //            GetRectangle(ref startPoint, ref endPoint, ref shape);
        //            break;
        //        default:
        //            break;
        //    }
        //    return shape;
        //}

        ////get rectangle
        //private static void GetRectangle(ref Point startPoint, ref Point endPoint, ref Shape shape)
        //{
        //    Rectangle rectangle = new Rectangle();
        //    rectangle.Fill = new SolidColorBrush(Colors.Green);
        //    double width = Math.Abs(endPoint.X - startPoint.X);
        //    rectangle.Width = width;
        //    double height = Math.Abs(endPoint.Y - startPoint.Y);
        //    rectangle.Height = height;
        //    Canvas.SetLeft(rectangle, (startPoint.X < endPoint.X ? startPoint.X : endPoint.X) - width / 2);
        //    Canvas.SetTop(rectangle, (startPoint.Y < endPoint.Y ? startPoint.Y : endPoint.Y) - height / 2);
        //    shape = rectangle;
        //}

        ////get ellipse
        //private static void GetEllipse(ref Point startPoint, ref Point endPoint, ref Shape shape)
        //{
        //    Ellipse ellipse = new Ellipse();
        //    ellipse.Fill = new SolidColorBrush(Colors.Blue);
        //    double width = Math.Abs(endPoint.X - startPoint.X);
        //    ellipse.Width = width;
        //    double height = Math.Abs(endPoint.Y - startPoint.Y);
        //    ellipse.Height = height;
        //    Canvas.SetLeft(ellipse, (startPoint.X < endPoint.X ? startPoint.X : endPoint.X) - width / 2);
        //    Canvas.SetTop(ellipse, (startPoint.Y < endPoint.Y ? startPoint.Y : endPoint.Y) - height / 2);
        //    shape = ellipse;
        //}

        ////get a line from start point and end point
        //private static Line GetLine(ref Point startPoint, ref Point endPoint)
        //{
        //    Line line = new Line();
        //    line.X1 = startPoint.X;
        //    line.Y1 = startPoint.Y;
        //    line.X2 = endPoint.X;
        //    line.Y2 = endPoint.Y;
        //    return line;
        //}
    }
}
