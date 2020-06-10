using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfTreeHomework.Commands;
using WpfTreeHomework.Models;

namespace WpfTreeHomework.ViewModels
{
    [Serializable]
    public class TreeViewModel:ISerializable
    {
        public ObservableCollection<TreeviewItemsBase> firstGeneration { get; set; } = new ObservableCollection<TreeviewItemsBase>();
        #region ctor
        public TreeViewModel()
        {
            IAddDirectory = new addItemCommand(AddDirectory);
            IAddImage = new addItemCommand(AddImage);
            IAddPassword = new addItemCommand(AddPassword);
            //firstGeneration.CollectionChanged += ContentCollectionChanged;
        }
        #endregion ctor
        
        #region ICommands
        public addItemCommand IAddDirectory { get; private set; }
        public addItemCommand IAddImage { get; private set; }
        public addItemCommand IAddPassword { get; private set; }
        public addItemCommand IsaveFile { get; private set; }
        #endregion ICommands

        #region ICommand Functions
        public void AddDirectory()
        {
            firstGeneration.Add(new Models.Directory(firstGeneration));
        }
        public void AddImage()
        {
            var ofd = new OpenFileDialog
            {
                Filter= "Image files (*.bmp, *.jpg, *.tif, *.gif, *.png)|*.bmp;*.jpg;*.tif;*.gif;*.png|All files (*.*)|*.*",
            InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            };
            if (ofd.ShowDialog() == true)
            {

                firstGeneration.Add(new Models.Image(firstGeneration,new BitmapImage(new Uri(ofd.FileName))));
            }

            
           
        }
        public void AddPassword()
        {
            firstGeneration.Add(new Models.Password(firstGeneration));
           
        }
        public TreeView tw { get; set; }


        #endregion commanFunctions

        #region innercollection changed
        //public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == NotifyCollectionChangedAction.Remove)
        //    {
        //        foreach (TreeviewItemsBase item in e.OldItems)
        //        {
        //            //Removed items
        //            item.PropertyChanged -= EntityViewModelPropertyChanged;
        //        }
        //    }
        //    else if (e.Action == NotifyCollectionChangedAction.Add)
        //    {
        //        foreach (TreeviewItemsBase item in e.NewItems)
        //        {
        //            //Added items
        //            item.PropertyChanged += EntityViewModelPropertyChanged;
        //        }
        //    }
        //}
        //public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    tw.Items.Refresh();  
        //    //This will get called when the property of an object inside the collection changes
        //}
        #endregion innercollection changed

        #region serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("firstGeneration", firstGeneration);
        }
        public TreeViewModel(SerializationInfo info, StreamingContext context)
        {
            foreach (var item in (ObservableCollection<TreeviewItemsBase>)info.GetValue("firstGeneration", typeof(ObservableCollection<TreeviewItemsBase>)))
            {
                firstGeneration.Add(item);
            }
            IAddDirectory = new addItemCommand(AddDirectory);
            IAddImage = new addItemCommand(AddImage);
            IAddPassword = new addItemCommand(AddPassword);
            //firstGeneration.CollectionChanged += ContentCollectionChanged;
        }

        #endregion serialization
    }
}
