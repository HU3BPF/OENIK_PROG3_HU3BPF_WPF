using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Shops.Models.NonCrudClasses;

namespace Shops.WpfClient.Model
{
    internal class GetBrandAveragesRatingViewModel : ObservableRecipient
    {
        private String baseURl = "http://localhost:51395/Stat/";
        private String endPoint = "BrandAverageProductRating";
        private HttpClient client = new HttpClient();
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public List<BrandAverageProductRating> BrandAverageProductRatings { get; set; }

        private BrandAverageProductRating selectedBrandAverageProductRatings;

        public BrandAverageProductRating SelectedBrandAverageProductRating
        {
            get { return selectedBrandAverageProductRatings; }
            set
            {
                if (value != null)
                {
                    selectedBrandAverageProductRatings = new BrandAverageProductRating()
                    {
                        BrandName = value.BrandName,
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

        public GetBrandAveragesRatingViewModel()
        {
            if (!IsInDesignMode)
            {
                List<BrandAverageProductRating> items = new List<BrandAverageProductRating>();
                client.BaseAddress = new Uri(baseURl);
                HttpResponseMessage response = client.GetAsync(endPoint).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    items = response.Content.ReadAsAsync<List<BrandAverageProductRating>>().GetAwaiter().GetResult();
                    BrandAverageProductRatings = items;
                }
            }

        }
    }
}
