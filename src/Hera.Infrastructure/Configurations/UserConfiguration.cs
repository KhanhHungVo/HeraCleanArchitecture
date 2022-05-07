using Hera.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hera.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            // Seeding data for user
            builder.HasData(new User
                { Id = 1, Email = "heraadmin@gmail.com", UserName = "heraadmin", Password = "$2a$12$5Eh7piUI9mmYADj7FE99deuQvFoSnPvW13n9GvgR/ijGoI5ZDAo9.", Role = Role.Admin});
        }
    }
}
