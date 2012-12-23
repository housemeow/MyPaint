using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace MyPaint
{
    public class Shape
    {
        private Point _firstPoint, _secondPoint;

        //constructor of shape
        public Shape()
        {
            _firstPoint = _secondPoint = new Point(0, 0);
        }

        //set first point and second point
        public void SetPoints(Point firstPoint, Point secondPoint)
        {
            _firstPoint = firstPoint;
            _secondPoint = secondPoint;
        }

        //using a list to set points
        public virtual void SetPoints(List<Point> points)
        {
            const int NORMAL_POINT_COUNT = 2;
            if (points.Count == NORMAL_POINT_COUNT)
            {
                SetPoints(points[0], points[1]);
            }
        }

        //draw shape method
        public void DrawShape(IGraphics graphics)
        {
            DoDrawShape(graphics);
            if (IsSelected)
            {
                graphics.DrawBorder(TopLeftPoint, BottomRightPoint);
            }
        }

        //a virutal function to draw shape
        protected virtual void DoDrawShape(IGraphics graphics)
        {
        }

        //check if point is in shape
        public virtual Boolean CheckIsSelected(Point point)
        {
            Rect rect = new Rect(TopLeftPoint, BottomRightPoint);
            return rect.Contains(point);
        }

        public Boolean IsSelected
        {
            get;
            set;
        }

        public Point TopLeftPoint
        {
            get
            {
                Point topLeftPoint;
                topLeftPoint.X = _firstPoint.X < _secondPoint.X ? _firstPoint.X : _secondPoint.X;
                topLeftPoint.Y = _firstPoint.Y < _secondPoint.Y ? _firstPoint.Y : _secondPoint.Y;
                return topLeftPoint;
            }
        }

        public Point BottomRightPoint
        {
            get
            {
                Point bottomRightPoint;
                bottomRightPoint.X = _firstPoint.X > _secondPoint.X ? _firstPoint.X : _secondPoint.X;
                bottomRightPoint.Y = _firstPoint.Y > _secondPoint.Y ? _firstPoint.Y : _secondPoint.Y;
                return bottomRightPoint;
            }
        }
    }
}
