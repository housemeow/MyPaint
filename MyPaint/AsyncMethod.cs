using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;

namespace MyPaint
{
    public class AsyncMethod
    {
        //because unit test is single thread, but UI elemnt is always multithread,
        //so have to trigger Test method using multithread way.
        public static IAsyncAction ExecuteOnUIThread(Windows.UI.Core.DispatchedHandler action)
        {
            CoreApplicationView mainView = CoreApplication.MainView;
            CoreWindow coreWindow = mainView.CoreWindow;
            CoreDispatcher coreDispatcher = coreWindow.Dispatcher;
            return coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, action);
        }
    }
}
