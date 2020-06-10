using System.Windows;
using System.Windows.Controls;
using WpfTreeHomework.ViewModels;
using WPF_Project;
using System.IO;

namespace WpfTreeHomework.UserControls
{
    /// <summary>
    /// Interaction logic for lockWindow.xaml
    /// </summary>
    public partial class lockWindow : UserControl
    {
        public main Main { get; set; }
        public MainWindow ParentForm { get; set; }
        public lockWindow(TreeViewModel tvm)
        {
            InitializeComponent();
            this.DataContext = tvm;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string path = $@"{System.IO.Directory.GetCurrentDirectory()}\Password.bin";
            //var bs= WPF_Project.DataEncryption.Encrypt("pass", File.ReadAllBytes(path));
            //if (bs!=null)
            ParentForm.Content = Main;
        }
    }
}
