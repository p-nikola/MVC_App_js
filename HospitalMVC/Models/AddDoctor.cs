using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalMVC.Models
{
    public class AddDoctorViewModel
    {

        public AddDoctorViewModel() { 
        
            Doctors = new List<Doctor>();   
        }
        public int HospitalId { get; set; }

        [Display(Name = "Select Doctor")]
        public int SelectedDoctorId { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
