using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPoj1.Models
{
    public class UpdatedClient : Client // Purpose of this class is to copy the already validated Client data fields (it's purpose) in order to modify it with Edit methods. 
    {
        // Constructor (placeholders for loaded data)
        public UpdatedClient(string personalId = "", string firstName = "", string lastName = "", string gender = "", string dateOfBirth = "", string phone = "", string email = "", double weight = 0, double height = 0)
            : base(personalId, firstName, lastName, gender, dateOfBirth, phone, email, weight, height)
        {
        }
    }

}
