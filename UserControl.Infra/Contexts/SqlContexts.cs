using Microsoft.EntityFrameworkCore;
using UserControl.Domain.Entities;
using UserControl.Infra.Mappings;

namespace UserControl.Infra.Contexts
{
    public class SqlContexts: DbContext
    {
        public SqlContexts(DbContextOptions<SqlContexts> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());

        }

        public DbSet<User> User { get; set; }
    }
}
