using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Poetry.Uploader.Services.WpfHelpers
{
    public interface IDispatcher
    {
        DispatcherOperation BeginInvoke(Action action);
    }
}
