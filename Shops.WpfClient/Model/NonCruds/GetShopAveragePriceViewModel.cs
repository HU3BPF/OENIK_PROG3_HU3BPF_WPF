using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Shops.Models.NonCrudClasses;

namespace Shops.WpfClient.Model.NonCruds
{
    internal class GetShopAveragePriceViewModel : ObservableRecipient
    {
        private String baseURl = "http://localhost:51395/Stat/";
        private String endPoint = "ShopAveragePrice";
        private HttpClient client = new HttpClient();
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public List<ShopAveragePrice> GetShopAveragePrices { get; set; }

        private ShopAveragePrice selectedShopAveragePrice;

        public ShopAveragePrice SelectedShopAveragePrice
        {
            get { return selectedShopAveragePrice; }
            set
            {
                if (value != null)
                {
                    selectedShopAveragePrice = new ShopAveragePrice()
                    {
                        ShopName = value.ShopName,
                        AveragePrice = value.AveragePrice,
                    };
                    OnPropertyChanged();
                }
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GetShopAveragePriceViewModel()
        {
            if (!IsInDesignMode)
            {
                List<ShopAveragePrice> items = new List<ShopAveragePrice>();
                client.BaseAddress = new Uri(baseURl);
                HttpResponseMessage response = client.GetAsync(endPoint).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    items = response.Content.ReadAsAsync<List<ShopAveragePrice>>().GetAwaiter().GetResult();
                    GetShopAveragePrices = items;
                }
            }

        }
    }
}
