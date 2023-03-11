using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using petshop_management.Data;
using petshop_management.Mappings;
using Microsoft.OpenApi.Models;

namespace petshop_management
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
            });
            ///<summary> 
            ///TESTE BATATA
            ///</summary>

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddControllersWithViews();

            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<ClientContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<AddressContext>(options => options.UseSqlServer(connectionString));
             services.AddDbContext<PetContext>(options => options.UseSqlServer(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "Client",
                    pattern: "{controller=Client}/{action=Index}"
                );
                endpoints.MapControllerRoute(
                    name: "Address",
                    pattern: "{controller=Address}/{action=Index}"
                );
                endpoints.MapControllerRoute(
                    name: "Pet",
                    pattern: "{controller=Pet}/{action=Index}"
                );
            });
        }
    }
}
