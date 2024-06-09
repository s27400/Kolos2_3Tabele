using WebApplication2.DTOs;

namespace WebApplication2.Services;

public interface IHospitalService
{
    public Task<PatientInfoDTO> GetPatient(int idPatient, CancellationToken token);
}