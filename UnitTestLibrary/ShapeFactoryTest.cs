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
    public class ShapeFactoryTest
    {
        [TestMethod]
        public void TestShapeFactoryGetShape()
        {
            Point startPoint = new Point(0, 100);
            Point endPoint = new Point(100, 100);
            Shape shape;
            shape = ShapeFactory.GetShape(PaintModel.ShapeEnum.Ellipse);
            Assert.AreEqual(typeof(Ellipse), shape.GetType());
            shape = ShapeFactory.GetShape(PaintModel.ShapeEnum.Rectangle);
            Assert.AreEqual(typeof(Rectangle), shape.GetType());
        }
    }
}
