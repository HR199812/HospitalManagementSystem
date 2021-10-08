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
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HMS.DataAccessLayer
{


    /// <summary>
    /// Represents patient data access class.
    /// </summary>
    [Serializable]
    public class PatientDataAccess : PatientDataAccessBase
    {

        /// <summary>
        /// Creating a list to store data of patient's.
        /// </summary>
        public static List<Patient> patientData = new List<Patient>();


        /// <summary>
        /// Using a static constructor to open the deserialise method at the beginning of application.
        /// </summary>
        static PatientDataAccess()
        {
            //File to be opened to read data of the user from it.
            FileStream fileStream = new FileStream(Environment.CurrentDirectory + @"\PD.txt", FileMode.Open);
            
            //Binary Formatter to deserialise patient data from file.
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            patientData = (List<Patient>)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
        }

        /// <summary>
        ///  Represents method to add a patient data.
        /// </summary>
        /// <param name="newPatient"> Paramter that will add a new Patient Object in list. </param>
        /// <returns> Boolean value if patient is added successfully. </returns>
        public override bool AddPatientDAL(Patient newPatient)
        {
            // boolean value to return wether the is data  null or not.
            bool patientAdded = false;

            try
            {
                patientData.Add(newPatient);
                SerialisePatientData(patientData);
                patientAdded = true;
            }
            catch (Exception ex)
            {
                throw new PatientException(ex.Message);
            }
            return patientAdded;

        }


        /// <summary>
        /// Represents method to get all details of a patient.
        /// </summary>
        /// <returns> Patient Data List. </returns>
        public override List<Patient> GetAllPatientsDAL()
        {
            return patientData;
        }

        /// <summary>
        /// Represets method to search a patient by it's doctor ID.
        /// </summary>
        /// <param name="searchPatientID"> SearchPatientID is used to search a patient by it's ID. </param>
        /// <returns> Patient object if Patient is found or not. </returns>
        public override Patient GetPatientByPatientID(byte searchPatientID)
        {
            // boolean value to return wether the is data  null or not.
            Patient searchPatient = null;

            try
            {
                searchPatient = patientData.Find(patient => patient.PatientId == searchPatientID);
            }
            catch (Exception ex)
            {
                throw new PatientException(ex.Message);
            }
            return searchPatient;
        }


        /// <summary>
        /// Represents method to update selected details of a patient.
        /// </summary>
        /// <param name="updatePatient"> Paramter that will be used to update list element. </param>
        /// <returns> Wether the object entities are successfully updated or not. </returns>
        public override bool UpdatePatientDAL(Patient updatePatient)
        {

            // boolean value to return wether the is data  null or not.
            bool patientUpdated = false;

            try
            {
                for (int i = 0; i < patientData.Count; i++)
                {
                    if (patientData[i].PatientId == updatePatient.PatientId)
                    {
                        patientData[i].PatientName = updatePatient.PatientName;
                        patientData[i].PatientPhoneNumber = updatePatient.PatientPhoneNumber;
                        patientUpdated = true;
                    }
                }
                SerialisePatientData(patientData);
            }
            catch (Exception ex)
            {
                throw new PatientException(ex.Message);
            }
            return patientUpdated;

        }

        /// <summary>
        /// Represents method to delete details of a patient using ID.
        /// </summary>
        /// <param name="deletePatientID"> Patient ID whose whole data is to be deleted. </param>
        /// <returns> Boolean if wether the object from the list is deleted or not. </returns>
        public override bool DeletePatientDAL(byte deletePatientID)
        {

            // boolean value to return wether the is data  null or not.
            bool patientDeleted = false;

            try
            {
                Patient deletePatient = patientData.Find(patient => patient.PatientId == deletePatientID);

                if (deletePatient != null)
                {
                    patientData.Remove(deletePatient);
                    patientDeleted = true;
                }
                SerialisePatientData(patientData);

            }
            catch (Exception ex)
            {
                throw new PatientException(ex.Message);
            }
            return patientDeleted;

        }

        /// <summary>
        /// Represents method that is to be serialised.
        /// </summary>
        /// <param name="patientData"> Patient data list which will be serialised inside the file. </param>
        public override void SerialisePatientData(List<Patient> patientData)
        {
            try
            {
                //File to be Created to write data of the user in it.
                FileStream fileStream = new FileStream(Environment.CurrentDirectory + @"\PD.txt", FileMode.Create, FileAccess.Write);

                //Binary Formatter to Serialise patient data into a file.
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, patientData);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                throw new PatientException(ex.Message);
            }
        }
    }
}

