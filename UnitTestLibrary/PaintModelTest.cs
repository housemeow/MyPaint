using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyPaint;
using Windows.Foundation;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.Threading.Tasks;

namespace UnitTestLibrary
{
    [TestClass]
    public class PaintModelTest
    {
        private PaintModel _model;

        [TestInitialize]
        public void Initialize()
        {
            _model = new PaintModel();
        }

        [TestMethod]
        public void TestAddShape()
        {
            Rectangle rectangle = new Rectangle();
            _model.Add(rectangle);
            List<Shape> shapes = _model.Shapes;
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(rectangle, shapes[0]);
        }

        [TestMethod]
        public void TestRemoveShape()
        {
            Rectangle rectangle = new Rectangle();
            _model.Add(rectangle);
            Assert.IsTrue(_model.Remove(rectangle));
            Assert.IsFalse(_model.Remove(rectangle));
        }

        [TestMethod]
        public void TestClearShape()
        {
            _model.Add(new Rectangle());
            List<Shape> shapes = _model.Shapes;
            Assert.AreEqual(1, shapes.Count);
            _model.Clear();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod]
        public void TestModelChanged()
        {
            int triggerTime = 0;
            _model._propertyChanged += delegate()
            {
                triggerTime++;
            };
            _model.Add(new Rectangle());
            Assert.AreEqual(1, triggerTime);
            _model.Remove(new Rectangle());
            Assert.AreEqual(2, triggerTime);
            _model.Clear();
            Assert.AreEqual(3, triggerTime);
        }
    }
}
