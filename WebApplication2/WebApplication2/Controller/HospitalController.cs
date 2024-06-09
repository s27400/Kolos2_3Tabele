using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Services;

namespace WebApplication2.Controller;

[ApiController]
[Route("api/[controller]")]
public class HospitalController : ControllerBase
{
    private readonly IHospitalService _hospitalService;

    public HospitalController(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetPatient(int patientId, CancellationToken token)
    {
        PatientInfoDTO dto = await _hospitalService.GetPatient(patientId, token);

        if (dto.IdPatient == -199)
        {
            return NotFound($"Patient with id: {patientId} not found");
        }

        return Ok(dto);
    }
}