namespace Task11.DTOs;

public class CreatePrescriptionDto
{
    public PatientDto Patient { get; set; }
    public int IdDoctor { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    
    public List<MedicamentDto> Medicaments { get; set; }
}