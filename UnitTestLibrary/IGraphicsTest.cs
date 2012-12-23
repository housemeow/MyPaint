using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint;
using Windows.Foundation;

namespace UnitTestLibrary
{
    [TestClass]
    public class IGraphicsTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            IGraphics graphics = new MockGraphics(null);
        }

        [TestMethod]
        public void TestDrawRectangleSuccess()
        {
            IGraphics graphics = new MockGraphics(null);
            Assert.IsTrue(graphics.DrawRectangle(new Point(0, 0), new Point(100, 100)));
        }

        [TestMethod]
        public void TestDrawEllipseSuccess()
        {
            IGraphics graphics = new MockGraphics(null);
            Assert.IsTrue(graphics.DrawEllipse(new Point(0, 0), new Point(100, 100)));
        }

        [TestMethod]
        public void TestDrawRectangleException()
        {
            IGraphics graphics = new ExceptionGraphis(null);
            Assert.IsFalse(graphics.DrawRectangle(new Point(0, 0), new Point(100, 100)));
        }

        [TestMethod]
        public void TestDrawEllipseException()
        {
            IGraphics graphics = new ExceptionGraphis(null);
            Assert.IsFalse(graphics.DrawEllipse(new Point(0, 0), new Point(100, 100)));
        }
    }
}
