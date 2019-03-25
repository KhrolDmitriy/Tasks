using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IGI_lab_1.Models
{
    class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int HospitalDepartmentID { get; set; }
        public virtual HospitalDepartment Department { get; set; }
        public string Specialty { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public Doctor()
        {
            Patients = new List<Patient>();
        }
    }
}