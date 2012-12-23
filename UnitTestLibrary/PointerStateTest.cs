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
    public class PointerStateTest
    {
        private PointerState _pointerState;
        private PresentationModel _pModel;

        [TestInitialize]
        public void Initialize()
        {
            _pModel = new PresentationModel(new PaintModel());
            _pointerState = new PointerState(_pModel);
        }

        [TestMethod]
        public void TestPressPointer()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            _pointerState.PressPointer(new Point(50, 50));
            Assert.AreEqual(0, triggerTime);
            Shape ellipse = new Ellipse();
            ellipse.SetPoints(new Point(0, 0), new Point(100, 100));
            _pModel.PaintModel.Add(ellipse);
            Assert.AreEqual(1, triggerTime);
            _pointerState.PressPointer(new Point(50, 50));
            Assert.AreEqual(2, triggerTime);
        }

        [TestMethod]
        public void TestMovePointer()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            Shape ellipse = new Ellipse();
            ellipse.SetPoints(new Point(0, 0), new Point(100, 100));
            _pModel.PaintModel.Add(ellipse);
            _pointerState.PressPointer(new Point(50, 50));
            _pointerState.MovePointer(new Point(100, 50));
            Assert.AreEqual(3, triggerTime);
            _pointerState.ReleasePointer(new Point(100, 50));
            Assert.AreEqual(50, ellipse.TopLeftPoint.X);
            Assert.AreEqual(0, ellipse.TopLeftPoint.Y);
            Assert.AreEqual(150, ellipse.BottomRightPoint.X);
            Assert.AreEqual(100, ellipse.BottomRightPoint.Y);
        }

        [TestMethod]
        public void TestReleasePointer()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            Shape ellipse = new Ellipse();
            ellipse.SetPoints(new Point(0, 0), new Point(100, 100));
            _pModel.PaintModel.Add(ellipse);
            _pointerState.PressPointer(new Point(50, 50));
            _pointerState.MovePointer(new Point(100, 50));
            _pointerState.ReleasePointer(new Point(100, 100));
            Assert.AreEqual(4, triggerTime);
            Assert.AreEqual(50, ellipse.TopLeftPoint.X);
            Assert.AreEqual(50, ellipse.TopLeftPoint.Y);
            Assert.AreEqual(150, ellipse.BottomRightPoint.X);
            Assert.AreEqual(150, ellipse.BottomRightPoint.Y);
        }
    }
}
