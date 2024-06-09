using WebApplication2.DTOs;

namespace WebApplication2.Repositories;

public interface IHospitalRepository
{
    public Task<int> EnsurePatientExists(int id, CancellationToken token);
    public Task<PatientInfoDTO> GetPatientInfo(int id, CancellationToken token);
}