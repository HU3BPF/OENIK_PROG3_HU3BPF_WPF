using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Shops.Models;
using Shops.Models.NonCrudClasses;

namespace Shops.WpfClient.Model
{
    internal class GetBrandAveragePricesViewModel : ObservableRecipient
    {
        private String baseURl = "http://localhost:51395/Stat/";
        private String endPoint = "BrandAveragerProductPrice";
        private HttpClient client = new HttpClient();
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public List<BrandAveragerProductPrice> GetBrandAveragePrices { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GetBrandAveragePricesViewModel()
        {
            if (!IsInDesignMode)
            {
                List<BrandAveragerProductPrice> items = new List<BrandAveragerProductPrice>();
                client.BaseAddress = new Uri(baseURl);  
                HttpResponseMessage response = client.GetAsync(endPoint).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    items = response.Content.ReadAsAsync<List<BrandAveragerProductPrice>>().GetAwaiter().GetResult();
                }
                GetBrandAveragePrices = items;
            }

        }
    }
}
