using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using UsersCRUD.Model;

namespace UsersCRUD
{
    public partial class UserControlWindow : Window
    {
        public UserControlWindow()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User
            {
                Name = NameIn.Text,
                LastName = LastNameIn.Text,
                Email = EmailIn.Text,
                Password = PasswordIn.Text
            };

            var viewModel = DataContext as UserViewModel;
            viewModel?.Users.Add(newUser);
        }

        private void updBtn_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as UserViewModel;

            if (viewModel?.SelectedUser != null)
            {
                MessageBox.Show("User updated correctly");
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var ViewModel = DataContext as UserViewModel;
            if (ViewModel?.SelectedUser != null)
            {
                var res = MessageBox.Show($"Are you sure you want to delete '{ViewModel.SelectedUser.Name}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    ViewModel.Users.Remove(ViewModel.SelectedUser);
                    MessageBox.Show("Success");
                } else
                {
                    MessageBox.Show("OK");
                }
            } else
            {
                MessageBox.Show("Please select a User to delete.");
            }
        }
    }
}
