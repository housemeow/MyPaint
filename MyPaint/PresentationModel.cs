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

        //constructor of presentation model
        public PresentationModel(PaintModel paintModel)
        {
            PaintModel = paintModel;
            paintModel._propertyChanged += ChangeModel;
            _state = new PointerState(this);//default state
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

        //click clear button
        public void ClickClearButton()
        {
            PaintModel.Clear();
        }

        #region PointerRegion
        //press pointer
        public void PressPointer(Point point)
        {
            _state.PressPointer(point);
        }

        //move pointer
        public void MovePointer(Point point)
        {
            _state.MovePointer(point);
        }

        //release pointer
        public void ReleasePointer(Point point)
        {
            _state.ReleasePointer(point);
        }
        #endregion

        #region PointerMethod
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
        public void EndSelecteShape(Point point)
        {
            PaintModel.EndSelecteShape(point);
        }
        #endregion

        #region DrawModeMethod
        //start create shape
        public void StartCreateShape(MyPaint.PaintModel.ShapeEnum shapeEnum, Point point)
        {
            PaintModel.StartCreateShape(shapeEnum, point);
        }

        //resize create shape
        public void ResizeShape(Point point)
        {
            PaintModel.ResizeShape(point);
        }

        //stop resize shape
        public void EndCreateShape(Point point)
        {
            PaintModel.EndCreateShape(point);
        }
        #endregion

        //draw all shapes
        public void DrawShapes(IGraphics graphics)
        {
            PaintModel.DrawShapes(graphics);
        }

        //state changed event trigger
        private void ChangeState()
        {
            if (_stateChanged != null)
            {
                _stateChanged();
            }
        }

        //model changed event
        public void ChangeModel()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }
    }
}
