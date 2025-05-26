namespace Task11.DTOs;

public class PatientAllInfoDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }

    public List<PrescriptionDto> Prescription { get; set; }
}