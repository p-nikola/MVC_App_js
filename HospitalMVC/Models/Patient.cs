using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMVC.Models
{
    public class Patient
    {

        public Patient()
        {

            Doctors = new List<Doctor>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Kodot mora da se sostoi od 5 cifri")]
        [Display(Name = "Kod na pacient")]
        public string PatientCode { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }


    }
}