using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Entities.Configs;

public class PrescriptionEfConfig : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(x => x.IdPrescription).HasName("IdPrescription");
        builder.Property(x => x.IdPrescription).UseIdentityColumn();

        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.DueDate).IsRequired();

        builder.HasOne(x => x.DoctorNavigation)
            .WithMany(x => x.IdPrescriptions)
            .HasForeignKey(x => x.IdDoctor)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PatientNavigation)
            .WithMany(x => x.IdPrescriptions)
            .HasForeignKey(x => x.IdPatient)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Prescription");

        Prescription[] prescriptions =
        {
            new Prescription()
            {
                IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddMonths(1), IdDoctor = 1,
                IdPatient = 1
            },
            new Prescription()
            {
                IdPrescription = 2, Date = DateTime.Now.AddDays(10), DueDate = DateTime.Now.AddMonths(3), IdDoctor = 1,
                IdPatient = 2
            },
            new Prescription()
            {
                IdPrescription = 3, Date = DateTime.Now.AddMonths(1), DueDate = DateTime.Now.AddMonths(2), IdDoctor = 2,
                IdPatient = 1
            }
        };

        builder.HasData(prescriptions);
    }
}