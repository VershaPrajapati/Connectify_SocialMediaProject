using Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Data;
using FollowMicroservice.DataAccessLayer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Connectify_SocialMediaProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure the database contexts
            services.AddDbContext<PostDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PostMicroserviceConnection")));

            services.AddDbContext<FollowDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FollowMicroserviceConnection")));

            // Add other necessary services and dependencies

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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Enable HTTPS redirection if needed
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
