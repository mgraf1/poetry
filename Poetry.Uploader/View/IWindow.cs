using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.View
{
    /// <summary>
    /// Interface implemented by all Windows displayed in the application.
    /// </summary>
    public interface IWindow
    {
        bool? DialogResult { get; set; }
        void Show();
        bool? ShowDialog();
        void Close();
        object DataContext { get; set; }
    }
}
