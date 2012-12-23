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
        }

        [TestMethod]
        public void TestClickEllipseButton()
        {
            _pModel.ClickEllipseButton();
            Assert.IsTrue(_pModel.IsPointerButtonEnable);
            Assert.IsFalse(_pModel.IsEllipseButtonEnable);
            Assert.IsTrue(_pModel.IsRectangleButtonEnable);
        }

        [TestMethod]
        public void TestClickRectangleButton()
        {
            _pModel.ClickRectangleButton();
            Assert.IsTrue(_pModel.IsPointerButtonEnable);
            Assert.IsTrue(_pModel.IsEllipseButtonEnable);
            Assert.IsFalse(_pModel.IsRectangleButtonEnable);
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
