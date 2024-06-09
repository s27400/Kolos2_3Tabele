using Microsoft.EntityFrameworkCore;
using WebApplication2.DTOs;
using WebApplication2.Entities;

namespace WebApplication2.Repositories;

public class HospitalRepostiory : IHospitalRepository
{
    private readonly HospitalDbContext _context;

    public HospitalRepostiory(HospitalDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> EnsurePatientExists(int id, CancellationToken token)
    {
        var temp = await _context.Patients
            .FirstOrDefaultAsync(x => x.IdPatient == id, token);

        if (temp == null)
        {
            return -1;
        }

        return temp.IdPatient;
    }


    public async Task<PatientInfoDTO> GetPatientInfo(int id, CancellationToken token)
    {
        var query = _context.Patients
            .Where(x => x.IdPatient == id)
            .Include(x => x.IdPrescriptions)
            .ThenInclude(x => x.DoctorNavigation);

        var res = await query
            .Select(x => new PatientInfoDTO()
            {
                IdPatient = x.IdPatient,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Birthdate = x.Birthdate,
                Prescriptions = x.IdPrescriptions.Select(p => new PrescriptionDTO()
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new DoctorDTO()
                    {
                        FirstName = p.DoctorNavigation.FirstName,
                        IdDoctor = p.DoctorNavigation.IdDoctor
                    }
                }).ToList()
            }).ToListAsync(token);

        return res[0];
    }
}