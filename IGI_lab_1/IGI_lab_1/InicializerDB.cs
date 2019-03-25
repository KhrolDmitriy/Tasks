using System;
using System.Collections.Generic;
using System.Linq;
using IGI_lab_1.Models;
using System.Text;

namespace IGI_lab_1
{
    class InicializerDB
    {
        static public void Inicialize(HospitalDB db)
        {
            db.Database.EnsureCreated();

            if (db.HospitalDepartments.Any())
               return;            
            List<string> names = new List<string>(new string[] {
                "HospitalDepartment_1", "HospitalDepartment_2", "HospitalDepartment_3"
            });
            Random rand = new Random();
            foreach (string name in names)
            {
                db.HospitalDepartments.Add(new HospitalDepartment
                {
                    NameOfDepartment = name,
                    Capacity = rand.Next(10, 20)
                });
            }

            db.SaveChanges();

            names = new List<string>(new string[] {
                "Doctor_1", "Doctor_2", "Doctor_3", "Doctor_4", "Doctor_5", "Doctor_6"
            });
            int k = 0;
            foreach (string name in names)
            {
                db.Doctors.Add(new Doctor
                {
                    DoctorName = name,
                    HospitalDepartmentID = rand.Next(1, 4),
                    Specialty = "sp" + (k % 3).ToString(),
                    Category = "ctgr" + (k % 3).ToString()
                });
                k++;
            }

            db.SaveChanges();

            names = new List<string>(new string[] {
                "Patient_1", "Patient_2", "Patient_3", "Patient_4", "Patient_5", "Patient_6",
                "Patient_7", "Patient_8", "Patient_9", "Patient_10", "Patient_11", "Patient_12"
            });
            DateTime today = DateTime.Now.Date;
            k = 0;

            foreach (string name in names)
            {
                db.Patients.Add(new Patient
                {
                    FullName = name,
                    Address = "adress",
                    Chamber = rand.Next(10, 40),
                    Diagnosis = "",
                    AttendingDoctorID = rand.Next(1, 7),
                    ArrivalData = today.AddDays(-k),
                    StatementData = new DateTime()
                });
                k++;
            }

            db.SaveChanges();
        }
    }
}
