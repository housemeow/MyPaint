using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyPaint;
using Windows.Foundation;
using Windows.UI.Xaml.Shapes;
using System.Threading.Tasks;

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
            Assert.AreEqual(PresentationModelProperty.DrawMode.Pointer, _pModel.NowDrawMode);
        }

        [TestMethod]
        public void TestClickEllipseButton()
        {
            _pModel.ClickEllipseButton();
            Assert.IsTrue(_pModel.IsPointerButtonEnable);
            Assert.IsFalse(_pModel.IsEllipseButtonEnable);
            Assert.IsTrue(_pModel.IsRectangleButtonEnable);
            Assert.AreEqual(PresentationModelProperty.DrawMode.Ellipse, _pModel.NowDrawMode);
        }

        [TestMethod]
        public void TestClickRectangleButton()
        {
            _pModel.ClickRectangleButton();
            Assert.IsTrue(_pModel.IsPointerButtonEnable);
            Assert.IsTrue(_pModel.IsEllipseButtonEnable);
            Assert.IsFalse(_pModel.IsRectangleButtonEnable);
            Assert.AreEqual(PresentationModelProperty.DrawMode.Rectangle, _pModel.NowDrawMode);
        }

        [TestMethod]
        public async Task TestClickClearButton()
        {
            await AsyncMethod.ExecuteOnUIThread(() =>
            {
                _pModel.ClickEllipseButton();
                _pModel.ClickMouse(new Point(100, 100));
                List<Shape> shapes = _pModel.GetShapes();
                Assert.AreEqual(1, shapes.Count);
                _pModel.ClickClearButton();
                Assert.AreEqual(0, shapes.Count);
            });
        }

        [TestMethod]
        public async Task TestMouseClick()
        {
            await AsyncMethod.ExecuteOnUIThread(() =>
            {
                Point point = new Point(100, 100);
                _pModel.NowDrawMode = PresentationModelProperty.DrawMode.Ellipse;
                _pModel.ClickMouse(point);
                PaintModel paintModel = _pModel.PaintModel;
                List<Shape> shapes = paintModel.Shapes;
                Assert.AreEqual(1, shapes.Count);
            });
        }

        [TestMethod]
        public async Task TestGetShapes()
        {
            await AsyncMethod.ExecuteOnUIThread(() =>
            {
                List<Shape> shapes = _pModel.GetShapes();
                Assert.AreEqual(0, shapes.Count);
                shapes.Add(new Line());
                Assert.AreEqual(1, shapes.Count);
            });
        }

        [TestMethod]
        public async Task TestStateChanged()
        {
            await AsyncMethod.ExecuteOnUIThread(() =>
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
            });
        }
    }
}
