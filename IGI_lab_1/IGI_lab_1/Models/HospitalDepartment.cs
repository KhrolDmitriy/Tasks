using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IGI_lab_1.Models
{
    class HospitalDepartment
    {
        public int HospitalDepartmentID { get; set; }
        public string NameOfDepartment { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public HospitalDepartment()
        {
            Doctors = new List<Doctor>();
        }
    }
}