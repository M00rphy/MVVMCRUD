using System.Windows;
using UsersCRUD.ViewModel;

namespace UsersCRUD
{
    public partial class UserControlWindow : Window
    {
        public UserControlWindow()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel(); // Bind ViewModel
        }

        // Logout button logic remains in code-behind (if it's navigation-specific).
        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow MainW = new MainWindow();
            MainW.Show();
        }
    }
}
