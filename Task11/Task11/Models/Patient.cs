using System.ComponentModel.DataAnnotations;

namespace Task11.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public DateOnly Birthdate { get; set; }
    
    public ICollection<Prescription> Prescription { get; set; }
}