using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation;

namespace MyPaint
{
    public class PaintModel
    {
        public delegate void ModelChangedHandler();
        public event ModelChangedHandler _propertyChanged;

        Point startPoint;
        Point shapeOriginTopLeftPoint;
        Point shapeOriginBottomRightPoint;
        Shape operationShape;

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
            operationShape = null;
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
            foreach (Shape shape in Shapes)
            {
                if (shape.CheckIsSelected(point))
                {
                    operationShape = shape;
                    break;
                }
            }
            if (operationShape != null)
            {
                startPoint = point;
                shapeOriginTopLeftPoint = operationShape.TopLeftPoint;
                shapeOriginBottomRightPoint = operationShape.BottomRightPoint;
                RemoveShape(operationShape);
                ChangeModel();
            }
        }

        //move selected shape
        public void MoveSelectedShape(Point point)
        {
            if (operationShape != null)
            {
                Point movePoint;// = point - startPoint;
                movePoint.X = point.X - startPoint.X;
                movePoint.Y = point.Y - startPoint.Y;
                Point newTopLeftPoint;
                newTopLeftPoint.X = shapeOriginTopLeftPoint.X + movePoint.X;
                newTopLeftPoint.Y = shapeOriginTopLeftPoint.Y + movePoint.Y;
                Point newBottomRightPoint;
                newBottomRightPoint.X = shapeOriginBottomRightPoint.X + movePoint.X;
                newBottomRightPoint.Y = shapeOriginBottomRightPoint.Y + movePoint.Y;
                operationShape.SetPoints(newTopLeftPoint, newBottomRightPoint);
                ChangeModel();
            }
        }

        //stop moving selected shape
        public void StopMovingSelectedShape(Point point)
        {
            if (operationShape != null)
            {
                AddShape(operationShape);
                operationShape = null;
                ChangeModel();
            }
        }

        //start create shape
        public void StartCreateShape(ShapeEnum shapeEnum, Point point)
        {
            operationShape = ShapeFactory.GetShape(shapeEnum);
            operationShape.SetPoints(point, point);
            startPoint = point;
            ChangeModel();
        }

        //resize create shape
        public void ResizeCreateShape(Point point)
        {
            operationShape.SetPoints(startPoint, point);
            ChangeModel();
        }

        //stop resize shape
        public void StopResizeShape(Point point)
        {
            AddShape(operationShape);
            operationShape = null;
            ChangeModel();
        }

        //draw Shapes
        public void DrawShapes(IGraphics graphics)
        {
            graphics.ClearCanvas();
            foreach (Shape shape in Shapes)
            {
                shape.DrawShape(graphics);
            }
            if (operationShape != null)
            {
                operationShape.DrawShape(graphics);
            }
        }

        //remove shape
        private void RemoveShape(Shape shape)
        {
            Shapes.Remove(shape);
        }
    }
}
