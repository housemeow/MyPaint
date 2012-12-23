using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyPaint;
using Windows.UI.Xaml.Shapes;
using Windows.Foundation;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.Threading.Tasks;

namespace UnitTestLibrary
{
    [TestClass]
    public class PresentationModelPropertyTest
    {
        private PresentationModelProperty _pModelProperty;

        [TestInitialize]
        public void InitializePresentationModelProperty()
        {
            _pModelProperty = new PresentationModelProperty();
        }

        [TestMethod]
        public void TestPresentationModelPropertyConstructor()
        {
            Assert.IsFalse(_pModelProperty.IsPointerButtonEnable);
            Assert.IsTrue(_pModelProperty.IsRectangleButtonEnable);
            Assert.IsTrue(_pModelProperty.IsEllipseButtonEnable);
        }

        [TestMethod]
        public void TestPresentationModelPropertyEnableButtons()
        {
            _pModelProperty.EnableButtons();
            Assert.IsTrue(_pModelProperty.IsPointerButtonEnable);
            Assert.IsTrue(_pModelProperty.IsRectangleButtonEnable);
            Assert.IsTrue(_pModelProperty.IsEllipseButtonEnable);
        }
    }
}
