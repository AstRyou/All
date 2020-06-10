using System.Windows;
using System.Windows.Controls;
using WpfTreeHomework.ViewModels;
using WpfTreeHomework.Models;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using WpfTreeHomework.extra;
using System;

namespace WpfTreeHomework.UserControls
{
    /// <summary>
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : UserControl
    {
        #region parent-sibling
        public lockWindow LockWindow { get; set; }
        public MainWindow ParentForm { get; set; }
        #endregion parent-sibling

        TreeViewModel tv;
        public main(TreeViewModel tvm)
        {
            
            tv = tvm;
            InitializeComponent();
            tvm.tw = viewTree;
            mainControl.DataContext = tvm;
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            ParentForm.Content = LockWindow;
        }

        private void ViewTree_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            viewTree.Items.Refresh();
        }
        private void ViewTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (viewTree.SelectedItem != null)
            {
                var item = viewTree.SelectedItem as TreeviewItemsBase;
                if (item.name.Contains("Directory"))
                {
                    contentCC.Content = new directoryViewUC(viewTree.SelectedItem as Models.Directory);
                }
                else if (item.name.Contains("Image"))
                {
                    contentCC.Content = new ImageViewUC(viewTree.SelectedItem as Models.Image);
                }
                else if (item.name.Contains("Password"))
                {
                    contentCC.Content = new passwordUC((viewTree.SelectedItem as Password).accounts);
                }
            }
            else
            {
                contentCC.Content = null;
            }
        }

        private void Save_click(object sender, RoutedEventArgs e)
        {

            using (var ms = new MemoryStream())
            {
                var ser = new BinaryFormatter();
                ser.Serialize(ms, tv);
                //ms.Position = 0;
                string path = $@"{System.IO.Directory.GetCurrentDirectory()}\Password.bin";
                File.WriteAllBytes(path, WPF_Project.DataEncryption.Encrypt("pass", ms.ToArray()));
             
            }
            //BinaryFormatter bf = new BinaryFormatter();
            //            using (var ms = new MemoryStream())
            //            {
            //                bf.Serialize(ms, tv);              
            // File.WriteAllBytes("Password.bin", WPF_Project.DataEncryption.Encrypt("pass", ms.ToArray()));

            //}
        }

        private void LostFocus_directory_textbox(object sender, RoutedEventArgs e)
        {
            (sender as EditableTextBlock).IsInEditMode = false;

        }
    }
   
}
