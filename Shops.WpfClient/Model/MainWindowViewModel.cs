using Microsoft.Toolkit.Mvvm.Input;
using Shops.WpfClient.View;
using Shops.WpfClient.View.NonCruds;
using System;
using System.Windows.Input;

namespace Shops.WpfClient
{
    public class MainWindowViewModel
    {
        public ICommand ShopsCommand { get; set; }
        public ICommand BrandsCommand { get; set; }
        public ICommand ProductsCommand { get; set; }
        public ICommand GetBrandAveragePricesCommand { get; set; }
        public ICommand GetBrandAveragesRatingCommand { get; set; }
        public ICommand GetNumberOfProductsCommand { get; set; }
        public ICommand GetShopAveragePriceCommand{ get; set; }
        public ICommand GetShopAverageRatingCommand{ get; set; }
        public ICommand ExitCommand { get; set; }

        public MainWindowViewModel()
        {
            ShopsCommand = new RelayCommand(() =>
            {
                ShopEditorWindow shopEditor = new ShopEditorWindow();
                shopEditor.ShowDialog();
            });

            BrandsCommand = new RelayCommand(() =>
            {
                BrandEditorWindow brandEditor = new BrandEditorWindow();
                brandEditor.ShowDialog();
            });

            ProductsCommand = new RelayCommand(() =>
            {
                ProductEditorWindow productEditor = new ProductEditorWindow();
                productEditor.ShowDialog();
            });

            GetBrandAveragePricesCommand = new RelayCommand(() =>
            {
                GetBrandAveragePricesWindow GetBrandAveragePricesEditor = new GetBrandAveragePricesWindow();
                GetBrandAveragePricesEditor.ShowDialog();
            });

            GetBrandAveragesRatingCommand = new RelayCommand(() =>
            {
                GetBrandAveragesRatingWindow GetBrandAveragesRatingEditor = new GetBrandAveragesRatingWindow();
                GetBrandAveragesRatingEditor.ShowDialog();
            });

            GetNumberOfProductsCommand = new RelayCommand(() =>
            {
                GetNumberOfProductsWindow GetNumberOfProductsEditor = new GetNumberOfProductsWindow();
                GetNumberOfProductsEditor.ShowDialog();
            });

            GetShopAveragePriceCommand = new RelayCommand(() =>
            {
                GetShopAveragePriceWindow GetShopAveragePriceEditor = new GetShopAveragePriceWindow();
                GetShopAveragePriceEditor.ShowDialog();
            });

            GetShopAverageRatingCommand = new RelayCommand(() =>
            {
                GetShopAverageRatingWindow getShopAverageRatingEditor = new GetShopAverageRatingWindow();
                getShopAverageRatingEditor.ShowDialog();
            });

            ExitCommand = new RelayCommand(() => Environment.Exit(0));
        }
    }
}
