using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;


public class ProductViewModel
{
    private IList<Product> productsList;

    public ProductViewModel()
    {
        productsList = new List<Product> {
            new Product { SKU = "1", Name = "Dog Toy", Price = "6", Stock = "6"},
            new Product { SKU = "2", Name = "CBD Chuwables", Price = "30", Stock = "25"},
            new Product { SKU = "3", Name = "Maskking", Price = "25", Stock = "55"},

        };
    }

    public IList<Product> Products
    {
        get { return productsList; }
        set { productsList = value; }
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

