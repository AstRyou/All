using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfTreeHomework.Models;

namespace WpfTreeHomework.UserControls
{
    /// <summary>
    /// Interaction logic for passwordUC.xaml
    /// </summary>
    public partial class passwordUC : UserControl
    {
        ObservableCollection<account> accounts;
        public int index;
        public passwordUC(ObservableCollection<account> _accounts)
        {
            accounts = _accounts;
            InitializeComponent();
            listthelist.ItemsSource = accounts;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listthelist.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("grr");
            view.GroupDescriptions.Add(groupDescription);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            accounts.Add(new account());
            index = accounts.Count - 1;
            passwordContent.Content = new passwordRightUC(accounts[index]);
            editMenu.Visibility = Visibility.Visible;
        }

        private void Listthelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = listthelist.SelectedIndex;
            if (index != -1)
            {
                passwordContent.Content = new passwordRightUC(accounts[index]);
                editMenu.Visibility = Visibility.Visible;
            }
        }

        private void ApplyClick(object sender, RoutedEventArgs e)
        {
            viewMenu.Visibility = Visibility.Visible;
            editMenu.Visibility = Visibility.Hidden;
            passwordContent.Content = new passwordViewUC(accounts[index]);
        }

        private void Cancel_click(object sender, RoutedEventArgs e)
        {
            viewMenu.Visibility = Visibility.Visible;
            editMenu.Visibility = Visibility.Hidden;
            passwordContent.Content = new passwordViewUC(accounts[index]);
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            viewMenu.Visibility = Visibility.Hidden;
            editMenu.Visibility = Visibility.Visible;
            passwordContent.Content = new passwordRightUC(accounts[index]);
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            viewMenu.Visibility = Visibility.Hidden;
            editMenu.Visibility = Visibility.Hidden;
            passwordContent.Content = null;
            accounts.RemoveAt(index);
        }
    }
}