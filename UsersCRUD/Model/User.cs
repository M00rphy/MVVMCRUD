using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersCRUD.Model
{
    class User
    {
        private string name;
        private string lastName;
        private string email;
        private string password;
        


        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(name)); }
        }

        public string LastName
        {
            get => lastName;
            set { lastName = value; OnPropertyChanged(nameof(lastName)); }
        }

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(nameof(email)); }
        }

        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(nameof(password)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
