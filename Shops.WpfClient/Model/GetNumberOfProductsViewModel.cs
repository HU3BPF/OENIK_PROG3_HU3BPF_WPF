using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Shops.Models.NonCrudClasses;
using System.Net.Http;

namespace Shops.WpfClient.Model
{
    internal class GetNumberOfProductsViewModel : ObservableRecipient
    {
        private String baseURl = "http://localhost:51395/Stat/";
        private String endPoint = "ShopNumberOfProduct";
        private HttpClient client = new HttpClient();
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public List<ShopNumberOfProduct> ShopNumberOfProducts { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GetNumberOfProductsViewModel()
        {
            if (!IsInDesignMode)
            {
                List<ShopNumberOfProduct> items = new List<ShopNumberOfProduct>();
                client.BaseAddress = new Uri(baseURl);
                HttpResponseMessage response = client.GetAsync(endPoint).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    items = response.Content.ReadAsAsync<List<ShopNumberOfProduct>>().GetAwaiter().GetResult();
                    ShopNumberOfProducts = items;
                }
            }

        }
    }
}
