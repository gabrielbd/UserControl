using UserControl.Domain.Interfaces.Repositories;
using UserControl.Domain.Interfaces.Services;
using UserControl.Domain.Services;
using UserControl.Infra.Contexts;
using UserControl.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UserControl.Test.Unit
{
    public class Setup : Xunit.Di.Setup
    {
        protected override void Configure()
        {
            ConfigureAppConfiguration((hostingContext, config) =>
            {
                bool reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);
                if (hostingContext.HostingEnvironment.IsDevelopment())
                    config.AddUserSecrets<Setup>(true, reloadOnChange);
            });

            ConfigureServices((context, services) =>
            {
                var config = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                config.AddJsonFile(path, false);

                var root = config.Build();
                var connectionString = root.GetSection("ConnectionStrings").GetSection("UserControlBd").Value;

                services.AddDbContext<SqlContexts>(options => options.UseSqlServer(connectionString));

                services.AddTransient<IUserControlRepository, UserControlRepository>();
                services.AddTransient<IUserControlDomainService, UserControlDomainService>();

            });
        }
    }
}
