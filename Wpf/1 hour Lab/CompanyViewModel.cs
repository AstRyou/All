using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Serialization;

namespace WpfLab1
{
    internal class CompanyViewModel
    {
        public ObservableCollection<Company> company { get; set; }
        public CompanyViewModel()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Company>));
            Stream fStream = new FileStream(@"C:\Users\aytac\source\repos\WpfLab1\WpfLab1\Companies.xml", FileMode.Open, FileAccess.Read);
            this.company = (ObservableCollection<Company>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
    }
}
