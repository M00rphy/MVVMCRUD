using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;


public class ProductViewModel
{

    //Replace IList<Product> with ObservableCollection<Product> to auto-update the UI
    public ObservableCollection<Product> Products { get; set; }

    private Product selectedProduct;

    public Product SelectedProduct
    {
        get => selectedProduct;
        set
        {
            selectedProduct = value;
            OnPropertyChanged(nameof(SelectedProduct));
        }
    }

    public ProductViewModel()
    {
        Products = new ObservableCollection<Product>
        {
            new Product { SKU = "1", Name = "Dog Toy", Price = "6", Stock = "6"},
            new Product { SKU = "2", Name = "CBD Chuwables", Price = "30", Stock = "25"},
            new Product { SKU = "3", Name = "Maskking", Price = "25", Stock = "55"},
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

