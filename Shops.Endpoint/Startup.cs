using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Shops.Repository;
using Shops.Logic;
using Shops.Data.Models;

namespace Shops.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IGoodsManagementLogic, GoodsManagementLogic>();
            services.AddTransient<IShopManagementLogic, ShopManagementLogic>();
            services.AddTransient<IRepositoryProduct, RepositoryProduct>();
            services.AddTransient<IRepositoryBrand, BrandRepository>();
            services.AddTransient<IRepositoryShop, RepositoryShop>();
            services.AddTransient<DbContext, ShopsDbContext>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
