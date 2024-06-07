using Cwiczenia_6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia_6.Controllers
{
    public class MainDBContext : DbContext
    {
        public MainDBContext()
        {

        }

        public MainDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s16467;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medicament>(opt =>
            {
                opt.HasKey(e => e.IdMedicament);
                opt.Property(e => e.IdMedicament).ValueGeneratedOnAdd();

                opt.Property(e => e.Name).IsRequired().HasMaxLength(100);
                opt.Property(e => e.Description).IsRequired().HasMaxLength(100);
                opt.Property(e => e.Type).IsRequired().HasMaxLength(100);

                opt.HasData(
                        new Medicament
                        {
                            IdMedicament=1,
                            Name="Med1",
                            Description="Med1 Desc",
                            Type="pill"
                        },
                        new Medicament
                        {
                            IdMedicament = 2,
                            Name = "Med2",
                            Description = "Med2 Desc",
                            Type = "cream"
                        },
                        new Medicament
                        {
                            IdMedicament = 3,
                            Name = "Med3",
                            Description = "Med3 Desc",
                            Type = "vaccine"
                        },
                        new Medicament
                        {
                            IdMedicament = 4,
                            Name = "Med4",
                            Description = "Med4 Desc",
                            Type = "antibiotics"
                        }
                    );

            });

            modelBuilder.Entity<Doctor>(opt =>
            {
                opt.HasKey(e => e.IdDoctor);
                opt.Property(e => e.IdDoctor).ValueGeneratedOnAdd();

                opt.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                opt.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                opt.Property(e => e.Email).IsRequired().HasMaxLength(100);

                opt.HasData(
                        new Doctor
                        {
                            IdDoctor=1,
                            FirstName="John",
                            LastName="Brown",
                            Email="j.brown@email.com"
                        },
                        new Doctor
                        {
                            IdDoctor = 2,
                            FirstName = "Andrew",
                            LastName = "White",
                            Email = "a.white@email.com"
                        },
                        new Doctor
                        {
                            IdDoctor = 3,
                            FirstName = "Walter",
                            LastName = "Anderson",
                            Email = "w.anderson@email.com"
                        },
                        new Doctor
                        {
                            IdDoctor = 4,
                            FirstName = "Mike",
                            LastName = "Handerson",
                            Email = "m.handerson@email.com"
                        }
                    );

            });

            modelBuilder.Entity<Patient>(opt =>
            {
                opt.HasKey(e => e.IdPatient);
                opt.Property(e => e.IdPatient).ValueGeneratedOnAdd();

                opt.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                opt.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                opt.Property(e => e.Birthdate).IsRequired();

                opt.HasData(
                        new Patient
                        {
                            IdPatient = 1,
                            FirstName="Jordan",
                            LastName="Finney",
                            Birthdate=DateTime.Today.Subtract(TimeSpan.FromDays(10101))
                        },
                        new Patient
                        {
                            IdPatient = 2,
                            FirstName = "Gordon",
                            LastName = "Ramsey",
                            Birthdate = DateTime.Today.Subtract(TimeSpan.FromDays(9321))
                        },
                        new Patient
                        {
                            IdPatient = 3,
                            FirstName = "Morgan",
                            LastName = "Freewoman",
                            Birthdate = DateTime.Today.Subtract(TimeSpan.FromDays(5832))
                        },
                        new Patient
                        {
                            IdPatient = 4,
                            FirstName = "Chris",
                            LastName = "Brown",
                            Birthdate = DateTime.Today.Subtract(TimeSpan.FromDays(1232))
                        }
                    );

            });

            modelBuilder.Entity<Prescription>(opt =>
            {
                opt.HasKey(e => e.IdPrescription);
                opt.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

                opt.Property(e => e.Date).IsRequired();
                opt.Property(e => e.DueDate).IsRequired();

                opt.HasOne(e => e.Doctor)
                    .WithMany(d => d.Prescriptions)
                    .HasForeignKey(d => d.IdPrescription);

                opt.HasOne(e => e.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(p => p.IdPrescription);

                opt.HasData(
                        new Prescription
                        {
                            IdPrescription=1,
                            Date=DateTime.Now,
                            DueDate=DateTime.Now.AddMonths(2),
                            IdDoctor=1,
                            IdPatient=2
                        },
                        new Prescription
                        {
                            IdPrescription = 2,
                            Date = DateTime.Now,
                            DueDate = DateTime.Now.AddMonths(4),
                            IdDoctor = 2,
                            IdPatient = 2
                        },
                        new Prescription
                        {
                            IdPrescription = 3,
                            Date = DateTime.Now,
                            DueDate = DateTime.Now.AddMonths(1),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new Prescription
                        {
                            IdPrescription = 4,
                            Date = DateTime.Now,
                            DueDate = DateTime.Now.AddMonths(8),
                            IdDoctor = 4,
                            IdPatient = 4
                        }
                    );

            });

            modelBuilder.Entity<Prescription_Medicament>(opt =>
            {
                opt.HasKey(e => new
                {
                    e.IdMedicament,
                    e.IdPrescription
                });

                opt.Property(e => e.Details).IsRequired().HasMaxLength(100);

                opt.HasOne(e => e.Medicament)
                    .WithMany(m => m.Prescription_Medicaments)
                    .HasForeignKey(m => m.IdPrescription);

                opt.HasOne(e => e.Prescription)
                    .WithMany(p => p.Prescription_Medicaments)
                    .HasForeignKey(p => p.IdMedicament);

                opt.HasData(
                        new Prescription_Medicament
                        {
                            IdMedicament=1,
                            IdPrescription=2,
                            Dose=null,
                            Details="details of prescription_medicament nr 1"
                        },
                        new Prescription_Medicament
                        {
                            IdMedicament = 2,
                            IdPrescription = 1,
                            Dose = 200,
                            Details = "details of prescription_medicament nr 2"
                        },
                        new Prescription_Medicament
                        {
                            IdMedicament = 1,
                            IdPrescription = 3,
                            Dose = 300,
                            Details = "details of prescription_medicament nr 3"
                        },
                        new Prescription_Medicament
                        {
                            IdMedicament = 3,
                            IdPrescription = 4,
                            Dose = 30,
                            Details = "details of prescription_medicament nr 4"
                        }
                    );

            });
        }



    }
}
