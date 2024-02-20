using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalPoj1.Servises;
using Newtonsoft.Json;

namespace FinalPoj1.Models
{
    internal class ExistingCoaches : Coach // In contrast to Coach (model) which mainly controls instance creation, purpose of this class is to to act as pattern for every instance loading into the program
    {
        // Constructor (placeholders for loaded data)
        public ExistingCoaches(string personalId = "", string firstName = "", string lastName = "", string gender = "", string dateOfBirth = "", string phone = "", string email = "", string[] bankDetails = null, List<string> specialization = null)
          : base(personalId, firstName, lastName, gender, dateOfBirth, phone, email, bankDetails, specialization)
        {
  
        }


        public static List<ExistingCoaches> LoadAllCoaches() // return list of object type of ExistingCoaches. 
        {
            List<ExistingCoaches> coaches = new List<ExistingCoaches>(); // create list to papulate
            string[] coachesDirectories = Directory.GetDirectories(FileManager.mainFolderPath + "\\Coach"); // get all subdirectories under Coach folder (for ex C:\Users\User\GymProject\Data\Coach\454545454).

            foreach (string coachDirectory in coachesDirectories)
            {
                string personalInfoPath = Path.Combine(coachDirectory, "PersonalInfo.json"); // full path to json with saved data fields

                if (File.Exists(personalInfoPath))
                {
                    ExistingCoaches coach = new ExistingCoaches();
                    string personalInfoContent = File.ReadAllText(personalInfoPath); // Read JSON
                    JsonConvert.PopulateObject(personalInfoContent, coach); // PopulateObject is a specific method for our need - fill in all objects fields
                    coaches.Add(coach); // add saved object to list
                }
            }

            return coaches;
        }


        public override string ToString() // Formatting to be able to represent data insted of class name 
        {
            string bankDetailsString = string.Join(",", BankDetails); // way to print array (convert to string and split every member with ",")
            string specializationsString = string.Join(",", Specialization); // same way to print list
            return $"ID: {PersonalId}\nFirst Name: {FirstName}\nLastName: {LastName}\nGender: {Gender}\nDate Of Birth: {DateOfBirth}\nPhone number: {Phone}\nEmail: {Email}\nBankDetails: {bankDetailsString}\nSpecializations: {specializationsString}\n";
        }


    }
}
