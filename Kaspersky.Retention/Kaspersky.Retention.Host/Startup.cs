using Kaspersky.Backup.Client.Extensions;
using Kaspersky.Retention.Services.Extensions.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kaspersky.Retention.Host
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
            => _configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBackupClient();
            services.AddClock();
            services.AddHealthChecks();
            services.AddScheduler(_configuration);
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseScheduler();
            app.UseHttpsRedirection();
            app.UseHealthChecks("/health");
            app.UseMvc();
        }
    }
}