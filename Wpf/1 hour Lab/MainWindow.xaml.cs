using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
namespace WpfLab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  
        public MainWindow()
        {
          
            InitializeComponent();
            DataContext = new CompanyViewModel();
        }
    }
}
