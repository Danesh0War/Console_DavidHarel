using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FinalPoj1.Servises;
using Newtonsoft.Json;

namespace FinalPoj1.Models
{
    public class ExistingClients : Client // In contrast to Client (model) which mainly controls instance creation, purpose of this class is to to act as pattern for every instance loading into the program
    {
        // declaring privete fields that are not presented in original Client class (according to requirements). Will be used to hold Subscription and TrainingProgram JSON's (which client can't do)
        private string _subscription { get; set; }
        private string _trainingProgram { get; set; }

        // Constructor (placeholders for loaded data)
        public ExistingClients(string personalId = "", string firstName = "", string lastName = "", string gender = "", string dateOfBirth = "", string phone = "", string email = "", double weight = 0, double height = 0)
            : base(personalId, firstName, lastName, gender, dateOfBirth, phone, email, weight, height)
        {
            _subscription = "";
            _trainingProgram = "";
        }

        public static List<ExistingClients> LoadAllClients() // return list of object type of ExistingClients. 
        {
            List<ExistingClients> clients = new List<ExistingClients>(); // create a list
            string[] clientDirectories = Directory.GetDirectories(FileManager.mainFolderPath + "\\Client"); // get all subdirectories under Coach folder (for ex C:\Users\User\GymProject\Data\Coach\454545454).

            foreach (string clientDirectory in clientDirectories) 
            {
                string personalInfoPath = Path.Combine(clientDirectory, "PersonalInfo.json"); // define a path to PersonalInfo.json
                string subscriptionPath = Path.Combine(clientDirectory, "Subscription.json"); // define a path to Subscription.json
                string trainingProgramPath = Path.Combine(clientDirectory, "TrainingProgram.json"); // define a path to TrainingProgram.json

                if (File.Exists(personalInfoPath)) // General check whether PersonalInfo exists. If it's not - we should not check for other json's because PersonalInfo is the main JSON which creates for every new instance and by "delete" function in the prog we delete all the JSONS.
                {
                    ExistingClients client = new ExistingClients(); // create instrance to assign readed data into it.
                    string personalInfoContent = File.ReadAllText(personalInfoPath);
                    JsonConvert.PopulateObject(personalInfoContent, client); // special function to fill in all the data fields of an object

                    if (File.Exists(subscriptionPath))
                    {
                        string subscriptionContent = File.ReadAllText(subscriptionPath); 
                        client._subscription = subscriptionContent; // Subscriptions contains only string so we can assign it directly
                    }
                    else client._subscription = "Subscription file not found"; //  Explain to user why this fields left unfilled

                    if (File.Exists(trainingProgramPath))
                    {
                        string trainingProgramContent = File.ReadAllText(trainingProgramPath);
                        client._trainingProgram = trainingProgramContent; // TrainingProgram contains only string so we can assign it directly
                    }
                    else client._trainingProgram = "Training program file not found"; //  Explain to user why this fields left unfilled

                    clients.Add(client);

                }
            }

            return clients;
        }


        public override string ToString() // String formatting to print the desired data instead of the class's name
        {
            return $"ID: {PersonalId}\nFirst Name: {FirstName}\nLastName: {LastName}\nGender: {Gender}\nDate Of Birth: {DateOfBirth}\nPhone number: {Phone}\nEmail: {Email}\nWeight: {Weight}\nHeight: {Height}\nBMI: {BMI}\nSubscrtiption: {_subscription} \nTraining Program: {_trainingProgram}";
        }


    }
}
