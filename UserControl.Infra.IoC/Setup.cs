using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserControl.Infra.Contexts;

namespace UserControl.Infra.IoC
{
    public static class Setup
    {
        public static void AddEntityFrameworkServicess(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("UserControlBd");

            builder.Services.AddDbContext<SqlContexts>(options => options.UseSqlServer(connectionString));
        }
        public static void AddAutoMapperServicess(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

    }
}
