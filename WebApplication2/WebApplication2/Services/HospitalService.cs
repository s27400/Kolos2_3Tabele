using WebApplication2.DTOs;
using WebApplication2.Entities;
using WebApplication2.Repositories;

namespace WebApplication2.Services;

public class HospitalService : IHospitalService
{
    private readonly IHospitalRepository _hospitalRepository;

    public HospitalService(IHospitalRepository hospitalRepository)
    {
        _hospitalRepository = hospitalRepository;
    }

    public async Task<PatientInfoDTO> GetPatient(int idPatient, CancellationToken token)
    {
        int verify = await _hospitalRepository.EnsurePatientExists(idPatient, token);

        if (verify == -1)
        {
            return new PatientInfoDTO()
            {
                IdPatient = -199,
                FirstName = "aaa",
                LastName = "bbbb",
                Birthdate = DateTime.Today,
                Prescriptions = new List<PrescriptionDTO>()
            };
        }

        return await _hospitalRepository.GetPatientInfo(idPatient, token);
    }

}