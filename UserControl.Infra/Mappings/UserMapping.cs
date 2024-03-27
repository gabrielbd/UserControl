using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserControl.Domain.Entities;

namespace UserControl.Infra.Mappings
{
    public class UserMapping : BaseMapping<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("user");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasColumnName("Email");
            builder.Property(c => c.Password).IsRequired().HasColumnName("Password");

        }
    }
}
