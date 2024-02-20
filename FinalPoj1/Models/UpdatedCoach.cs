using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPoj1.Models
{
    internal class UpdatedCoach : Coach // Purpose of this class is to copy the already validated Coach data fields (it's purpose) in order to modify it with Edit methods. 
    {
        // Constructor (placeholders for loaded data)
        public UpdatedCoach(string personalId = "", string firstName = "", string lastName = "", string gender = "", string dateOfBirth = "", string phone = "", string email = "", string[] bankDetails = null, List<string> specialization = null)
            : base(personalId, firstName, lastName, gender, dateOfBirth, phone, email, bankDetails, specialization)
        {
        }
    }
}
