using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

namespace WpfTreeHomework.UserControls
{
    /// <summary>
    /// Interaction logic for ImageViewUC.xaml
    /// </summary>
    public partial class ImageViewUC : UserControl
    {
        public Models.Image Img { get; set; }
        public ImageViewUC(Models.Image img)
        {
            Img = img;
            this.DataContext = Img;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog()
            {
                Filter = "Png files(*.png)|*.png"
            };
            if (sfd.ShowDialog() == true)
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    BitmapEncoder enc = new BmpBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create(Img.bmp));
                    enc.Save(outStream);
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                    var mp= new Bitmap(bitmap);
                    mp.Save(sfd.FileName, ImageFormat.Png);
                }
            }
        }
    }
}
