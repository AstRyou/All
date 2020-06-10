using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfTreeHomework.Commands;

namespace WpfTreeHomework.Models
{
    [Serializable]
    public abstract class TreeviewItemsBase : INotifyPropertyChanged
    {
        public string _name;
        public bool isedit = false;
        public bool isEditaaaaaa
        {
            get { return isedit; }
            set { isedit = value;NotifyPropertyChanged("isedit"); }
        }
    
        public string name { get { return _name; } set { _name = value;NotifyPropertyChanged("asdasda"); } }
        public ObservableCollection<TreeviewItemsBase> parent { get; set; }
        #region expandselect
        private bool isSelected;
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (value != this.isSelected)
                {
                    this.isSelected = value;
                    NotifyPropertyChanged("IsSelected");
                }
            }
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            get { return this.isExpanded; }
            set
            {
                if (value != this.isExpanded)
                {
                    this.isExpanded = value;
                    NotifyPropertyChanged("IsExpanded");
                }
            }
        }

        #endregion expandselect
        #region inotify
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion inotify
        public addItemCommand remove { get; set; }
        public void _remove()
        {
            parent.Remove(this);
        }
        public addItemCommand rename { get; set; }
        public void _rename()
        {
            isEditaaaaaa = false;
        }

    }
}
