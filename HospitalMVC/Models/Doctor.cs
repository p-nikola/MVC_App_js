using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMVC.Models
{
    public class Doctor
    {

        public Doctor()
        {

            Patients = new List<Patient>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public string Gender { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        
        public int ?HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

    }
}