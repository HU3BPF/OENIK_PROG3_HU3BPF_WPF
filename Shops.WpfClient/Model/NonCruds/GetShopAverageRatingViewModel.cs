using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Shops.Models.NonCrudClasses;

namespace Shops.WpfClient.Model.NonCruds
{
    internal class GetShopAverageRatingViewModel : ObservableRecipient
    {
        private String baseURl = "http://localhost:51395/Stat/";
        private String endPoint = "ShopAverageRating";
        private HttpClient client = new HttpClient();
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public List<ShopAverageRating> ShopAverageRatings { get; set; }

        private ShopAverageRating selectedShopAverageRatings;

        public ShopAverageRating SelectedShopAverageRating
        {
            get { return selectedShopAverageRatings; }
            set
            {
                if (value != null)
                {
                    selectedShopAverageRatings = new ShopAverageRating()
                    {
                        ShopName = value.ShopName,
                        AverageRating = value.AverageRating,
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

        public GetShopAverageRatingViewModel()
        {
            if (!IsInDesignMode)
            {
                List<ShopAverageRating> items = new List<ShopAverageRating>();
                client.BaseAddress = new Uri(baseURl);
                HttpResponseMessage response = client.GetAsync(endPoint).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    items = response.Content.ReadAsAsync<List<ShopAverageRating>>().GetAwaiter().GetResult();
                    ShopAverageRatings = items;
                }
            }

        }
    }
}
