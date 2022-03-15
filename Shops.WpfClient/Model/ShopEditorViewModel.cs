using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Shops.Models;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;

namespace Shops.WpfClient
{
    public class ShopEditorViewModel : ObservableRecipient
    {
        private String baseURl = "http://localhost:51395/";
        private String endPoint = "Shop";
        private HttpClient client = new HttpClient();
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Shop> Shops { get; set; }

        private Shop selectedShop;

        public Shop SelectedShop
        {
            get { return selectedShop; }
            set
            {
                if (value != null)
                {
                    selectedShop = new Shop()
                    {
                        ShopName = value.ShopName,
                        ShopId = value.ShopId,
                        ShopAnnualProfit = value.ShopAnnualProfit,
                        ShopLeader = value.ShopLeader,
                        ShopLocation = value.ShopLocation,
                        ShopNumberOfWorker = value.ShopNumberOfWorker,
                        ShopReliability = value.ShopReliability,
                    };
                    OnPropertyChanged();
                    (DeleteShopCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateShopCommand { get; set; }

        public ICommand DeleteShopCommand { get; set; }

        public ICommand UpdateShopCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ShopEditorViewModel()
        {
            if (!IsInDesignMode)
            {
                Shops = new RestCollection<Shop>("http://localhost:51395/", "Shop", "hub");

                CreateShopCommand = new RelayCommand(() =>
                {
                    Shops.Add(new Shop()
                    {
                        ShopName = SelectedShop.ShopName
                    });
                });

                UpdateShopCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Shops.Update(SelectedShop);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                },
                 () =>
                 {
                     return SelectedShop != null;
                 });

                DeleteShopCommand = new RelayCommand(() =>
                {
                    Shops.Delete(SelectedShop.ShopId);
                },
                () =>
                {
                    return SelectedShop != null;
                });
                SelectedShop = new Shop();
            }

        }
    }
}
