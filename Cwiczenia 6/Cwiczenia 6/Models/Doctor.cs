using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia_6.Models
{
    public class Doctor
    {

        public int IdDoctor { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //public int? IdPrescription { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }

    }
}
