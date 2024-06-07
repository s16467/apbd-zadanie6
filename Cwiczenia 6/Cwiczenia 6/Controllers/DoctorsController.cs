using Cwiczenia_6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : Controller
    {
        private MainDBContext context;

        [HttpGet]
        public IActionResult getDoctors()
        {
            context = new MainDBContext();
            
            return Ok(context.Doctors);
        }

        [HttpPost]
        public IActionResult addDoctor([FromBody] Doctor doctor)
        {
            context = new MainDBContext();

            context.Doctors.Add(doctor);

            context.SaveChanges();

            return Ok("New Doctor succesfully added to database");
        }

        [HttpPut("{IdDoctor}")]
        public IActionResult updateDoctor(int IdDoctor, [FromBody] Doctor doctor)
        {
            context = new MainDBContext();

            // Validate if doctor with given id exists in DB
            if(context.Doctors.Where(d=> d.IdDoctor.Equals(IdDoctor)).Count() == 1)
            {
                Doctor doc = context.Doctors.Where(d => d.IdDoctor.Equals(IdDoctor)).First();

                doc.FirstName = doctor.FirstName;
                doc.LastName = doctor.LastName;
                doc.Email = doctor.Email;

                context.SaveChanges();
            }
            else
            {
                return BadRequest("Doctor with the given id: " + IdDoctor + " does not exist in the DB");
            }

            return Ok("Doctor with id: "+IdDoctor+" succesfully updated");
        }

        [HttpDelete("{IdDoctor}")]
        public IActionResult deleteDoctor(int IdDoctor)
        {
            context = new MainDBContext();

            // Validate if doctor with given id exists in DB
            if (context.Doctors.Where(d => d.IdDoctor.Equals(IdDoctor)).Count() == 1)
            {
                Doctor doctor = context.Doctors.Where(d => d.IdDoctor.Equals(IdDoctor)).First();
                context.Remove(doctor);
                context.SaveChanges();
            }
            else
            {
                return BadRequest("Doctor with the given id: " + IdDoctor + " does not exist in DB");
            }

            return Ok("Doctor with id: "+IdDoctor+" succesfully deleted from DB");
        }
    }
}
