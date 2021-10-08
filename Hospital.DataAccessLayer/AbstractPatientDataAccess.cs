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


namespace HMS.DataAccessLayer
{
    /// <summary>
    /// Absract class for Data Access layer .
    /// </summary>
    public abstract class PatientDataAccessBase
    {
        /// <summary>
        /// Represents method to delete details of a patient using ID.
        /// </summary>
        /// <param name="deletePatientID"> Patient ID whose whole data is to be deleted. </param>
        /// <returns> Boolean if wether the object from the list is deleted or not. </returns>
        public abstract bool DeletePatientDAL(byte deletePatientID);

        /// <summary>
        /// Represents method to update selected details of a patient.
        /// </summary>
        /// <param name="updatePatient"> Paramter that will be used to update list element. </param>
        /// <returns> Wether the object entities are successfully updated or not. </returns>
        public abstract bool UpdatePatientDAL(Patient updatePatient);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchPatientID"> SearchPatientID is used to search a patient by it's ID. </param>
        /// <returns> Patient object if Patient is found or not. </returns>
        public abstract Patient GetPatientByPatientID(byte searchPatientID);

        /// <summary>
        ///  Represents method to add a patient data.
        /// </summary>
        /// <param name="newPatient"> Paramter that will add a new Patient Object in list. </param>
        /// <returns> Boolean value if patient is added successfully. </returns>
        public abstract bool AddPatientDAL(Patient newPatient);

        /// <summary>
        /// Represents method to get all details of a patient.
        /// </summary>
        /// <returns> Patient Data List. </returns>
        public abstract List<Patient> GetAllPatientsDAL();

        /// <summary>
        /// Represents method that is to be serialised.
        /// </summary>
        /// <param name="patientData"> Patient data list which will be serialised inside the file. </param>
        public abstract void SerialisePatientData(List<Patient> patientData);

    }
}
