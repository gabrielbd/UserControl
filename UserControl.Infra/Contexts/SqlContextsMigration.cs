using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace UserControl.Infra.Contexts
{
    public class SqlContextsMigration : IDesignTimeDbContextFactory<SqlContexts>
    {
        public SqlContexts CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);

            var root = config.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("UserControlBd").Value;

            var builder = new DbContextOptionsBuilder<SqlContexts>();
            builder.UseSqlServer(connectionString);

            return new SqlContexts(builder.Options);
        }
    }
}
