using System.Windows.Controls;
using Plasma.WpfDialogBox.ViewModels;

namespace Plasma.WpfDialogBox.Views
{
    public partial class GenericMessageBox : UserControl, IMessageBoxView<GenericMessageBoxViewModel>
    {
        public GenericMessageBox()
        {
            InitializeComponent();
        }
    }
}
