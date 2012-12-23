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
    public class PresentationModelPropertyTest
    {
        private PresentationModelProperty _pModelProperty;

        [TestInitialize]
        public void Initialize()
        {
            _pModelProperty = new PresentationModelProperty();
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.IsFalse(_pModelProperty.IsPointerButtonEnable);
            Assert.IsTrue(_pModelProperty.IsRectangleButtonEnable);
            Assert.IsTrue(_pModelProperty.IsEllipseButtonEnable);
        }

        [TestMethod]
        public void TestEnableButtons()
        {
            _pModelProperty.EnableButtons();
            Assert.IsTrue(_pModelProperty.IsPointerButtonEnable);
            Assert.IsTrue(_pModelProperty.IsRectangleButtonEnable);
            Assert.IsTrue(_pModelProperty.IsEllipseButtonEnable);
        }
    }
}
