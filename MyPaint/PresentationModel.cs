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
        public delegate void ModelChangeHandler();
        public event ModelChangeHandler _modelChanged;

        State _state;

        //model changed event
        public void ChangeModel()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        //constructor of presentation model
        public PresentationModel(PaintModel paintModel)
        {
            PaintModel = paintModel;
            paintModel._propertyChanged += ChangeModel;
            _state = new PointerState(this);
        }
        
        //press pointer
        public void PressPointer(Point point)
        {
            _state.TouchDown(point);
        }

        //move pointer
        public void MovePointer(Point point)
        {
            _state.TouchMove(point);
        }

        //release pointer
        public void ReleasePointer(Point point)
        {
            _state.TouchUp(point);
        }

        //disable all buttons and using pointer mode
        public void ClickPointerButton()
        {
            EnableButtons();
            IsPointerButtonEnable = false;
            _state = new PointerState(this);
            ChangeState();
        }

        //disable all buttons and using ellipse mode
        public void ClickEllipseButton()
        {
            EnableButtons();
            IsEllipseButtonEnable = false;
            DrawState drawState = new DrawState(this);
            drawState.ShapeEnum = MyPaint.PaintModel.ShapeEnum.Ellipse;
            _state = drawState;
            ChangeState();
        }

        //disable all buttons and using rectangle mode
        public void ClickRectangleButton()
        {
            EnableButtons();
            IsRectangleButtonEnable = false;
            DrawState drawState = new DrawState(this);
            drawState.ShapeEnum = MyPaint.PaintModel.ShapeEnum.Rectangle;
            _state = drawState;
            ChangeState();
        }

        //a method for one click adding a shape fixed width and height = 50
        public void ClickMouse(Point point)
        {

            //const int WIDTH = 50;
            //Point newPoint = new Point(point.X + WIDTH, point.Y + WIDTH);
            //Shape shape = null;
            //switch (NowDrawMode)
            //{
            //    case DrawMode.None:
            //        break;
            //    case DrawMode.Pointer:
            //        break;
            //    case DrawMode.Ellipse:
            //        shape = ShapeFactory.GetShape(PaintModel.ShapeEnum.Ellipse, point, newPoint);
            //        PaintModel.AddShape(shape);
            //        break;
            //    case DrawMode.Rectangle:
            //        shape = ShapeFactory.GetShape(PaintModel.ShapeEnum.Rectangle, point, newPoint);
            //        PaintModel.AddShape(shape);
            //        break;
            //    default:
            //        break;
            //}
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

        //draw all shapes
        public void DrawShapes(IGraphics graphics)
        {
            PaintModel.DrawShapes(graphics);
        }
    }
}
