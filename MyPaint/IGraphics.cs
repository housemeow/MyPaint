using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace MyPaint
{
    public abstract class IGraphics
    {
        protected Canvas _canvas;

        //constructor of IGraphics
        protected IGraphics(Canvas canvas)
        {
            _canvas = canvas;
        }

        //draw rectangle with template method
        public Boolean DrawRectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            try
            {
                DoDrawRectangle(topLeftPoint, bottomRightPoint);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //abstract method to do draw rectangle
        protected abstract void DoDrawRectangle(Point topLeftPoint, Point bottomRightPoint);

        //draw ellipse with template method
        public Boolean DrawEllipse(Point topLeftPoint, Point bottomRightPoint)
        {
            try
            {
                DoDrawEllipse(topLeftPoint, bottomRightPoint);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //abstract method to do draw ellipse
        protected abstract void DoDrawEllipse(Point topLeftPoint, Point bottomRightPoint);

        //draw ellipse with template method
        public Boolean DrawBorder(Point topLeftPoint, Point bottomRightPoint)
        {
            try
            {
                DoBorderRectangle(topLeftPoint, bottomRightPoint);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //abstract method to do draw border
        protected abstract void DoBorderRectangle(Point topLeftPoint, Point bottomRightPoint);

        //clear
        public void ClearCanvas()
        {
            _canvas.Children.Clear();
        }
    }
}
