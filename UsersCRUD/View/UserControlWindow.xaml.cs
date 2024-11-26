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

        private void Button_Click(object sender, RoutedEventArgs e)
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
    }
}
