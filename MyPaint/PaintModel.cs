using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Shapes;

namespace MyPaint
{
    public class PaintModel
    {
        public delegate void ModelChangedHandler();
        public event ModelChangedHandler _propertyChanged;

        //drawing shape type 
        public enum ShapeType
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
    }
}
