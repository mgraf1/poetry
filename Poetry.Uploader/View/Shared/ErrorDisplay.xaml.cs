using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Poetry.Uploader.View.Shared
{
    /// <summary>
    /// Interaction logic for ErrorDisplay.xaml
    /// </summary>
    public partial class ErrorDisplay : UserControl
    {
        public static readonly DependencyProperty ControlToValidateProperty = DependencyProperty.Register("ControlToValidate",
                                                                                                typeof(Control),
                                                                                                typeof(ErrorDisplay));

        public Control ControlToValidate
        {
            get
            {
                return (Control)GetValue(ControlToValidateProperty);
            }
            set
            {
                SetValue(ControlToValidateProperty, value);
            }
        }

        public ErrorDisplay()
        {
            InitializeComponent();
        }
    }
}
