using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace UsersCRUD
{
    public partial class UserControlWindow : Window
    {
        public UserControlWindow()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel();
        }
    }
}
