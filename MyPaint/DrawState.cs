using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    public class DrawState : State
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
        public override void PressPointer(Windows.Foundation.Point point)
        {
            base.PressPointer(point);
            _pModel.StartCreateShape(ShapeEnum, point);
        }

        //pointer state touch move method
        public override void MovePointer(Windows.Foundation.Point point)
        {
            base.MovePointer(point);
            if (_isPressed)
            {
                _pModel.ResizeShape(point);
            }
        }

        //pointer state touch up method
        public override void ReleasePointer(Windows.Foundation.Point point)
        {
            base.ReleasePointer(point);
            _pModel.EndCreateShape(point);
        }
    }
}
