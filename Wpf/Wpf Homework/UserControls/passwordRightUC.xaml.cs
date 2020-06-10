using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfTreeHomework.Models;

namespace WpfTreeHomework.UserControls
{
    /// <summary>
    /// Interaction logic for passwordRightUC.xaml
    /// </summary>
    public partial class passwordRightUC : UserControl
    {
        public account acc { get; set; }
        public passwordRightUC(account _acc)
        {
            acc = _acc;
            InitializeComponent();
            this.DataContext =acc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            };
            if (ofd.ShowDialog() == true)
            {
                acc.ImagePath = new BitmapImage(new Uri(ofd.FileName));
                img.Source = acc.ImagePath;
            }
        }

    }
}
