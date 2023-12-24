using Microsoft.Data.SqlClient;
using RestfulApiExample.Repositories;
using RestfulApiExample.Services;
using System.Data;

namespace RestfulApiExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = Configuration.GetSection("ConnectionStrings");
            string connectionString = configuration["DefaultConnection"];

            services.AddSingleton<IDbConnection>(provider => new SqlConnection(connectionString));
            services.AddTransient<IAdvertRepository, AdvertRepository>();
            services.AddTransient<IAdvertService, AdvertService>();
            services.AddControllers(); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // ...
            });
        }
    }
}
