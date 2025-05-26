using Microsoft.EntityFrameworkCore;
using Task11.Models;

namespace Task11.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor() { IdDoctor = 1, FirstName = "Johnny", LastName = "Johns", Email = "123@gmail.com" },
            new Doctor() { IdDoctor = 2, FirstName = "Adam", LastName = "Apple", Email = "321@gmail.com" },
        });
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament() { IdMedicament = 1, Name = "Apap", Description = "Strong", Type = "Pill" },
            new Medicament() { IdMedicament = 2, Name = "Ibuprom", Description = "Strong", Type = "Pill" },
        });
    }
}