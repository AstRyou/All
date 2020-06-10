using System.Windows;
using WpfTreeHomework.UserControls;
using WpfTreeHomework.ViewModels;

namespace WpfTreeHomework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
             var tvm=new TreeViewModel();
            lockWindow LockWindow = new lockWindow(tvm);
            main man = new main(tvm);

            LockWindow.ParentForm = this;
            LockWindow.Main = man;

            man.ParentForm = this;
            man.LockWindow = LockWindow;

            this.Content = LockWindow;

        }
    }
}
