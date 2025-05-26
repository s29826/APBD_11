using Task11.DTOs;

namespace Task11.Services;

public interface IDbService
{
    Task AddPrescription(CreatePrescriptionDto dto);
    Task<PatientAllInfoDto> GetPatient(int idPatient);
}