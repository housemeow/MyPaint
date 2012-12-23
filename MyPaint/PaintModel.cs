using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml.Shapes;

namespace MyPaint
{
    public class PaintModel
    {
        public delegate void ModelChangedHandler();
        public event ModelChangedHandler _propertyChanged;

        Point startPoint;
        MyShape operationShape;


        //drawing shape type 
        public enum ShapeEnum
        {
            None,
            Line,
            Ellipse,
            Rectangle
        }

        //constructor of paint model
        public PaintModel()
        {
            Shapes = new List<Shape>();
            MyShapes = new List<MyShape>();
            operationShape = null;
        }

        public List<MyShape> MyShapes
        {
            get;
            set;
        }

        public List<Shape> Shapes
        {
            get;
            set;
        }

        //add a shape into shape list
        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
            ChangeModel();
        }

        //clear shapes
        public void Clear()
        {
            Shapes.Clear();
            ChangeModel();
        }

        //remove a shape from shape list
        public bool Remove(Shape shape)
        {
            bool removeResult = Shapes.Remove(shape);
            ChangeModel();
            return removeResult;
        }

        //model changed event
        private void ChangeModel()
        {
            if (_propertyChanged != null)
            {
                _propertyChanged();
            }
        }

        //select shape
        public void SelecteShape(Point point)
        {
            foreach (MyShape shape in MyShapes)
            {
                if(shape.CheckIsSelected(point)){
                    operationShape = shape;
                    break;  
                }
            }
            startPoint = point;
            RemoveShape(operationShape);
            
        }

        //move selected shape
        public void MoveSelectedShape(Point point)
        {
            Point movePoint;// = point - startPoint;
            movePoint.X = point.X - startPoint.X;
            movePoint.Y = point.Y - startPoint.Y;
            Point newTopLeftPoint;
            newTopLeftPoint.X = operationShape.TopLeftPoint.X + movePoint.X;
            newTopLeftPoint.Y = operationShape.TopLeftPoint.Y + movePoint.Y;
            Point newBottomRightPoint;
            newBottomRightPoint.X = operationShape.BottomRightPoint.X + movePoint.X;
            newBottomRightPoint.Y = operationShape.BottomRightPoint.Y + movePoint.Y;
            operationShape.SetPoints(newTopLeftPoint, newBottomRightPoint);
        }

        //stop moving selected shape
        public void StopMovingSelectedShape(Point point)
        {
            AddShape(operationShape);
            operationShape = null;
        }

        //start create shape
        public void StartCreateShape(ShapeEnum shapeEnum, Point point)
        {
            operationShape = ShapeFactory.GetShape(shapeEnum);
            operationShape.SetPoints(point, point);
            startPoint = point;
        }

        //resize create shape
        public void ResizeCreateShape(Point point)
        {
            operationShape.SetPoints(startPoint, point);
        }

        //stop resize shape
        public void StopResizeShape(Point point)
        {
            AddShape(operationShape);
            operationShape = null;
        }

        //draw Shapes
        public void DrawShapes(IGraphics graphics)
        {
            foreach (MyShape shape in MyShapes)
            {
                shape.DrawShape(graphics);
            }
            operationShape.DrawShape(graphics);
        }

        //remove shape
        private void RemoveShape(MyShape shape)
        {
            MyShapes.Remove(shape);
        }

        //add shape
        private void AddShape(MyShape shape)
        {
            MyShapes.Add(shape);
        }
    }
}
