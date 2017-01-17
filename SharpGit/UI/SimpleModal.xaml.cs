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

namespace SharpGit.UI
{
    /// <summary>
    /// Logica di interazione per SimpleModal.xaml
    /// </summary>
    public partial class SimpleModal : Page
    {
        public SimpleModal()
        {
            InitializeComponent();
            WindowStatus.ModalOutput = Output;
            WindowStatus.ModalFrameCloseButton = CloseButton;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            WindowStatus.HideModalFrame();
        }
    }
}
