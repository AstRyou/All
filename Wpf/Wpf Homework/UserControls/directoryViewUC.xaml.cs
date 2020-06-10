using System.Windows.Controls;
using WpfTreeHomework.Models;

namespace WpfTreeHomework.UserControls
{
    /// <summary>
    /// Interaction logic for directoryViewUC.xaml
    /// </summary>
    public partial class directoryViewUC : UserControl
    {
        public directoryViewUC(Directory directory)
        {
            InitializeComponent();
            this.DataContext = directory;
        }
    }
}
