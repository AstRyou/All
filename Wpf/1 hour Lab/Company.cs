using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfLab1
{
    public class Branch : INotifyPropertyChanged
    {
        private string _branchName;
        private string _companyName;
        private string _address;
        private string _email;
        private string _phoneNo;
        private string _webSite;

        public string BranchName { get => _branchName; set{ _branchName = value; OnPropertyChanged("BranchName"); } }
        public string CompanyName { get => _companyName; set { _companyName = value; OnPropertyChanged("CompanyName"); } }
        public string Address { get => _address;set { _address = value; OnPropertyChanged("Address"); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged("Email"); } }
        public string PhoneNo { get => _phoneNo; set { _phoneNo = value; OnPropertyChanged("PhoneNo"); } }
        public string WebSite { get => _webSite; set { _webSite = value; OnPropertyChanged("WebSite"); } }



        #region notify
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string proName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(proName));
            }

        }
        #endregion
    }

    public class Company : INotifyPropertyChanged
    {
        private string _companyName;
        private string _phrase;
        private string _description;
        private List<Branch> _branches;

        public string CompanyName { get => _companyName; set { _companyName = value; OnPropertyChanged("CompanyName"); } }
        public string Phrase { get => _phrase; set { _phrase = value; OnPropertyChanged("Phrase"); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged("Description"); } }
        public List<Branch> Branches { get => _branches; set { _branches = value; OnPropertyChanged("Branches"); } }

        #region notify
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string proName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(proName));
            }

        }
        #endregion
    }
}
