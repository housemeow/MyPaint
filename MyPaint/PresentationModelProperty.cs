using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Shapes;

namespace MyPaint
{
    public class PresentationModelProperty
    {
        //a enumeration about draw mode
        public enum DrawMode
        {
            None,
            Pointer,
            Ellipse,
            Rectangle
        }

        //presentation model property constructor.
        public PresentationModelProperty()
        {
            IsPointerButtonEnable = false;
            IsEllipseButtonEnable = true;
            IsRectangleButtonEnable = true;
            IsDrawing = false;
            NowDrawMode = DrawMode.Pointer;
        }

        public bool IsPointerButtonEnable
        {
            get;
            set;
        }

        public bool IsRectangleButtonEnable
        {
            get;
            set;
        }

        public bool IsEllipseButtonEnable
        {
            get;
            set;
        }

        public bool IsDrawing
        {
            get;
            set;
        }

        public DrawMode NowDrawMode
        {
            get;
            set;
        }

        public PaintModel PaintModel
        {
            get;
            set;
        }

        //disable all button
        public void EnableButtons()
        {
            IsPointerButtonEnable = true;
            IsEllipseButtonEnable = true;
            IsRectangleButtonEnable = true;
            NowDrawMode = DrawMode.None;
        }
    }
}
