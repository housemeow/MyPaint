using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace MyPaint
{
    public class State
    {
        protected PresentationModel _pModel;
        protected Point _startPoint;
        protected Boolean _isPressed;

        //constructor state
        protected State(PresentationModel pModel)
        {
            _pModel = pModel;
            _isPressed = false;
        }

        //a virtual function touch down
        public virtual void PressPointer(Point point)
        {
            _isPressed = true;
        }

        // a virtual function touch move
        public virtual void MovePointer(Point point)
        {
        }

        //a virtual function touch up
        public virtual void ReleasePointer(Point point)
        {
            _isPressed = false;
        }
    }
}
