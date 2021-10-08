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

namespace HMS.Exceptions
{

    /// <summary>
    /// Represents custom Exception Class for patient data 
    /// </summary>
    public class PatientException:ApplicationException
    {

        /// <summary>
        /// Non-Paramterised exception
        /// </summary>
        public PatientException()
          : base()
        {
        }

        /// <summary>
        /// Single Paramterised exception
        /// </summary>
        /// <param name="message"> String Parameter that'll take the string thrwon from the try block. </param>
        public PatientException(string message)
            : base(message)
        {
        }


        /// <summary>
        /// Double Paramterised exception
        /// </summary>
        /// <param name="message">  String Parameter that'll take the string thrwon from the try block. </param>
        /// <param name="innerException"> Inner Execption if thrown any from any throws clause. </param>
        public PatientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
