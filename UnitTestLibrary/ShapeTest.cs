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
    public class ShapeTest
    {
        [TestMethod]
        public void TestSetPoint()
        {
            MyShape myShape = new MyShape();
            myShape.SetPoints(new Point(20, 30), new Point(30, 40));
            Assert.AreEqual(20, myShape.TopLeftPoint.X);
            Assert.AreEqual(30, myShape.TopLeftPoint.Y);
            Assert.AreEqual(30, myShape.BottomRightPoint.X);
            Assert.AreEqual(40, myShape.BottomRightPoint.Y);
        }

        [TestMethod]
        public void TestTopLeftPoint()
        {
            MyShape myShape = new MyShape();
            myShape.SetPoints(new Point(20, 30), new Point(30, 40));
            Assert.AreEqual(20, myShape.TopLeftPoint.X);
            Assert.AreEqual(30, myShape.TopLeftPoint.Y);
            myShape.SetPoints(new Point(80, 30), new Point(30, 40));
            Assert.AreEqual(30, myShape.TopLeftPoint.X);
            Assert.AreEqual(30, myShape.TopLeftPoint.Y);
            myShape.SetPoints(new Point(80, 80), new Point(30, 40));
            Assert.AreEqual(30, myShape.TopLeftPoint.X);
            Assert.AreEqual(40, myShape.TopLeftPoint.Y);
            myShape.SetPoints(new Point(20, 70), new Point(30, 40));
            Assert.AreEqual(20, myShape.TopLeftPoint.X);
            Assert.AreEqual(40, myShape.TopLeftPoint.Y);
        }

        [TestMethod]
        public void TestBottomRightPoint()
        {
            MyShape myShape = new MyShape();
            myShape.SetPoints(new Point(20, 30), new Point(30, 40));
            Assert.AreEqual(30, myShape.BottomRightPoint.X);
            Assert.AreEqual(40, myShape.BottomRightPoint.Y);
            myShape.SetPoints(new Point(80, 30), new Point(30, 40));
            Assert.AreEqual(80, myShape.BottomRightPoint.X);
            Assert.AreEqual(40, myShape.BottomRightPoint.Y);
            myShape.SetPoints(new Point(80, 80), new Point(30, 40));
            Assert.AreEqual(80, myShape.BottomRightPoint.X);
            Assert.AreEqual(80, myShape.BottomRightPoint.Y);
            myShape.SetPoints(new Point(20, 70), new Point(30, 40));
            Assert.AreEqual(30, myShape.BottomRightPoint.X);
            Assert.AreEqual(70, myShape.BottomRightPoint.Y);
        }
    }
}