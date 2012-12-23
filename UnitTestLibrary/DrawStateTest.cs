using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyPaint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace UnitTestLibrary
{
    [TestClass]
    public class DrawStateTest
    {
        private DrawState _drawState;
        private PresentationModel _pModel;

        [TestInitialize]
        public void Initialize()
        {
            _pModel = new PresentationModel(new PaintModel());
            _drawState = new DrawState(_pModel);
            _drawState.ShapeEnum = PaintModel.ShapeEnum.Rectangle;
        }

        [TestMethod]
        public void TestPressPointer()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            _drawState.PressPointer(new Point(50, 50));
            Assert.AreEqual(1, triggerTime);
        }

        [TestMethod]
        public void TestMovePointer()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            _drawState.PressPointer(new Point(50, 50));
            _drawState.MovePointer(new Point(100, 100));
            Assert.AreEqual(2, triggerTime);
        }

        [TestMethod]
        public void TestReleasePointer()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            _drawState.PressPointer(new Point(50, 50));
            _drawState.MovePointer(new Point(100, 100));
            _drawState.ReleasePointer(new Point(25, 25));
            Assert.AreEqual(3, triggerTime);
            Shape shape = _pModel.PaintModel.Shapes[0];
            Assert.AreEqual(25, shape.TopLeftPoint.X);
            Assert.AreEqual(25, shape.TopLeftPoint.Y);
            Assert.AreEqual(50, shape.BottomRightPoint.X);
            Assert.AreEqual(50, shape.BottomRightPoint.Y);
        }
    }
}
