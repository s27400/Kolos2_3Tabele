using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Entities.Configs;

public class PatientEfConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(x => x.IdPatient).HasName("IdPatient");
        builder.Property(x => x.IdPatient).UseIdentityColumn();

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Birthdate).IsRequired();

        builder.ToTable("Patient");

        Patient[] patients =
        {
            new Patient()
            {
                IdPatient = 1, FirstName = "Adam", LastName = "Kowalski", Birthdate = new DateTime(1990, 12, 12)
            },
            new Patient()
            {
                IdPatient = 2, FirstName = "Alicja", LastName = "Mickiewicz", Birthdate = new DateTime(1989, 11, 5)
            }
        };

        builder.HasData(patients);
    }
}