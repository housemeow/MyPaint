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
using Windows.UI.Xaml.Shapes;

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
        public async Task TestAddShape()
        {
            await AsyncMethod.ExecuteOnUIThread(() =>
            {
                Line line = new Line();
                _model.AddShape(line);
                List<Shape> shapes = _model.Shapes;
                Assert.AreEqual(1, shapes.Count);
                Assert.AreEqual(line, shapes[0]);
            });
        }

        [TestMethod]
        public async Task TestRemoveShape()
        {
            await AsyncMethod.ExecuteOnUIThread(() =>
            {
                Rectangle rectangle = new Rectangle();
                _model.AddShape(rectangle);
                Assert.IsTrue(_model.Remove(rectangle));
                Assert.IsFalse(_model.Remove(rectangle));
            });
        }

        [TestMethod]
        public async Task TestClearShape()
        {
            await AsyncMethod.ExecuteOnUIThread(() =>
            {
                _model.AddShape(new Line());
                List<Shape> shapes = _model.Shapes;
                Assert.AreEqual(1, shapes.Count);
                _model.Clear();
                Assert.AreEqual(0, shapes.Count);
            });
        }

        [TestMethod]
        public async Task TestModelChanged()
        {
            await AsyncMethod.ExecuteOnUIThread(() =>
            {
                int triggerTime = 0;
                _model._propertyChanged += delegate()
                {
                    triggerTime++;
                };
                _model.AddShape(new Line());
                Assert.AreEqual(1, triggerTime);
                _model.Remove(new Line());
                Assert.AreEqual(2, triggerTime);
                _model.Clear();
                Assert.AreEqual(3, triggerTime);
            });
        }
    }
}
