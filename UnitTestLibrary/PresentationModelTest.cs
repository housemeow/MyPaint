using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyPaint;
using Windows.Foundation;

namespace UnitTestLibrary
{
    [TestClass]
    public class PresentationModelTest
    {
        private PresentationModel _pModel;

        [TestInitialize]
        public void Initialize()
        {
            _pModel = new PresentationModel(new PaintModel());
        }

        [TestMethod]
        public void TestClickPointerButton()
        {
            _pModel.ClickPointerButton();
            Assert.IsFalse(_pModel.IsPointerButtonEnable);
            Assert.IsTrue(_pModel.IsEllipseButtonEnable);
            Assert.IsTrue(_pModel.IsRectangleButtonEnable);
        }

        [TestMethod]
        public void TestClickEllipseButton()
        {
            _pModel.ClickEllipseButton();
            Assert.IsTrue(_pModel.IsPointerButtonEnable);
            Assert.IsFalse(_pModel.IsEllipseButtonEnable);
            Assert.IsTrue(_pModel.IsRectangleButtonEnable);
        }

        [TestMethod]
        public void TestClickRectangleButton()
        {
            _pModel.ClickRectangleButton();
            Assert.IsTrue(_pModel.IsPointerButtonEnable);
            Assert.IsTrue(_pModel.IsEllipseButtonEnable);
            Assert.IsFalse(_pModel.IsRectangleButtonEnable);
        }

        [TestMethod]
        public void TestStateChanged()
        {
            int triggerTime = 0;
            _pModel._stateChanged += delegate()
            {
                triggerTime++;
            };
            _pModel.ClickEllipseButton();
            Assert.AreEqual(1, triggerTime);
            _pModel.ClickRectangleButton();
            Assert.AreEqual(2, triggerTime);
            _pModel.ClickPointerButton();
            Assert.AreEqual(3, triggerTime);
        }

        [TestMethod]
        public void TestSelecteShape()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            Shape ellipse = new Ellipse();
            ellipse.SetPoints(new Point(0, 0), new Point(100, 100));
            _pModel.PaintModel.Add(ellipse);
            Point point = new Point(50, 50);
            _pModel.SelecteShape(point);
            Assert.AreEqual(2, triggerTime);
        }

        [TestMethod]
        public void TestMoveSelectedShape()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            Shape ellipse = new Ellipse();
            ellipse.SetPoints(new Point(0, 0), new Point(100, 100));
            _pModel.PaintModel.Add(ellipse);
            Point point = new Point(50, 50);
            _pModel.SelecteShape(point);
            _pModel.MoveSelectedShape(point);
            Assert.AreEqual(3, triggerTime);
        }

        [TestMethod]
        public void TestEndSelecteShape()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            Shape ellipse = new Ellipse();
            ellipse.SetPoints(new Point(0, 0), new Point(100, 100));
            _pModel.PaintModel.Add(ellipse);
            Point point = new Point(50, 50);
            _pModel.SelecteShape(point);
            _pModel.MoveSelectedShape(point);
            _pModel.EndSelecteShape(point);
            Assert.AreEqual(4, triggerTime);
        }

        [TestMethod]
        public void TestStartCreateShape()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            _pModel.StartCreateShape(PaintModel.ShapeEnum.Ellipse, new Point(0, 0));
            Assert.AreEqual(1, triggerTime);
        }

        [TestMethod]
        public void TestResizeShape()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            _pModel.StartCreateShape(PaintModel.ShapeEnum.Ellipse, new Point(0, 0));
            _pModel.ResizeShape(new Point(100, 100));
            Assert.AreEqual(2, triggerTime);
        }

        [TestMethod]
        public void TestEndCreateShape()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            _pModel.StartCreateShape(PaintModel.ShapeEnum.Ellipse, new Point(0, 0));
            _pModel.MoveSelectedShape(new Point(100, 100));
            _pModel.EndCreateShape(new Point(200, 200));
            Assert.AreEqual(3, triggerTime);
        }

        [TestMethod]
        public void TestPressPointer()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            _pModel.ClickRectangleButton();
            _pModel.PressPointer(new Point(50, 50));
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
            _pModel.ClickRectangleButton();
            _pModel.PressPointer(new Point(50, 50));
            _pModel.MovePointer(new Point(100, 100));
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
            _pModel.ClickRectangleButton();
            _pModel.PressPointer(new Point(50, 50));
            _pModel.MovePointer(new Point(100, 100));
            _pModel.ReleasePointer(new Point(150, 150));
            Assert.AreEqual(3, triggerTime);
        }

        [TestMethod]
        public void TestDrawShapes()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            _pModel.DrawShapes(new MockGraphics(null));
            Assert.AreEqual(0, triggerTime);
        }

        [TestMethod]
        public void TestModelChanged()
        {
            int triggerTime = 0;
            _pModel._modelChanged += delegate()
            {
                triggerTime++;
            };
            Shape ellipse = new Ellipse();
            ellipse.SetPoints(new Point(0, 0), new Point(100, 100));
            _pModel.PaintModel.Add(ellipse);
            Assert.AreEqual(1, triggerTime);
            Point point = new Point(50, 50);
            _pModel.SelecteShape(point);
            Assert.AreEqual(2, triggerTime);
            _pModel.MoveSelectedShape(point);
            Assert.AreEqual(3, triggerTime);
            _pModel.EndSelecteShape(point);
            Assert.AreEqual(4, triggerTime);
            _pModel.StartCreateShape(PaintModel.ShapeEnum.Ellipse, point);
            Assert.AreEqual(5, triggerTime);
            _pModel.ResizeShape(point);
            Assert.AreEqual(6, triggerTime);
            _pModel.EndCreateShape(point);
        }
    }
}
