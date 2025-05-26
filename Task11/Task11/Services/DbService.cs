using Microsoft.EntityFrameworkCore;
using Task11.Data;
using Task11.DTOs;
using Task11.Models;

namespace Task11.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddPrescription(CreatePrescriptionDto dto)
    {
        if (dto.Medicaments.Count > 10)
        {
            throw new ArgumentException();
        }

        if (dto.DueDate < dto.Date)
        {
            throw new ArgumentException();
        }

        foreach (var medicamentDto in dto.Medicaments)
        {
            var exists = await _context.Medicaments
                .AnyAsync(m => m.IdMedicament == medicamentDto.IdMedicament);

            if (!exists)
            {
                throw new KeyNotFoundException();
            }
        }
        
        var patient = _context.Patients
            .FirstOrDefault(p => p.FirstName == dto.Patient.FirstName
                                 && p.LastName == dto.Patient.LastName
                                 && p.Birthdate == dto.Patient.Birthdate);

        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = dto.Patient.FirstName,
                LastName = dto.Patient.LastName,
                Birthdate = dto.Patient.Birthdate
            };
            
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        var prescription = new Prescription
        {
            Date = dto.Date,
            DueDate = dto.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = dto.IdDoctor,
            PrescriptionMedicament = dto.Medicaments
                .Select(m => new PrescriptionMedicament
                {
                    IdMedicament = m.IdMedicament,
                    Dose = m.Dose,
                    Details = m.Description
                }).ToList()
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task<PatientAllInfoDto> GetPatient(int idPatient)
    {
        var patient = await _context.Patients
            .Where(p => p.IdPatient == idPatient)
            .Select(p => new PatientAllInfoDto
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = p.Birthdate,
                Prescription = p.Prescription
                    .OrderBy(pr => pr.DueDate)
                    .Select(pr => new PrescriptionDto
                    {
                        IdPrescription = pr.IdPrescritption,
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        Doctor = new DoctorDto
                        {
                            IdDoctor = pr.Doctor.IdDoctor,
                            FirstName = pr.Doctor.FirstName,
                            LastName = pr.Doctor.LastName,
                            Email = pr.Doctor.Email
                        },
                        Medicament = pr.PrescriptionMedicament
                            .Select(pm => new MedicamentWithNameDto
                            {
                                IdMedicament = pm.Medicament.IdMedicament,
                                Name = pm.Medicament.Name,
                                Dose = pm.Dose,
                                Description = pm.Details
                            }).ToList()
                    }).ToList()
            }).FirstOrDefaultAsync();

        
        return patient ?? throw new NullReferenceException();
    }
}