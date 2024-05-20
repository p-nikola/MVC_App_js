using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMVC.Models
{
    public class Hospital
    {
        public Hospital()
        {
            Doctors = new List<Doctor>();

        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }


    }
}