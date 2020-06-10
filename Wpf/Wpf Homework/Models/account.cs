using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace WpfTreeHomework.Models
{
    [Serializable]
    public class account : INotifyPropertyChanged,ISerializable
    {
        private BitmapImage imagePath;
        private string name = "Account Name";
        private string email;
        private string login;
        private string password;
        private string notes;
        private string webmail;
        public char grr { get { return name[0]; } }
        public BitmapImage ImagePath { get => imagePath; set { imagePath = value; NotifyPropertyChanged("image"); } }
        public string Name { get => name; set { name = value; NotifyPropertyChanged("Name"); } }
        public string Email { get => email; set { email = value; NotifyPropertyChanged("email"); } }
        public string Login { get => login; set { login = value; NotifyPropertyChanged("login"); } }
        public string Password { get => password; set { password = value; NotifyPropertyChanged("password"); } }
        public string Webmail { get => webmail; set { webmail = value; NotifyPropertyChanged("webmail"); } }
        public string Notes { get => notes; set { notes = value; NotifyPropertyChanged("notes"); } }

        public account() { }

        #region inotify
        public event PropertyChangedEventHandler PropertyChanged;

 

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion inotify

        #region serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ImagePath", ImagePath);
            info.AddValue("Name", Name);
            info.AddValue("Email", Email);
            info.AddValue("Login", Login);
            info.AddValue("Webmail", Password);
            info.AddValue("ImagePath", Webmail);
            info.AddValue("Notes", Notes);
        }
        public account(SerializationInfo info, StreamingContext context)
        {
            ImagePath = (BitmapImage)info.GetValue("ImagePath", typeof(BitmapImage));
            Name = (string)info.GetValue("Name", typeof(string));
            Email = (string)info.GetValue("Email", typeof(string));
            Login = (string)info.GetValue("Login", typeof(string));
            Password = (string)info.GetValue("Password", typeof(string));
            Webmail = (string)info.GetValue("Webmail", typeof(string));
            Notes = (string)info.GetValue("Notes", typeof(string));

        }
        #endregion serialization
    }
}
