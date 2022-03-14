using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Shops.Models;
using Shops.WpfClient;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Shops.WpfClient
{
    public class ProductEditorViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Product> Products { get; set; }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (value != null)
                {
                    selectedProduct = new Product()
                    {
                        ProductName = value.ProductName,
                        ProductdId = value.ProductdId,
                        ProductColour = value.ProductColour,
                        ProductPrice = value.ProductPrice,
                        StockNumber = value.StockNumber,
                        UsresRating = value.UsresRating,
                        Brand = value.Brand,
                        BrandrId = value.BrandrId
                    };
                    OnPropertyChanged();
                    (DeleteProductCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateProductCommand { get; set; }

        public ICommand DeleteProductCommand { get; set; }

        public ICommand UpdateProductCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public ProductEditorViewModel()
        {
            if (!IsInDesignMode)
            {
                Products = new RestCollection<Product>("http://localhost:51395/", "Product", "hub");
                CreateProductCommand = new RelayCommand(() =>
                {
                    Products.Add(new Product()
                    {
                        ProductName = SelectedProduct.ProductName
                    });
                });

                UpdateProductCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Products.Update(SelectedProduct);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteProductCommand = new RelayCommand(() =>
                {
                    Products.Delete(SelectedProduct.ProductdId);
                },
                () =>
                {
                    return SelectedProduct != null;
                });
                SelectedProduct = new Product();
            }

        }
    }
}
