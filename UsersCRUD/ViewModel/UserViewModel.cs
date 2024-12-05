using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UsersCRUD.Model;
using UsersCRUD.Repositories;

namespace UsersCRUD.ViewModel 
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly UserRepository _userRepository; // For database operations
        private User _selectedUser; // Selected user for UI interactions

        public ObservableCollection<User> Users { get; set; } // Bindable user list
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        // Commands for CRUD operations
        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        // Constructor
        public UserViewModel()
        {
            // Initialize database connection
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string databasePath = Path.Combine(projectDirectory, "DB", "mvvmCRUDEx.db");

            _userRepository = new UserRepository(databasePath);

            // Load users from the database
            Users = new ObservableCollection<User>(_userRepository.GetAllUsers());

            // Initialize commands
            AddUserCommand = new RelayCommand(AddUser);
            UpdateUserCommand = new RelayCommand(UpdateUser, CanModifyUser);
            DeleteUserCommand = new RelayCommand(DeleteUser, CanModifyUser);
        }

        // Command Methods
        private void AddUser(object obj)
        {
            var newUser = new User
            {
                Name = "New",
                LastName = "User",
                Email = "new.user@example.com",
                Password = "password123"
            };

            _userRepository.AddUser(newUser);
            Users.Add(newUser); // Update UI
        }

        private void UpdateUser(object obj)
        {
            if (SelectedUser != null)
            {
                _userRepository.UpdateUser(SelectedUser);

                // Refresh UI, if necessary
                // Optional: Reload all users from DB
                // Users.Clear();
                // foreach (var user in _userRepository.GetAllUsers())
                // {
                //     Users.Add(user);
                // }
            }
        }

        private void DeleteUser(object obj)
        {
            if (SelectedUser != null)
            {
                _userRepository.DeleteUser(SelectedUser.Email);
                Users.Remove(SelectedUser); // Update UI
            }
        }

        private bool CanModifyUser(object obj)
        {
            return SelectedUser != null;
        }

        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
