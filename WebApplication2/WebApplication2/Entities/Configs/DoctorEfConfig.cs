using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Entities.Configs;

public class DoctorEfConfig : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(x => x.IdDoctor).HasName("IdDoctor");
        builder.Property(x => x.IdDoctor).UseIdentityColumn();

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

        builder.ToTable("Doctor");

        Doctor[] doctors =
        {
            new Doctor()
            {
                IdDoctor = 1, FirstName = "Anna", LastName = "Nowak", Email = "AnNo@wp.pl"
            },
            new Doctor()
            {
                IdDoctor = 2, FirstName = "Michal", LastName = "Malinowski", Email = "MiMa@wp.pl"
            }
        };

        builder.HasData(doctors);
    }
}