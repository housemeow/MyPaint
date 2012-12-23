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
        protected Point startPoint;

        //constructor state
        protected State(PresentationModel pModel)
        {
            _pModel = pModel;
        }

        //a virtual function touch down
        public virtual void TouchDown(Point point)
        {
        }

        // a virtual function touch move
        public virtual void TouchMove(Point point)
        {
        }

        //a virtual function touch up
        public virtual void TouchUp(Point point)
        {
        }
    }
}
