using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IGI_lab_1.Models
{
    class Patient
    {
        public int PatientID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        //public int HospitalDepartmentID { get; set; }
        public int Chamber { get; set; }
        public string Diagnosis { get; set; }
        public int AttendingDoctorID { get; set; }
        public virtual Doctor AttendingDoctor { get; set; }
        public DateTime ArrivalData { get; set; }
        public DateTime StatementData { get; set; }
    }
}