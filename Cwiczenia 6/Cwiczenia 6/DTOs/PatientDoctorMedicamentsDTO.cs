using Cwiczenia_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia_6.DTOs
{
    public class PatientDoctorMedicamentsDTO
    {
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientBirthdate { get; set; }

        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorEmail { get; set; }

        public IEnumerable<Medicament> Medicaments { get; set; }


    }
}
