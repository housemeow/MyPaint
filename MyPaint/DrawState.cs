using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class DrawState : State
    {
        public MyPaint.PaintModel.ShapeEnum ShapeEnum
        {
            get;
            set;
        }
        
        //constructor of pointer state
        public DrawState(PresentationModel pModel)
            : base(pModel)
        {
        }

        //pointer state touch down method
        public override void TouchDown(Windows.Foundation.Point point)
        {
            _pModel.StartCreateShape(ShapeEnum, point);
            base.TouchDown(point);
        }

        //pointer state touch move method
        public override void TouchMove(Windows.Foundation.Point point)
        {
            _pModel.ResizeCreateShape(point);
            base.TouchMove(point);
        }

        //pointer state touch up method
        public override void TouchUp(Windows.Foundation.Point point)
        {
            _pModel.StopResizeShape(point);
            base.TouchUp(point);
        }
    }
}
