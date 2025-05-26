namespace Task11.DTOs;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public DoctorDto Doctor { get; set; }

    public List<MedicamentWithNameDto> Medicament { get; set; }
}