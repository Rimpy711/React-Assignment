using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { set; get; }
    public DbSet<Patient> Patients { set; get; }
    public DbSet<IntakeForm> IntakeForms { set; get; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(@"server=localhost;user=root;password=redhat;database=DoctorsOffice",
            ServerVersion.Parse("8.0.20-mysql")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "Dr. Jack Smith"
                },
                 new Doctor
                {
                    Id = 2,
                    Name = "Dr. Adam west"
                },
                 new Doctor
                {
                    Id = 3,
                    Name = "Dr. Diana Wilson"
                }
        );
        modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 1,
                    HealthNumber = 12355,
                    Name="Patient Mark",
                    Address="123 Main St., Wimnipeg",
                    DateOfBirth=new DateTime(1994,08,11),
                    PhoneNumber= "204 123-3452"
                }
        );
       
    }     
}