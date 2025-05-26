using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task11.Models;

public class Prescription
{
    [Key]
    public int IdPrescritption { get; set; }
    
    public DateOnly Date { get; set; }
    
    public DateOnly DueDate { get; set; }

    [ForeignKey(nameof(Patient))]
    public int IdPatient { get; set; }
    public Patient Patient { get; set; }

    [ForeignKey(nameof(Doctor))]
    public int IdDoctor { get; set; }
    public Doctor Doctor { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; }
}