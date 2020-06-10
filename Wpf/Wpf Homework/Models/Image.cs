using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using WpfTreeHomework.Commands;

namespace WpfTreeHomework.Models
{
    [Serializable]
    public class Image : TreeviewItemsBase,ISerialize
    {
        public BitmapImage bmp { get; set; } = new BitmapImage();
        public Image(ObservableCollection<TreeviewItemsBase> _parent, BitmapImage bmpp)
        {
            rename = new addItemCommand(_rename);
            remove = new addItemCommand(_remove);
            parent = _parent;
            bmp = bmpp;
          name = "New Image";          
        }
    }
}
