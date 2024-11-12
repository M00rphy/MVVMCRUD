using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;


public class Product : INotifyPropertyChanged
{

    public string sku;
    public string name;
    public string price;
    public string stock;

    public string SKU
    {
        get
        {
            return sku;
        }
        set
        {
            sku = value;
            OnPropertyChanged("sku");
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            OnPropertyChanged("name");
        }
    }

    public string Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
            OnPropertyChanged("price");
        }
    }

    public string Stock
    {
        get
        {
            return stock;
        }
        set
        {
            stock = value;
            OnPropertyChanged("stock");
        }
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion
}

