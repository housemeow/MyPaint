using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyPaint
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private PresentationModel _pModel;
        private PaintModel _paintModel;

        //constructor of main page
        public MainPage()
        {
            this.InitializeComponent();
            _paintModel = new PaintModel();
            _pModel = new PresentationModel(_paintModel);
            _paintModel._propertyChanged += RefreshCanvas;
            _pModel._stateChanged += RefreshState;
            RefreshState();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        //click close button and exit the application
        private void ClickButtonClose(object sender, RoutedEventArgs e)
        {
            _canvas.Children.Clear();
            App.Current.Exit();
        }

        //click pointer button
        private void ClickButtonPointer(object sender, RoutedEventArgs e)
        {
            _pModel.ClickPointerButton();
        }

        //refresh presentation state
        void RefreshState()
        {
            _buttonPointer.IsEnabled = _pModel.IsPointerButtonEnable;
            _buttonEllipse.IsEnabled = _pModel.IsEllipseButtonEnable;
            _buttonRectangle.IsEnabled = _pModel.IsRectangleButtonEnable;
        }

        //model change and refresh canvas
        void RefreshCanvas()
        {
            //創造一個矩形範圍
            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            //設定矩形大小
            myRectangleGeometry.Rect = new Rect(0, 0, _canvas.ActualWidth, _canvas.ActualHeight);
            //畫布超出矩形大小的都會被截掉
            _canvas.Clip = myRectangleGeometry;
            _canvas.Children.Clear();
            List<Shape> shapes = _pModel.GetShapes();
            foreach (Shape shape in shapes)
            {
                _canvas.Children.Add(shape);
            }
        }

        //click ellipse button
        private void ClickButtonEllipse(object sender, RoutedEventArgs e)
        {
            _pModel.ClickEllipseButton();
        }

        //click rectangle button
        private void ClickButtonRectangle(object sender, RoutedEventArgs e)
        {
            _pModel.ClickRectangleButton();
        }

        //click clear button
        private void ClickButtonClear(object sender, RoutedEventArgs e)
        {
            _pModel.ClickClearButton();
        }

        //release point
        private void ReleaseCanvasPointe(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pointerPoint = e.GetCurrentPoint(_canvas);
            Point point = pointerPoint.Position;
            _pModel.MouseClick(point);
        }
    }
}
