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

namespace HMS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Patient
    {

        /// <summary>
        /// Represents Patient's ID
        /// </summary>
        public byte PatientId { get; set; }

        /// <summary>
        /// Represents Patient's Name
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// Represents Patient's Gender
        /// </summary>
        public char PatientGender { get; set; }

        /// <summary>
        /// Represents Patient's Address
        /// </summary>
        public string PatientAddress { get; set; }

        /// <summary>
        /// Represents Patient's Disease
        /// </summary>
        public string PatientDisease { get; set; }

        /// <summary>
        /// Represents Patient's Doctor's ID
        /// </summary>
        public byte PatientDoctorId { get; set; }

        /// <summary>
        /// Represents Patient's Age
        /// </summary>
        public byte PatientAge { get; set; }

        /// <summary>
        /// Represents Patient's Weight
        /// </summary>
        public byte PatientWeight { get; set; }

        /// <summary>
        /// Represents Patient's Phone Number
        /// </summary>
        public long PatientPhoneNumber { get; set; }
    }
}
