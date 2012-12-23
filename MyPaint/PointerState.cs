using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    public class PointerState : State
    {
        //constructor of pointer state
        public PointerState(PresentationModel pModel)
            : base(pModel)
        {
        }

        //pointer state touch down method
        public override void TouchDown(Windows.Foundation.Point point)
        {
            _pModel.SelecteShape(point);
            base.TouchDown(point);
        }

        //pointer state touch move method
        public override void TouchMove(Windows.Foundation.Point point)
        {
            _pModel.MoveSelectedShape(point);
            base.TouchMove(point);
        }

        //pointer state touch up method
        public override void TouchUp(Windows.Foundation.Point point)
        {
            _pModel.StopMovingSelectedShape(point);
            base.TouchUp(point);
        }
    }
}
