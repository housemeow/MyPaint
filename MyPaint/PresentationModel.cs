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
        public void MouseClick(Point point)
        {
            Point newPoint = new Point(point.X + 50, point.Y + 50);
            Shape shape = null;
            switch (NowDrawMode)
            {
                case DrawMode.None:
                    break;
                case DrawMode.Pointer:
                    break;
                case DrawMode.Ellipse:
                    shape = ShapeFactory.GetShape(PaintModel.ShapeType.Ellipse, point, newPoint);
                    PaintModel.AddShape(shape);
                    break;
                case DrawMode.Rectangle:
                    shape = ShapeFactory.GetShape(PaintModel.ShapeType.Rectangle, point, newPoint);
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

        //state changed
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
    }
}
