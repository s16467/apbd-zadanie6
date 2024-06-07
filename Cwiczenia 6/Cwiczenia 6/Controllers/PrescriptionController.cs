using Cwiczenia_6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia_6.DTOs;

namespace Cwiczenia_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : Controller
    {
        MainDBContext context;
        [HttpGet("{IdPrescription}")]
        public IActionResult getPrescription(int IdPrescription)
        {
            context = new MainDBContext();

            /*
            PatientDoctorMedicamentsDTO patientDoctorMedicamentsDTO = 
                context.Prescriptions
                .Where(p => p.IdPrescription.Equals(IdPrescription))
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .Include(p => p.Prescription_Medicaments)
                .ThenInclude(pm => pm.Medicament)
                .AsEnumerable()
                .Select(x => new PatientDoctorMedicamentsDTO
                {
                    PatientFirstName=x.Patient.FirstName,
                    PatientLastName=x.Patient.LastName,
                    PatientBirthdate=x.Patient.Birthdate,
                    DoctorFirstName=x.Doctor.FirstName,
                    DoctorLastName=x.Doctor.LastName,
                    DoctorEmail=x.Doctor.Email
                }).Single();

            */
            var result = context.Prescriptions
                .Where(p => p.IdPrescription.Equals(IdPrescription))
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .Include(p => p.Prescription_Medicaments)
                .ThenInclude(p => p.Medicament)
                .Select(x=> new PatientDoctorMedicamentsDTO
                {
                    PatientFirstName = x.Patient.FirstName,
                    PatientLastName = x.Patient.LastName,
                    PatientBirthdate = x.Patient.Birthdate,
                    DoctorFirstName = x.Doctor.FirstName,
                    DoctorLastName = x.Doctor.LastName,
                    DoctorEmail = x.Doctor.Email,
                    Medicaments = x.Prescription_Medicaments.Select(xx => xx.Medicament)
                
                });

            return Ok(result);
        }
    }
}
