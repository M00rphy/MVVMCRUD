using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UsersCRUD.Model;


class UserViewModel
{
    public ObservableCollection<User> Users { get; set; }

    private User selectedUser;

    public User SelectedUser
    {
        get => selectedUser;
        set
        {
            selectedUser = value;
            OnPropertyChanged(nameof(SelectedUser));
        }
    }


    public UserViewModel()
    {
        Users = new ObservableCollection<User>
        {
            new User { Name = "Pedro", LastName = "sola", Email = "pedrito.sola@tlaeriza.mx", Password = "123"},
            new User { Name = "Pedro", LastName = "sola", Email = "pedrito.sola@tlaeriza.mx", Password = "123"},
            new User { Name = "Pedro", LastName = "sola", Email = "pedrito.sola@tlaeriza.mx", Password = "123"},
        };
    }


    private ICommand mUpdater;
    private ICommand UpdateCommand
    {
        get
        {
            if (mUpdater == null)
                mUpdater = new Updater();
            return mUpdater;

        }
        set { mUpdater = value; }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private class Updater : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            // Code implementation for execution
        }
    }
}
