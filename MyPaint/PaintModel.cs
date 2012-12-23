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
        public void Add(Shape shape)
        {
            Shapes.Add(shape);
            ChangeModel();
        }

        //remove a shape from shape list
        public bool Remove(Shape shape)
        {
            bool removeResult = Shapes.Remove(shape);
            ChangeModel();
            return removeResult;
        }

        //clear shapes
        public void Clear()
        {
            Shapes.Clear();
            ChangeModel();
        }

        #region SelectStateMethod
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
                Remove(operationShape);
                operationShape.IsSelected = true;
                ChangeModel();
            }
        }

        //move selected shape
        public void MoveSelectedShape(Point point)
        {
            if (operationShape != null)
            {
                Point movePoint;
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
        public void EndSelecteShape(Point point)
        {
            if (operationShape != null)
            {
                Add(operationShape);
                operationShape.IsSelected = false;
                operationShape = null;
                ChangeModel();
            }
        }
        #endregion

        #region CreateStateMethod
        //start create shape
        public void StartCreateShape(ShapeEnum shapeEnum, Point point)
        {
            operationShape = ShapeFactory.GetShape(shapeEnum);
            operationShape.SetPoints(point, point);
            startPoint = point;
            ChangeModel();
        }

        //resize create shape
        public void ResizeShape(Point point)
        {
            operationShape.SetPoints(startPoint, point);
            ChangeModel();
        }

        //stop resize shape
        public void EndCreateShape(Point point)
        {
            Add(operationShape);
            operationShape = null;
            ChangeModel();
        }
        #endregion

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

        //model changed event
        private void ChangeModel()
        {
            if (_propertyChanged != null)
            {
                _propertyChanged();
            }
        }
    }
}
