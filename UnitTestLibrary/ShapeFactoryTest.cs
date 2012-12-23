﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyPaint;
using Windows.UI.Xaml.Shapes;
using Windows.Foundation;
using System.Threading.Tasks;

namespace UnitTestLibrary
{
    [TestClass]
    public class ShapeFactoryTest
    {
        [TestMethod]
        public async Task TestShapeFactoryGetShape()
        {
            await AsyncMethod.ExecuteOnUIThread(() =>
            {
                Point startPoint = new Point(0, 100);
                Point endPoint = new Point(100, 100);
                Shape shape;
                shape = ShapeFactory.GetShape(PaintModel.ShapeEnum.Ellipse, startPoint, endPoint);
                Assert.AreEqual(typeof(Ellipse), shape.GetType());
                shape = ShapeFactory.GetShape(PaintModel.ShapeEnum.Line, startPoint, endPoint);
                Assert.AreEqual(typeof(Line), shape.GetType());
                shape = ShapeFactory.GetShape(PaintModel.ShapeEnum.Rectangle, startPoint, endPoint);
                Assert.AreEqual(typeof(Rectangle), shape.GetType());
            });
        }
    }
}
