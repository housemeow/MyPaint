using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation;
using MyPaint;
using Windows.UI.Xaml.Shapes;

namespace MyPaint
{
    public class PresentationModel : PresentationModelProperty
    {
        public delegate void StateChangeHandler();
        public event StateChangeHandler _stateChanged;

        //constructor of presentation model
        public PresentationModel(PaintModel paintModel)
        {
            PaintModel = paintModel;
        }

        //disable all buttons and using pointer mode
        public void ClickPointerButton()
        {
            EnableButtons();
            IsPointerButtonEnable = false;
            NowDrawMode = DrawMode.Pointer;
            ChangeState();
        }

        //disable all buttons and using ellipse mode
        public void ClickEllipseButton()
        {
            EnableButtons();
            IsEllipseButtonEnable = false;
            NowDrawMode = DrawMode.Ellipse;
            ChangeState();
        }

        //disable all buttons and using rectangle mode
        public void ClickRectangleButton()
        {
            EnableButtons();
            IsRectangleButtonEnable = false;
            NowDrawMode = DrawMode.Rectangle;
            ChangeState();
        }

        //a method for one click adding a shape fixed width and height = 50
        public void ClickMouse(Point point)
        {
            const int WIDTH = 50;
            Point newPoint = new Point(point.X + WIDTH, point.Y + WIDTH);
            Shape shape = null;
            switch (NowDrawMode)
            {
                case DrawMode.None:
                    break;
                case DrawMode.Pointer:
                    break;
                case DrawMode.Ellipse:
                    shape = ShapeFactory.GetShape(PaintModel.ShapeEnum.Ellipse, point, newPoint);
                    PaintModel.AddShape(shape);
                    break;
                case DrawMode.Rectangle:
                    shape = ShapeFactory.GetShape(PaintModel.ShapeEnum.Rectangle, point, newPoint);
                    PaintModel.AddShape(shape);
                    break;
                default:
                    break;
            }
        }

        //get shapes from paint model
        public List<Shape> GetShapes()
        {
            return PaintModel.Shapes;
        }

        //state changed event trigger
        private void ChangeState()
        {
            if (_stateChanged != null)
            {
                _stateChanged();
            }
        }

        //click clear button
        public void ClickClearButton()
        {
            PaintModel.Clear();
        }

        //select shape
        public void SelecteShape(Point point)
        {
            PaintModel.SelecteShape(point);
        }

        //move selected shape
        public void MoveSelectedShape(Point point)
        {
            PaintModel.MoveSelectedShape(point);
        }

        //stop moving selected shape
        public void StopMovingSelectedShape(Point point)
        {
            PaintModel.StopMovingSelectedShape(point);
        }

        //start create shape
        public void StartCreateShape(MyPaint.PaintModel.ShapeEnum shapeEnum, Point point)
        {
            PaintModel.StartCreateShape(shapeEnum, point);
        }

        //resize create shape
        public void ResizeCreateShape(Point point)
        {
            PaintModel.ResizeCreateShape(point);
        }

        //stop resize shape
        public void StopResizeShape(Point point)
        {
            PaintModel.StopResizeShape(point);
        }
    }
}
