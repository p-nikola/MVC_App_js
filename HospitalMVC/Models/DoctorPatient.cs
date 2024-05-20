using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMVC.Models
{
    public class DoctorPatient
    {


        public DoctorPatient()
        {
            patients = new List<Patient>();

        }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public Doctor doctor { get; set; }

        public List<Patient> patients { get; set; }


    }
}