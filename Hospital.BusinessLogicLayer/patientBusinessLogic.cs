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
using HMS.DataAccessLayer;
using HMS.Entities;
using HMS.Exceptions;

namespace HMS.BusinessLogicLayer
{

    /// <summary>
    /// Represents Patient's Business Logic Class.
    /// </summary>
    public class PatientBusinessLogic : IPatientBusinessLogic
    {
        /// <summary>
        /// Reference for PatientDataAccess;
        /// </summary>
        PatientDataAccess patientDAL;

        /// <summary>
        /// Constructor
        /// </summary>
        public PatientBusinessLogic()
        {
            if (patientDAL == null)
                patientDAL = new PatientDataAccess();
        }

        /// <summary>
        /// Represents a method to validate Patient Info.
        /// </summary>
        /// <param name="patient"> Patient Class Object whose entities will be validated. </param>
        /// <returns> Wether a data is valid or not! </returns>
        public bool ValidatePatient(Patient patient)
        {
            Patient newPatient = new Patient();

            //Used to store all the entities to a string.
            StringBuilder sb = new StringBuilder();

            // boolean value to return wether the is data  null or not.
            bool validPatient = true;

            //Validating Patient's ID, that wether it is null or less than 0.
            if (patient.PatientId == 0 || Convert.ToByte(patient.PatientId) <= 0 || Convert.ToByte(patient.PatientId) >= 256)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Invalid Patient ID! Please Enter ID between 1 to 255");

            }

            //Validating Patient's Name, that wether it is null or greater than 0.
            if (patient.PatientName.Length >= 50 || patient.PatientName == null || patient.PatientName == "")
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Patient Name Required! Enter an alphabetical name only with character range between 0 to 50: ");
            }
            
            //Validating Patient's Phone Number, that wether it is null or not.
            if (patient.PatientPhoneNumber.ToString().Length != 10)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "10 Digit Contact Number is Required");
            }

            //Validating Patient's Address, that wether it is null or greater than 0.
            if (patient.PatientAddress.Length >= 100 || patient.PatientAddress == null)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "A valid Patient's Address is Required! Enter address only with character range between 0 to 50: ");
            }

            //Validating Patient's Age, that wether it is 0.
            if (patient.PatientAge == 0)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Patient's Age is Invalid! Enter a numerical age only with range between 0 to 100: ");
            }

            //Validating Patient's Weight, that wether it is 0.
            if (patient.PatientWeight == 0)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Patient Weight is needed");
            }

            //Validating Patient's Gender, that wether it is M/F/Other.
            if (char.ToUpper(patient.PatientGender) != 'M' && char.ToUpper(patient.PatientGender) != 'F' && char.ToUpper(patient.PatientGender) != 'O')
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Patient's Gender is needed.");
            }

            //Validating Patient's Disease, that wether it is null or not.
            if (patient.PatientDisease == null | patient.PatientDisease.Length >= 50)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Require a valid Patient Disease: Enter an alphabetical name only with character range between 0 to 50: ");
            }

            //Validating Patient's Doctor ID, that wether it is null or less than 0.
            if (patient.PatientDoctorId == 0)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Require a valid doctor id: please enter a numerical Doctor ID between 1 to 255");
            }

            //Validating Patient's ID that wether it is null or less than 0.
            if (validPatient == false)
                throw new PatientException(sb.ToString());
            return validPatient;
        }


        /// <summary>
        /// Represents a method to add data as this method will further call data access layer add method.
        /// </summary>
        /// <param name="newPatient"> Object that is going to be added in the list and file of Patient. </param>
        /// <returns> Wether the data is added or not. </returns>
        public bool AddPatientBL(Patient newPatient)
        {
            bool patientAdded = false;
            try
            {
                if (ValidatePatient(newPatient))
                {
                    patientAdded = patientDAL.AddPatientDAL(newPatient);
                }
            }
            catch (PatientException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return patientAdded;
        }


        /// <summary>
        /// Represents a methodthat will return list of all patients.
        /// </summary>
        /// <returns> Returns list of all patients. </returns>
        public List<Patient> GetAllPatientBL()
        {
            List<Patient> patientList = null;
            try
            {
                patientList = patientDAL.GetAllPatientsDAL();
            }
            catch (PatientException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return patientList;
        }


        /// <summary>
        /// Represent a method to search a patient by it's ID.
        /// </summary>
        /// <param name="searchPatientID"> ID of patient to be Searched. </param>
        /// <returns> Boolean value that wether the patient data is present or not. </returns>
        public Patient SearchPatientByIdBL(byte searchPatientID)
        {
            Patient searchPatient = null;
            try
            {
                searchPatient = patientDAL.GetPatientByPatientID(searchPatientID);
            }
            catch (PatientException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchPatient;

        }

        /// <summary>
        /// Represents a method to update existing patient Value.
        /// </summary>
        /// <param name="updatePatient"> Patient object to check if there's any data present or not. </param>
        /// <returns> Whether the data of a patient is updated or not. </returns>
        public bool UpdatePatientBL(Patient updatePatient)
        {
            bool patientUpdated = false;
            try
            {
                if (ValidatePatient(updatePatient))
                {
                    patientUpdated = patientDAL.UpdatePatientDAL(updatePatient);
                }
            }
            catch (PatientException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return patientUpdated;
        }

        /// <summary>
        /// Represents a method to delete existing patient record.
        /// </summary>
        /// <param name="deletePatientID"> Patient ID whose record should be deleted. </param>
        /// <returns> Boolean value that wether the data is deleted or not. </returns>
        public bool DeletePatientByIdBL(byte deletePatientID)
        {
            bool patientDeleted = false;
            try
            {
                if (deletePatientID > 0)
                {
                    patientDeleted = patientDAL.DeletePatientDAL(deletePatientID);
                }
                else
                {
                    throw new PatientException("Invalid Patient ID");
                }
            }
            catch (PatientException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return patientDeleted;
        }

    }
}
