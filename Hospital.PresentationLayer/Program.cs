/*Case Study: Hospital Management System
 * Developer: Hritwik Agarwal
 * Task: To apply CRUD Operation's on Patient's Dtails
 * Created: 05/02/2020 , 17:00 PM
 * Last Modified: 07/02/2020, 17:00 PM
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.HMS.BusinessLogicLayer;
using Capgemini.HMS.Entities;
using Capgemini.HMS.Exceptions;


namespace Hospital.PresentationLayer
{

    /// <summary>
    /// Main Class of the HSM Application 
    /// </summary>
    class Program
    {

        /// <summary>
        /// Main method of the Application that marks beginning of the application.
        /// </summary>
        /// <param name="args"> Main method that takes arguments at runtime. </param>
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("----------- Welcome to Hospital Management System ----------\n");
                Console.WriteLine("---------- Task: To apply Paitent's CRUD Operation ----------\n");
                //Calling print method to print method.
                PrintMenu();
                Console.WriteLine("Enter your Choice:");

                //Validation of choice entered by user, if wrong value entered then value asked again.
                int.TryParse(Console.ReadLine(), out choice);

                //Switch case to take value from thre user and then do the following crud operations.
                switch (choice)
                {
                    //case 1 to do addition operation.
                    case 1:
                        AddPatient();
                        break;

                    //case 2 to perform List all Patients operation.
                    case 2:
                        ListAllPatients();
                        break;

                    //case 3 to perform search a patient by it's operation.
                    case 3:
                        SearchPatientByID();
                        break;

                    //case 4 to perfrom update a patient's value by it's ID operation.
                    case 4:
                        UpdatePatient();
                        break;

                    //case 5 to perform deletion operation.
                    case 5:
                        DeletePatient();
                        break;

                    //case 6 to Quit/Exit the control.
                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }


        /// <summary>
        /// Represents Method that'll print menu
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("\n***********Patients Menu***********");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. List All Patients");
            Console.WriteLine("3. Search Patient by Patient ID");
            Console.WriteLine("4. Update Patients");
            Console.WriteLine("5. Delete Patients");
            Console.WriteLine("6. Exit");
            Console.WriteLine("******************************************\n");

        }


        /// <summary>
        /// Represents Presentation layer's Add a Patients Methods. 
        /// </summary>
        private static void AddPatient()
        {
            try
            {
                //Business logic Layer Object.
                PatientBusinessLogic patientBusinessLogic = new PatientBusinessLogic();

                //Entity class object.
                Patient newPatient = new Patient();

                //Get Patient ID.
                Console.WriteLine("Enter PatientId :");
                var inputPatientId = Console.ReadLine();
                byte patientId;
                while (!byte.TryParse(inputPatientId, out patientId))
                {
                    Console.WriteLine("Enter Valid  Patient ID");
                    inputPatientId = Console.ReadLine();
                }
                newPatient.PatientId = patientId;

                //Get Patient Name.
                Console.WriteLine("Enter Patient Name :");
                newPatient.PatientName = Console.ReadLine();

                //Get Patient Phone Number.
                Console.WriteLine("Enter PhoneNumber :");

                var inputPhoneNumber = Console.ReadLine();
                long patientPhoneNumber = 0;
                while (!long.TryParse(inputPhoneNumber, out patientPhoneNumber) || patientPhoneNumber.ToString().Length != 10)
                {
                    Console.WriteLine("Enter Valid  Patient Phone Number");
                    inputPhoneNumber = Console.ReadLine();
                    
                }
                newPatient.PatientPhoneNumber = patientPhoneNumber;

                //Get Patient Age.
                Console.WriteLine("Enter Patients Age :");
                var inputPatientAge = Console.ReadLine();
                byte patientAge;
                while (!byte.TryParse(inputPatientAge, out patientAge))
                {
                    Console.WriteLine("Enter a Valid  Patient Age between 1 - 100");
                    inputPatientAge = Console.ReadLine();
                }
                newPatient.PatientAge = patientAge;

                //Get Patient Address.
                Console.WriteLine("Enter Patients Address :");
                newPatient.PatientAddress = Console.ReadLine();

                //Get Patient Gender.
                Console.WriteLine("Enter Patients  Gender: M / F / O(for Other)");

                var inputPatientGender = Console.ReadLine();
                char patientGender;
                while (!char.TryParse(inputPatientGender, out patientGender) && (char.ToUpper(patientGender) != 'M' || char.ToUpper(patientGender) != 'F' || char.ToUpper(patientGender) != 'O'))
                {
                    Console.WriteLine("Enter a Valid  Patient Gender: F/f | M/m | O/o ");
                    inputPatientGender = Console.ReadLine();
                }
                newPatient.PatientGender = patientGender;

                //Get patient Weight. 
                Console.WriteLine("Enter Patients Weight :");

                var inputPatientWeight = Console.ReadLine();
                byte patientWeight;
                while (!byte.TryParse(inputPatientWeight, out patientWeight))
                {
                    Console.WriteLine("Enter a Valid  Patient Weight in Numerical Form: ");
                    inputPatientWeight = Console.ReadLine();
                }
                newPatient.PatientWeight = patientWeight;

                //Get patient Disease.
                Console.WriteLine("Enter Patients Disease :");
                newPatient.PatientDisease = Console.ReadLine();

                //Get patients doctor ID. 
                Console.WriteLine("Enter Patients Doctor ID :");
                var inputPatientDoctorId = Console.ReadLine();
                byte patientDoctorId;
                while (!byte.TryParse(inputPatientDoctorId, out patientDoctorId))
                {
                    Console.WriteLine("Enter Valid  Patient ID");
                    inputPatientDoctorId = Console.ReadLine();
                }
                newPatient.PatientDoctorId = patientDoctorId;

                //calls Add Patient method of Business Layer which will further validate wether the data entered is correct or not. 
                bool patientAdded = patientBusinessLogic.AddPatientBL(newPatient);
                if (patientAdded)
                    Console.WriteLine("Patient Added");
                else
                    Console.WriteLine("Patient not Added");
            }
            catch (PatientException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Represents Presentation layer's List all Patients Methods. 
        /// </summary>

        private static void ListAllPatients()
        {
            try
            {
                //Business logic Layer Object
                PatientBusinessLogic patientBusinessLogic = new PatientBusinessLogic();

                List<Patient> patientList = patientBusinessLogic.GetAllPatientBL();
                if (patientList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Patient\t\tName\t\tPhoneNumber\t\tAge\t\tGender\t\tWeigth\t\tAddress\t\tDisease\t\tDoctor ID");
                    Console.WriteLine("******************************************************************************");

                    // 'p' in for each loop will help retreiving each and every data of patient object.
                    foreach (Patient p in patientList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\t\t{8}"
                            , p.PatientId, p.PatientName, p.PatientPhoneNumber, p.PatientAge, p.PatientGender
                            , p.PatientWeight, p.PatientAddress, p.PatientDisease, p.PatientDoctorId);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Patient Details Available");
                }
            }
            catch (PatientException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Represents Presentation layer Search a Patient by it'd ID Methods. 
        /// </summary>

        private static void SearchPatientByID()
        {
            try
            {
                //Business logic Layer Object
                PatientBusinessLogic patientBusinessLogic = new PatientBusinessLogic();

                byte searchPatietID;
                Console.WriteLine("Enter PatientID to Search:");
                searchPatietID = Convert.ToByte(Console.ReadLine());
                Patient searchPatient = patientBusinessLogic.SearchPatientByIdBL(searchPatietID);
                if (searchPatient != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("PatientID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchPatient.PatientId, searchPatient.PatientName, searchPatient.PatientPhoneNumber);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Patient Details Available");
                }

            }
            catch (PatientException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Represents Presentation layer update Patients Methods. 
        /// </summary>
        private static void UpdatePatient()
        {
            try
            {
                //Business logic Layer Object.
                PatientBusinessLogic patientBusinessLogic = new PatientBusinessLogic();

                byte updatePatientID;
                Console.WriteLine("Enter Patient to Update Details:");
                updatePatientID = Convert.ToByte(Console.ReadLine());
                Patient updatedPatient = patientBusinessLogic.SearchPatientByIdBL(updatePatientID);
                if (updatedPatient != null)
                {
                    Console.WriteLine("Update Patient Name :");
                    updatedPatient.PatientName = Console.ReadLine();
                    Console.WriteLine("Update PhoneNumber :");
                    updatedPatient.PatientPhoneNumber = Convert.ToInt64(Console.ReadLine());
                    bool patientUpdated = patientBusinessLogic.UpdatePatientBL(updatedPatient);
                    if (patientUpdated)
                        Console.WriteLine("Patient Details Updated");
                    else
                        Console.WriteLine("Patient Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Patient Details Available");
                }


            }
            catch (PatientException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Represents Presentation layer delete method.
        /// </summary>
        private static void DeletePatient()
        {
            try
            {
                PatientBusinessLogic patientBusinessLogic = new PatientBusinessLogic();
                byte deletePatientID;

                Console.WriteLine("Enter Patient ID to Delete:");
                deletePatientID = Convert.ToByte(Console.ReadLine());
                Patient deletePatient = patientBusinessLogic.SearchPatientByIdBL(deletePatientID);
                if (deletePatient != null)
                {
                    bool patientdeleted = patientBusinessLogic.DeletePatientByIdBL(deletePatientID);
                    if (patientdeleted)
                        Console.WriteLine("Patient Deleted");
                    else
                        Console.WriteLine("Patient not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Patient Details Available");
                }


            }
            catch (PatientException ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
    }
}
