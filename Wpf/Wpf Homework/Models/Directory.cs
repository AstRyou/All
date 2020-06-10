using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfTreeHomework.Commands;
using WpfTreeHomework.extra;

namespace WpfTreeHomework.Models
{
    [Serializable]
    public class Directory:TreeviewItemsBase,ISerializable
    { 
        public ObservableCollection<TreeviewItemsBase> Directories { get; set; } = new ObservableCollection<TreeviewItemsBase>();
        public ObservableCollection<TreeviewItemsBase> Items
        {
            get
            {
                ObservableCollection<TreeviewItemsBase> childNodes = new ObservableCollection<TreeviewItemsBase>();
                foreach (var group in this.Directories)
                    childNodes.Add(group);
                return childNodes;
            }
            set { }
        }
        #region ctor
        public Directory(ObservableCollection<TreeviewItemsBase> _parent)
        {
            parent = _parent;
            name = "New Directory";
            IaddSubDir = new addItemCommand(addSubDir);
            IAddImage = new addItemCommand(AddImage);
            IAddPassword = new addItemCommand(AddPassword);
            remove = new addItemCommand(_remove);
            rename = new addItemCommand(_rename);
        }
        #endregion ctor
        #region command
        public addItemCommand IaddSubDir { get; private set; }
        public addItemCommand IAddImage { get; private set; }
        public addItemCommand IAddPassword { get; private set; }
        public void addSubDir()
        {
            Directories.Add(new Directory(Directories));
            NotifyPropertyChanged("addsub");
        }



        public void AddImage()
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Image files (*.bmp, *.jpg, *.tif, *.gif, *.png)|*.bmp;*.jpg;*.tif;*.gif;*.png|All files (*.*)|*.*",
                InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            };
            if (ofd.ShowDialog() == true)
            {

                Directories.Add(new Models.Image(Directories,new BitmapImage(new Uri(ofd.FileName))));
            }



        }
        public void AddPassword()
        {
            Directories.Add(new Models.Password(Directories));

        }
        #endregion command

        #region seri
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            info.AddValue("Directories", Directories);
            info.AddValue("name", name);
        }
        public Directory(SerializationInfo info, StreamingContext context)
        {
            this.name = (string)info.GetValue("name", typeof(string));
            foreach (var item in (ObservableCollection<TreeviewItemsBase>)info.GetValue("Directories",typeof(ObservableCollection<TreeviewItemsBase>)))
            {
                Directories.Add(item);
            }
            IaddSubDir = new addItemCommand(addSubDir);
        }
        #endregion seri
    }
}
