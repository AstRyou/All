using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WpfTreeHomework.Commands;

namespace WpfTreeHomework.Models
{
    [Serializable]
    internal class Password : TreeviewItemsBase,ISerializable
    {
        public ObservableCollection<account> accounts = new ObservableCollection<account>();
        public Password(ObservableCollection<TreeviewItemsBase> _parent)
        {
            rename = new addItemCommand(_rename);
            remove = new addItemCommand(_remove);
            parent = _parent;
            name = "New Password" ;  

        }
        #region serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("accounts", accounts);
        }
        public Password(SerializationInfo info, StreamingContext context)
        {
            foreach (var item in (ObservableCollection<account>)info.GetValue("accounts", typeof(ObservableCollection<account>)))
            {
                accounts.Add(item);
            }
        }

        #endregion serialization
    }
}
