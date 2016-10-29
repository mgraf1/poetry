using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Poetry.Uploader.Services.WpfHelpers
{
    public class Dispatcher : IDispatcher
    {
        public DispatcherOperation BeginInvoke(Action action)
        {
            return Application.Current.Dispatcher.BeginInvoke(action);
        }
    }
}
