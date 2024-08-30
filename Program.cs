using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
namespace CollegeAdmission
{
    class Program
    {
        static List<StudentDetails> studentDetailList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentDetailList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionDetailList = new List<AdmissionDetails>();
        static StudentDetails currentStudent;
        public static void Main()
        {
            AddDefault();

            string check = "yes";
            string option;
            Console.WriteLine("---Syncfusion College of Engineering Technology---");
            Console.WriteLine();
            do
            {
                // create main menu
                Console.WriteLine("---Main Menu---");
                Console.WriteLine("Enter any one of the option");
                Console.WriteLine("1. Student Registration");
                Console.WriteLine("2. Studnet Login");
                Console.WriteLine("3. Department Wise Seat Availability");
                Console.WriteLine("4. Exit");
                // geting option from user

                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        {
                            // calling Registration method
                            StudentRegistration();
                            break;
                        }
                    case "2":
                        {
                            // calling Login method
                            StudentLogin();
                            break;
                        }
                    case "3":
                        {
                            // calling DepartmentWiseSeatAvailability
                            DepartmentWiseSeatAvailability();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("You Selected Exit, Thank you!");
                            check = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid option");
                            break;
                        }
                }

            } while (check == "yes");
        }
        public static void StudentRegistration()
        {
            bool checkName = false;
            string StudentName;    // get valid name from user
            do
            {
                Console.WriteLine("Enter your Name");
                StudentName = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(StudentName) || !SpecialCharacterCheck(StudentName) || StudentName.Contains("  "))
                {
                    checkName = true;
                    Console.WriteLine("The name should not contain special characters or numeric values.");
                }
                else
                {
                    checkName = false;
                    break;
                }
            } while (checkName);

            bool checkName1 = false;
            string FatherName;    // get valid father name from user
            do
            {
                Console.WriteLine("Enter your Father Name");
                FatherName = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(FatherName) || !SpecialCharacterCheck(FatherName) || FatherName.Contains("  "))
                {
                    checkName1 = true;
                    Console.WriteLine("The name should not contain special characters or numeric values.");
                }
                else
                {
                    checkName1 = false;
                    break;
                }
            } while (checkName1);


            DateTime DateOfBirth;
            bool dateCheck = false;      // getting date of joining from employee
            do
            {
                Console.WriteLine("Enter Date of Joining (DD/MM/YYYY)");
                string date = Console.ReadLine();
                dateCheck = DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOfBirth);
                if (dateCheck)
                {
                    if (DateOfBirth < DateTime.Now)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid Date Of Joining");
                        dateCheck = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Date");
                }
            } while (!dateCheck);

            Gender Gender;
            bool checkGender = false;   // get valid gender from user
            do
            {
                Console.WriteLine("Enter your gender (Female/Male)");
                string gender = Console.ReadLine();
                checkGender = Enum.TryParse(gender, true, out Gender);
                if (checkGender)
                {
                    if (int.TryParse(gender, out _))
                    {
                        Console.WriteLine("Invalid gender input gender must be (Female/Male)");
                        checkGender = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid gender input gender must be (Female/Male)");
                    checkGender = false;
                }
            } while (!checkGender);

            // getting marks from user

            double Physics;
            bool physicscheck = false;   
            do
            {
                Console.WriteLine("Enter your Physics Mark");
                string mark = Console.ReadLine();
                physicscheck = double.TryParse(mark, out Physics);
                if (physicscheck && Physics == Math.Round(Physics, 2))
                {
                    if (Physics >= 35 && Physics <= 100)
                    {
                        break;
                    }
                    else if (Physics > 100)
                    {
                        Console.WriteLine("Mark must less than or equal to 100");
                        physicscheck = false;
                    }
                    else if (Physics < 0)
                    {
                        Console.WriteLine("Mark does not be a negative value");
                    }
                    else
                    {
                        Console.WriteLine("You are not eligible to take admission");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Mark must be a numeric value");
                    physicscheck = false;
                }
            } while (!physicscheck);

            double Chemistry;
            bool chemistrycheck = false;
            do
            {
                Console.WriteLine("Enter your Chemistry Mark");
                string mark = Console.ReadLine();
                chemistrycheck = double.TryParse(mark, out Chemistry);
                if (chemistrycheck && Chemistry == Math.Round(Chemistry, 2))
                {
                    if (Chemistry >= 35 && Chemistry <= 100)
                    {
                        break;
                    }
                    else if (Chemistry > 100)
                    {
                        Console.WriteLine("Mark must less than or equal to 100");
                        chemistrycheck = false;
                    }
                    else if (Chemistry < 0)
                    {
                        Console.WriteLine("Mark does not be a negative value");
                    }
                    else
                    {
                        Console.WriteLine("You are not eligible to take admission");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Mark must be a numeric value");
                    chemistrycheck = false;
                }
            } while (!chemistrycheck);

            double Maths;
            bool mathscheck = false;
            do
            {
                Console.WriteLine("Enter your Maths Mark");
                string mark = Console.ReadLine();
                mathscheck = double.TryParse(mark, out Maths);
                if (mathscheck && Maths == Math.Round(Maths, 2))
                {
                    if (Maths >= 35 && Maths <= 100)
                    {
                        break;
                    }
                    else if (Maths > 100)
                    {
                        Console.WriteLine("Mark must less than or equal to 100");
                        mathscheck = false;
                    }
                    else if (Maths < 0)
                    {
                        Console.WriteLine("Mark does not be a negative value");
                    }
                    else
                    {
                        Console.WriteLine("You are not eligible to take admission");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Mark must be a numeric value");
                    mathscheck = false;
                }
            } while (!mathscheck);

            StudentDetails student = new StudentDetails(StudentName, FatherName, DateOfBirth, Gender, Physics, Chemistry, Maths);
            studentDetailList.Add(student);

            Console.WriteLine();
            Console.WriteLine("Registered Successfully");
            Console.WriteLine("Your Student ID: " + student.StudentId);
            Console.WriteLine();

        }
        public static void StudentLogin()
        {
            // ask for student Id to login
            Console.WriteLine("Enter your student ID");
            string studentId = Console.ReadLine().ToUpper();
            bool check = false;
            foreach (StudentDetails student in studentDetailList)
            {
                if (student.StudentId == studentId)
                {
                    check = true;
                    currentStudent = student;
                    Console.WriteLine("Login Successfull");
                    Console.WriteLine();
                    SubMenu();

                }
            }
            if (!check)
            {
                Console.WriteLine("Invalid student ID");
            }
        }
        public static void SubMenu()
        {
            // to show sub menu

            Console.WriteLine("--Sub Menu--");
            string choose = "yes";
            string option;

            do
            {
                Console.WriteLine("choose one of the option");
                Console.WriteLine("1. Check Eligibility");
                Console.WriteLine("2. Show Details");
                Console.WriteLine("3. Take Admission");
                Console.WriteLine("4. Cancel Admission");
                Console.WriteLine("5. Show Admission Details");
                Console.WriteLine("6. Exit");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        {
                            // calling CheckEligibility method
                            CheckEligibility();
                            break;
                        }
                    case "2":
                        {
                            // calling ShowDetails method
                            ShowDetails();
                            break;
                        }
                    case "3":
                        {
                            // calling TakeAdmission method
                            TakeAdmission();
                            break;
                        }
                    case "4":
                        {
                            // calling CancelAdmission method
                            CancelAdmission();
                            break;
                        }
                    case "5":
                        {
                            // calling ShowAdmissionDetails method
                            ShowAdmissionDetails();
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("You selected Exit");
                            choose = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Option");
                            break;
                        }
                }
            } while (choose == "yes");
        }
        public static bool CheckEligibility()
        {

            double average = (currentStudent.Physics + currentStudent.Chemistry + currentStudent.Maths) / 3;
            if (average > 75.0)
            {
                Console.WriteLine("You are eligible to take admission");
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("You are not eligible to take admission");
                Console.WriteLine();
            }
            return false;

        }
        public static void ShowDetails()
        {
            Console.WriteLine("---Student Information---");
            Console.WriteLine("Name          : " + currentStudent.StudentName);
            Console.WriteLine("Father Name   : " + currentStudent.FatherName);
            Console.WriteLine("Date of Birth : " + currentStudent.DateOfBirth.ToString("dd/MM/yyyy"));
            Console.WriteLine("Gender        : " + currentStudent.Gender);
            Console.WriteLine("Physics Mark  : " + currentStudent.Physics);
            Console.WriteLine("Chemistry Mark: " + currentStudent.Chemistry);
            Console.WriteLine("Maths Mark    : " + currentStudent.Maths);
            Console.WriteLine();
        }
        public static void TakeAdmission()
        {
            // showing department details
            Console.WriteLine("---Department Details---");
            foreach (DepartmentDetails department in departmentDetailList)
            {
                Console.WriteLine("Department Id  : " + department.DepartmentId);
                Console.WriteLine("Department name: " + department.DepartmentName);
                Console.WriteLine("Number of seats: " + department.NumberOfSeats);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine();
            }
            // ask to choose one of the department ID
            Console.WriteLine("Select the department Id");
            string DepartmentId = Console.ReadLine().ToUpper();

            // checking user choosing is valid or not
            bool check = false;
            bool check1 = false;
            foreach (DepartmentDetails department1 in departmentDetailList)
            {
                if (department1.DepartmentId == DepartmentId)
                {
                    check = true;
                    if (CheckEligibility())
                    {
                        if (department1.NumberOfSeats > 0)
                        {
                            foreach (AdmissionDetails admission in admissionDetailList)
                            {
                                if (admission.StudentId == currentStudent.StudentId && admission.AdmissionStatus == AdmissionStatus.Admitted)
                                {
                                    check1 = true;
                                    break;
                                   
                                }
                            }
                            if(check1)
                            {
                                Console.WriteLine("You already have a admission");
                                Console.WriteLine();
                            }
                            else
                            {
                                // give admission
                                department1.NumberOfSeats--;
                               

                                // create object to store student details
                                AdmissionDetails admission1 = new AdmissionDetails(currentStudent.StudentId, DepartmentId, DateTime.Now, AdmissionStatus.Admitted);
                                admissionDetailList.Add(admission1);

                                Console.WriteLine("Your admission ID: " + admission1.AdmissionId);
                                Console.WriteLine();
                                Console.WriteLine("Admission took successfully");
                                
                                Console.WriteLine("Thank You!!");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Seats is not available");
                        }
                    }
                }
            }
            if (!check)
            {
                Console.WriteLine("Invalid Department ID");
            }
        }
        public static void CancelAdmission()
        {
            Console.WriteLine("---Admission Details---");
            bool check = false;
            foreach (AdmissionDetails admission in admissionDetailList)
            {
                if (admission.StudentId == currentStudent.StudentId && admission.AdmissionStatus == AdmissionStatus.Admitted)
                {
                    // showing admission details
                    check = true;
                    
                    Console.WriteLine("Admission Id     : " + admission.AdmissionId);
                    Console.WriteLine($"Student Id      : {admission.StudentId}");
                    Console.WriteLine($"Department Id   :{admission.DepartmentId}");
                    Console.WriteLine($"Admission Date  :{admission.AdmissionDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Admission Status:{AdmissionStatus.Cancelled}");
                    Console.WriteLine();

                    admission.AdmissionStatus = AdmissionStatus.Cancelled;
                    foreach (DepartmentDetails department in departmentDetailList)
                    {
                        if (admission.DepartmentId == department.DepartmentId)
                        {
                            // cancelling admission
                            department.NumberOfSeats++;
                            // Console.WriteLine("Seats: " + department.NumberOfSeats);
                            Console.WriteLine("Admission Cancelled Successfully");
                            Console.WriteLine();
                        }
                    }
                }
            }
            if (!check)
            {
                Console.WriteLine("You did not take any admission to cancel");
                Console.WriteLine();
            }
        }
        public static void ShowAdmissionDetails()
        {
            // showing admission details
            bool check = false;
            foreach (AdmissionDetails admission in admissionDetailList)
            {
                if (admission.StudentId == currentStudent.StudentId)
                {
                    check = true;
                    Console.WriteLine("---Admission Details---");
                    Console.WriteLine("Admission Id    : " + admission.AdmissionId);
                    Console.WriteLine("Student Id      : " + admission.StudentId);
                    Console.WriteLine("Department Id   : " + admission.DepartmentId);
                    Console.WriteLine($"Admission Date  : {admission.AdmissionDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine("Admission Status: " + admission.AdmissionStatus);
                    Console.WriteLine("----------------------------------------------------------------------------------");
                }
            }
            if (!check)
            {
                Console.WriteLine("You don't have any admission details, your admission detail is empty");
                Console.WriteLine();
            }
        }
        public static void DepartmentWiseSeatAvailability()
        {
            // showing department wise seat availability
            Console.WriteLine("---Seat avaliability---");
            foreach (DepartmentDetails department in departmentDetailList)
            {
                Console.WriteLine("Department Id: " + department.DepartmentId);
                Console.WriteLine("Department Name: " + department.DepartmentName);
                Console.WriteLine("Number of seats: " + department.NumberOfSeats);
                Console.WriteLine("----------------------------------------------------------");
            }
        }
        public static void AddDefault()
        {
            // adding default values
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);

            studentDetailList.Add(student1);
            studentDetailList.Add(student2);

            DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails department4 = new DepartmentDetails("ECE", 30);

            departmentDetailList.Add(department1);
            departmentDetailList.Add(department2);
            departmentDetailList.Add(department3);
            departmentDetailList.Add(department4);

            AdmissionDetails admission1 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 05, 12), AdmissionStatus.Admitted);

            admissionDetailList.Add(admission1);
            admissionDetailList.Add(admission2);
        }
        public static bool SpecialCharacterCheck(string name)
        {
            // for checking special character present in name
            foreach (char value in name)
            {
                if (!char.IsLetter(value) && !char.IsWhiteSpace(value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}