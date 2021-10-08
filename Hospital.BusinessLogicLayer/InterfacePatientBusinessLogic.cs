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
using HMS.Entities;
using HMS.Exceptions;

namespace HMS.BusinessLogicLayer
{

    /// <summary>
    /// Interface for business logic layer.
    /// </summary>
    public interface IPatientBusinessLogic
    {
        /// <summary>
        /// Represents a method to validate Patient Info.
        /// </summary>
        /// <param name="patient"> Patient Class Object whose entities will be validated. </param>
        /// <returns> Wether a data is valid or not! </returns>
        bool ValidatePatient(Patient patient);

        /// <summary>
        /// Represents a method to add data as this method will further call data access layer add method.
        /// </summary>
        /// <param name="newPatient"> Object that is going to be added in the list and file of Patient. </param>
        /// <returns> Wether the data is added or not. </returns>
        bool AddPatientBL(Patient newPatient);

        /// <summary>
        /// Represents a methodthat will return list of all patients.
        /// </summary>
        /// <returns> Returns list of all patients. </returns>
        List<Patient> GetAllPatientBL();

        /// <summary>
        /// Represent a method to search a patient by it's ID.
        /// </summary>
        /// <param name="searchPatientID"> ID of patient to be Searched. </param>
        /// <returns> Boolean value that wether the patient data is present or not. </returns>
        Patient SearchPatientByIdBL(byte searchPatientID);

        /// <summary>
        /// Represents a method to update existing patient Value.
        /// </summary>
        /// <param name="updatePatient"> Patient object to check if there's any data present or not. </param>
        /// <returns> Whether the data of a patient is updated or not. </returns>
        bool UpdatePatientBL(Patient updatePatient);

        /// <summary>
        /// Represents a method to delete existing patient record.
        /// </summary>
        /// <param name="deletePatientID"> Patient ID whose record should be deleted. </param>
        /// <returns> Boolean value that wether the data is deleted or not. </returns>
        bool DeletePatientByIdBL(byte deletePatientID);
    }
}
