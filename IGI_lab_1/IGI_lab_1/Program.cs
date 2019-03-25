using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using IGI_lab_1.Models;

namespace IGI_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var db = new HospitalDB();
            IGI_lab_1.InicializerDB.Inicialize(db);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Вывести записи об отделениях больницы");
                Console.WriteLine("2. Вывести записи о докторах");
                Console.WriteLine("3. Вывести записи о пациентах");
                Console.WriteLine("4. Вывести список пациентов по отделениям больницы");
                Console.WriteLine("5. Вывести список пациентов каждого врача");
                Console.WriteLine("6. Вывести список пациентов сгруппированное по категориям врачей");
                Console.WriteLine("7. Вывести список пациентов сгруппированное по специальностям врачей");
                Console.WriteLine("8. Добавить пациента");
                Console.WriteLine("9. Удалить пациента");
                Console.WriteLine("0. Обновить пациента");

                string action = Console.ReadLine();
                Console.Clear();
                switch (action)
                {
                    case "1":
                        ViewHospitalDepartments(GetHospitalDepartmentList(db));
                        break;
                    case "2":
                        ViewDoctors(db);
                        break;
                    case "3":
                        ViewPatients(GetPatientList(db));
                        break;
                    case "4":
                        PatientlistByNameHospitalDepartment(db);
                        break;
                    case "5":
                        PatientlistByDoctor(db);
                        break;
                    case "6":
                        GroupPatientlistByCategory(db);
                        break;
                    case "7":
                        GroupPatientlistBySpecialty(db);
                        break;
                    case "8":
                        Console.WriteLine("Введите имя пациента");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Введите адрес пациента");
                        string address = Console.ReadLine();
                        Console.WriteLine("Введите палату пациента");
                        string chamber = Console.ReadLine();
                        Console.WriteLine("Введите диагноз пациента");
                        string diagnosis = Console.ReadLine();
                        ViewDoctors(db);
                        Console.WriteLine("Введите ID лечащего врача");
                        string attendingDoctorID = Console.ReadLine();
                        Console.WriteLine("Введите дату поступления");
                        DateTime arrivalData = Convert.ToDateTime(Console.ReadLine());

                        AddPatient(db, new Patient
                        {
                            FullName = fullName,
                            Address = address,
                            Chamber = Int32.Parse(chamber),
                            Diagnosis = diagnosis,
                            AttendingDoctorID = Int32.Parse(attendingDoctorID),
                            ArrivalData = arrivalData
                        });
                        break;
                    case "9":
                        ViewPatients(GetPatientList(db));
                        Console.WriteLine("Введите ID пациента, которого нужно удалить");
                        int id = Int32.Parse(Console.ReadLine());
                        DeletePatient(db, id);
                        break;
                    case "0":
                        ViewPatients(GetPatientList(db));
                        Console.WriteLine("Введите ID пациента");
                        id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите имя пациента");
                        fullName = Console.ReadLine();
                        Console.WriteLine("Введите адрес пациента");
                        address = Console.ReadLine();
                        Console.WriteLine("Введите палату пациента");
                        chamber = Console.ReadLine();
                        Console.WriteLine("Введите диагноз пациента");
                        diagnosis = Console.ReadLine();
                        ViewDoctors(db);
                        Console.WriteLine("Введите ID лечащего врача");
                        attendingDoctorID = Console.ReadLine();
                        Console.WriteLine("Введите дату поступления");
                        arrivalData = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Введите дату выписки");
                        DateTime statementData = Convert.ToDateTime(Console.ReadLine());

                        UpdatePatient(db, id, new Patient
                        {
                            FullName = fullName,
                            Address = address,
                            Chamber = Int32.Parse(chamber),
                            Diagnosis = diagnosis,
                            AttendingDoctorID = Int32.Parse(attendingDoctorID),
                            ArrivalData = arrivalData,
                            StatementData = statementData
                        });
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }

        static List<HospitalDepartment> GetHospitalDepartmentList(HospitalDB db)
        {
            List<HospitalDepartment> hospitalDepartments = null;
            hospitalDepartments = db.HospitalDepartments.ToList();
            return hospitalDepartments;
        }

        static void ViewHospitalDepartments(List<HospitalDepartment> hospitalDepartments)
        {
            Console.WriteLine(". ID  .          Name          . Capacity .");
            foreach (HospitalDepartment hospitalDepartment in hospitalDepartments)
            {
                Console.WriteLine(String.Format("|{0,5}|{1,24}|{2,10}|", hospitalDepartment.HospitalDepartmentID, hospitalDepartment.NameOfDepartment, hospitalDepartment.Capacity));
                Console.WriteLine("|_____|________________________|__________|");
            }
        }

        static List<Doctor> GetDoctorList(HospitalDB db)
        {
            List<Doctor> doctors = null;
            doctors = db.Doctors.ToList();
            return doctors;
        }

        static void ViewDoctors(HospitalDB db)
        {
            Console.WriteLine(". ID  .   Name   . DepartmentID . Speciality . Category .");
            foreach (Doctor doctor in db.Doctors)
            {
                Console.WriteLine(String.Format("|{0,5}|{1,10}|{2,14}|{3,12}|{4,10}|", doctor.DoctorID,
                    doctor.DoctorName, doctor.HospitalDepartmentID, doctor.Specialty, doctor.Category));
                Console.WriteLine("|_____|__________|______________|____________|__________|");
            }
        }

        static List<Patient> GetPatientList(HospitalDB db)
        {
            List<Patient> patients = null;
            patients = db.Patients.ToList();
            return patients;
        }

        static void ViewPatients(List<Patient> patients)
        {
            Console.WriteLine(". ID  .    Name    .  Address   .  Chamber   . Diagnosis  . DoctorID .   ArrivalData    .  StatementData   .");
            foreach (Patient patient in patients)
            {
                Console.WriteLine(String.Format("|{0,5}|{1,12}|{2,12}|{3,12}|{4,12}|{5,10}|{6,18}|{7,18}|",
                    patient.PatientID, patient.FullName, patient.Address, patient.Chamber,
                    patient.Diagnosis, patient.AttendingDoctorID, patient.ArrivalData, patient.StatementData));
                Console.WriteLine("|_____|____________|____________|____________|____________|__________|__________________|__________________|");
            }
        }

        static void AddPatient(HospitalDB db, Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
        }

        static void DeletePatient(HospitalDB db, int id)
        {
            var tmp = db.Patients.Where(a => a.PatientID == id);
            var oldValue = db.Patients.Where(a => a.PatientID == id);

            db.Patients.RemoveRange(oldValue);
            db.SaveChanges();
        }

        static void UpdatePatient(HospitalDB db, int id, Patient patient)
        {
            Patient oldValue = db.Patients.Where(a => a.PatientID == id).First();

            oldValue.FullName = patient.FullName;
            oldValue.Address = patient.Address;
            oldValue.Chamber = patient.Chamber;
            oldValue.Diagnosis = patient.Diagnosis;
            oldValue.AttendingDoctorID = patient.AttendingDoctorID;
            oldValue.ArrivalData = patient.ArrivalData;
            oldValue.StatementData = patient.StatementData;

            db.SaveChanges();
        }

        static void PatientlistByNameHospitalDepartment(HospitalDB db)
        {
            string nameDep = "";
            var list1 =
                from h in db.HospitalDepartments
                join d in db.Doctors on h.HospitalDepartmentID equals d.HospitalDepartmentID
                join p in db.Patients on d.DoctorID equals p.AttendingDoctorID
                orderby h.NameOfDepartment
                select new { p.FullName, p.Address, h.NameOfDepartment};

            foreach (var item in list1)
            {
                if (nameDep != item.NameOfDepartment.ToString())
                {
                    nameDep = item.NameOfDepartment.ToString();
                    Console.WriteLine("\n" + nameDep);
                }
                Console.WriteLine(item.ToString());
            }
        }

        static void PatientlistByDoctor(HospitalDB db)
        {
            string nameDoctor = "";
            var list1 =
                from p in db.Patients
                join d in db.Doctors on p.AttendingDoctorID equals d.DoctorID
                orderby d.DoctorName
                select new { p.FullName, p.Address, d.DoctorName };

            foreach (var item in list1)
            {
                if (nameDoctor != item.DoctorName.ToString())
                {
                    nameDoctor = item.DoctorName.ToString();
                    Console.WriteLine("\n" + nameDoctor);
                }
                Console.WriteLine(item.ToString());
            }
        }

        static void GroupPatientlistByCategory(HospitalDB db)
        {
            var result =
                from p in db.Patients
                group p by p.AttendingDoctor.Category;
            foreach (var group in result)
            {
                Console.WriteLine(group.Key);
                foreach (var t in group)
                    Console.WriteLine(t.FullName);
                Console.WriteLine();
            }
        }

        static void GroupPatientlistBySpecialty(HospitalDB db)
        {
            var result =
                from p in db.Patients
                group p by p.AttendingDoctor.Specialty;
            foreach (var group in result)
            {
                Console.WriteLine(group.Key);
                foreach (var t in group)
                    Console.WriteLine(t.FullName);
                Console.WriteLine();
            }
        }
    }
}
