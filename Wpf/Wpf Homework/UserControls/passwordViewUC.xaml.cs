using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfTreeHomework.Models;

namespace WpfTreeHomework.UserControls
{
    /// <summary>
    /// Interaction logic for passwordViewUC.xaml
    /// </summary>
    public partial class passwordViewUC : UserControl
    {
        public account acc { get; set; }
        public passwordViewUC(account _acc)
        {
            InitializeComponent();
            acc = _acc;
            DataContext = acc;
            edit.Text= DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            create.Text = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }


        private void EmailButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Clipboard.SetText(acc.Email);
        }
        private void loginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Clipboard.SetText(acc.Login);
        }
        private void PassButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Clipboard.SetText(acc.Password);
        }
    }
}
