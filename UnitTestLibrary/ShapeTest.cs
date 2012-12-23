using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyPaint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation;

namespace UnitTestLibrary
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void TestSetPoints()
        {
            Shape shape = new Shape();
            shape.SetPoints(new Point(20, 30), new Point(30, 40));
            Assert.AreEqual(20, shape.TopLeftPoint.X);
            Assert.AreEqual(30, shape.TopLeftPoint.Y);
            Assert.AreEqual(30, shape.BottomRightPoint.X);
            Assert.AreEqual(40, shape.BottomRightPoint.Y);
        }

        [TestMethod]
        public void TesstSetPointsByList()
        {
            Shape shape = new Shape();
            List<Point> points = new List<Point>();
            points.Add(new Point(20, 30));
            points.Add(new Point(30, 40));
            shape.SetPoints(points);
            Assert.AreEqual(20, shape.TopLeftPoint.X);
            Assert.AreEqual(30, shape.TopLeftPoint.Y);
            Assert.AreEqual(30, shape.BottomRightPoint.X);
            Assert.AreEqual(40, shape.BottomRightPoint.Y);
        }

        [TestMethod]
        public void TestTopLeftPoint()
        {
            Shape shape = new Shape();
            shape.SetPoints(new Point(20, 30), new Point(30, 40));
            Assert.AreEqual(20, shape.TopLeftPoint.X);
            Assert.AreEqual(30, shape.TopLeftPoint.Y);
            shape.SetPoints(new Point(80, 30), new Point(30, 40));
            Assert.AreEqual(30, shape.TopLeftPoint.X);
            Assert.AreEqual(30, shape.TopLeftPoint.Y);
            shape.SetPoints(new Point(80, 80), new Point(30, 40));
            Assert.AreEqual(30, shape.TopLeftPoint.X);
            Assert.AreEqual(40, shape.TopLeftPoint.Y);
            shape.SetPoints(new Point(20, 70), new Point(30, 40));
            Assert.AreEqual(20, shape.TopLeftPoint.X);
            Assert.AreEqual(40, shape.TopLeftPoint.Y);
        }

        [TestMethod]
        public void TestBottomRightPoint()
        {
            Shape shape = new Shape();
            shape.SetPoints(new Point(20, 30), new Point(30, 40));
            Assert.AreEqual(30, shape.BottomRightPoint.X);
            Assert.AreEqual(40, shape.BottomRightPoint.Y);
            shape.SetPoints(new Point(80, 30), new Point(30, 40));
            Assert.AreEqual(80, shape.BottomRightPoint.X);
            Assert.AreEqual(40, shape.BottomRightPoint.Y);
            shape.SetPoints(new Point(80, 80), new Point(30, 40));
            Assert.AreEqual(80, shape.BottomRightPoint.X);
            Assert.AreEqual(80, shape.BottomRightPoint.Y);
            shape.SetPoints(new Point(20, 70), new Point(30, 40));
            Assert.AreEqual(30, shape.BottomRightPoint.X);
            Assert.AreEqual(70, shape.BottomRightPoint.Y);
        }

        [TestMethod]
        public void TestDefaultCheckIsSelected()
        {
            Shape shape = new Shape();
            shape.SetPoints(new Point(20, 30), new Point(30, 40));
            Assert.IsTrue(shape.CheckIsSelected(new Point(25, 35)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(19, 35)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(25, 41)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(19, 41)));
        }

        [TestMethod]
        public void TesRectangleCheckIsSelected()
        {
            Shape shape = new Rectangle();
            shape.SetPoints(new Point(20, 30), new Point(30, 40));
            Assert.IsTrue(shape.CheckIsSelected(new Point(25, 35)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(19, 35)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(25, 41)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(19, 41)));
        }

        [TestMethod]
        public void TeEllipseCheckIsSelected()
        {
            Shape shape = new Ellipse();
            shape.SetPoints(new Point(50, 50), new Point(100, 100));
            Assert.IsTrue(shape.CheckIsSelected(new Point(75, 75)));
            Assert.IsTrue(shape.CheckIsSelected(new Point(75, 99)));
            Assert.IsTrue(shape.CheckIsSelected(new Point(99, 75)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(50, 50)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(50, 100)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(100, 50)));
            Assert.IsFalse(shape.CheckIsSelected(new Point(100, 100)));
        }
    }
}