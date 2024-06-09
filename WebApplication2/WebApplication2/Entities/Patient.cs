namespace WebApplication2.Entities;

public class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public virtual ICollection<Prescription> IdPrescriptions { get; set; } = new List<Prescription>();
}