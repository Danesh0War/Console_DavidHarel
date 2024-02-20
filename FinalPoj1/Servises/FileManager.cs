using FinalPoj1.Models;
using Newtonsoft.Json;


namespace FinalPoj1.Servises
{
    public class FileManager // Main Servise responsible for file management. 
    {
            // Basic blocks usefull in class
        static public string mainFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GymProject\\Data"; // default user's folder so the program will work on different PC's and different OS's.(For ex C:\Users\User\GymProject\Data)

        static public string GetPath(Person newPerson) // returns a path to every created coach / client based on the func input). Would be used in file creation.
        {
            return mainFolderPath + @$"\{newPerson.GetType().Name}\{newPerson.PersonalId}";
        }
  
        public enum EntityType // Limit's user input to function bases on 2 current targeted models - allows propper function implementation and also cration of Gereral function which will work for every project possible model (for ex editPerson isntead of Edit coach / Edit Client)
        {
            Client,
            Coach
        }

        public static string IDCheck(EntityType personType) // Check whether client /coach already saved previously
        {
            {
                //Console.WriteLine("Please enter personal ID: ");
                string ID = Setters.SetNumericProperty("Personal Id", 9, 0).ToString();
                string entityFolder = personType == EntityType.Client ? "Client" : "Coach";
                string folderPath = Path.Combine(FileManager.mainFolderPath, entityFolder, @$"{ID}");

                while (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("This person doesn't exist, Please reinput");
                    ID = Setters.SetNumericProperty("Personal Id", 9, 0, 9, 0).ToString();
                }

                return ID;

            }

        }

            // Creation block

        static public void SerializeAndSavePersonalData(Person newPerson) // saves data fields of Client/Coach into PersonalInfo.json
        {
            //if (newPerson is Client )

            string fileName = "PersonalInfo.json";
            string personFolderPath = GetPath(newPerson);
            string filePath = Path.Combine(personFolderPath, fileName);
            string serializedPerson = JsonConvert.SerializeObject(newPerson);
            try
            {
                Directory.CreateDirectory(personFolderPath);
                File.WriteAllText(filePath, serializedPerson);
                Console.WriteLine("\nA new person has been successfully added to the existing folder.\n");
                //Console.ReadKey();
                //Program.MaintInterf(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the directory or writing to the file: {ex.Message}");
            }
            
        }

        public static void SerializeAndSaveSubscription(Client client) // Saves subscription of Client into Subscription.json
        {
            string subscription = Subscription.SetSubscription();
            string subscriptionFilePath = Path.Combine(GetPath(client), "Subscription.json");
            string serializedSubscription = JsonConvert.SerializeObject(subscription);
            try
            {
                File.WriteAllText(subscriptionFilePath, serializedSubscription);
                Console.WriteLine("Subscription data has been serialized and saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the subscription data: {ex.Message}");
            }
        }

        public static void SerializeAndSaveTrainingProgram(Client client) // Saves TrainingProgram of Client into Subscription.json
        {
            string trainingProgram = TrainingProgram.SetTrainingProgram(client);
            string trainingProgramFilePath = Path.Combine(GetPath(client), "TrainingProgram.json");
            string serializedTrainingProgram = JsonConvert.SerializeObject(trainingProgram);
            try
            {
                File.WriteAllText(trainingProgramFilePath, serializedTrainingProgram);
                Console.WriteLine("Training program data has been serialized and saved successfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the training program data: {ex.Message}");
            }
        }

        public static void SerializeAndSaveClientData(Client client) // Unite 3 functions that are used per every new client creation
        {
            SerializeAndSavePersonalData(client);
            SerializeAndSaveTrainingProgram(client);
            SerializeAndSaveSubscription(client);
        }

        // Edition block
       
        static public void EditPerson(EntityType personType) // One general function that will work for every decalred model (currently 2). 
        {
            string id = IDCheck(personType);

            string entityFolder = personType == EntityType.Client ? "Client" : "Coach"; // Entity folder based on personType
            string folderPath = Path.Combine(FileManager.mainFolderPath, entityFolder, @$"{id}");
            string filePath = Path.Combine(folderPath, "PersonalInfo.json");

            string jsonContent = File.ReadAllText(filePath); // Read JSON

            // Function NODE 
            if (personType == EntityType.Client)
            {
                var deserializedClient = JsonConvert.DeserializeObject<UpdatedClient>(jsonContent); // load data into UpdatedClient class
                //defining optionality for field modification
                Console.WriteLine("Please choose which field to edit:\n");
                Console.WriteLine("1.First Name \n2.Laste Name \n3.Gender \n4.Date Of Birth \n5.Phone Number \n6.Email \n7.Weight \n8.Height \n9.Back\n");

                double choise1;
                bool isEditing1 = true;

                while (isEditing1)
                {
                    choise1 = Setters.SetNumericProperty("Your choise", 1, 0, 1, 0, 1, 9); // allow only 1-9 input
                    switch (choise1)
                    {
                        // Resetting data into data fields incliding validation
                        case 1:
                            deserializedClient.FirstName = Setters.SetTextualProperty("First Name");
                            break;

                        case 2:
                            deserializedClient.LastName = Setters.SetTextualProperty("Last Name");
                            break;

                        case 3:
                            deserializedClient.Gender = Setters.setGender();
                            break;

                        case 4:
                            deserializedClient.DateOfBirth = Setters.setDateofBirth();
                            break;

                        case 5:
                            deserializedClient.Phone = Setters.setPhone();
                            break;

                        case 6:
                            deserializedClient.Email = Setters.setEmail();
                            break;

                        case 7:
                            deserializedClient.Weight = Setters.SetNumericProperty("Weight in kg", 2, 0, 3, 3, 50, 220);
                            break;

                        case 8:
                            deserializedClient.Height = Setters.SetNumericProperty("Height in m", 1, 0, 1, 3, 1.5, 3);
                            break;

                        case 9:
                            isEditing1 = false;
                            break;
                    }
                }

                string updatedClient = JsonConvert.SerializeObject(deserializedClient); // again convert to json
                File.WriteAllText(filePath, updatedClient); // save json
                Console.WriteLine("\nA client has been successfully modified.\n");

            }

            else if (personType == EntityType.Coach)
            {
                var deserializedCoach = JsonConvert.DeserializeObject<UpdatedCoach>(jsonContent); // load data into UpdatedCoach class
                // defining optionality for field modification
                Console.WriteLine("Please choose which field to edit: ");
                Console.WriteLine("1.First Name \n2.Laste Name \n3.Gender \n4.Date Of Birth \n5.Phone Number \n6.Email \n7.Bank Details \n8.Specialisations \n9.Back");

                double choise;
                bool isEditing = true;

                while (isEditing)
                {
                    choise = Setters.SetNumericProperty("Your choise", 1, 0, 1, 0, 1, 9); // limit input to 1-9. 
                    switch (choise)
                    {
                        // data fields refilling including validation
                        case 1:
                            deserializedCoach.FirstName = Setters.SetTextualProperty("First Name");
                            break;

                        case 2:
                            deserializedCoach.LastName = Setters.SetTextualProperty("Last Name");
                            break;

                        case 3:
                            deserializedCoach.Gender = Setters.setGender();
                            break;

                        case 4:
                            deserializedCoach.DateOfBirth = Setters.setDateofBirth();
                            break;

                        case 5:
                            deserializedCoach.Phone = Setters.setPhone();
                            break;

                        case 6:
                            deserializedCoach.Email = Setters.setEmail();
                            break;

                        case 7:
                            deserializedCoach.BankDetails = Setters.setBankDetails();
                            break;

                        case 8:
                            deserializedCoach.Specialization = Setters.setSpecializ();
                            break;

                        case 9:
                            isEditing = false;
                            break;
                    }
                }

                string updatedCoach = JsonConvert.SerializeObject(deserializedCoach);
                File.WriteAllText(filePath, updatedCoach);
                Console.WriteLine("\nA coach has been successfully modified.\n");
            }

        }


            // Deletion block
        static public void DeletePerson(EntityType personType) // sets defaut field Status: "Active" to "Passive". 
        {
            string id = IDCheck(personType);
            string entityFolder = personType == EntityType.Client ? "Client" : "Coach";
            string folderPath = Path.Combine(FileManager.mainFolderPath, entityFolder, @$"{id}");
            string filePath = Path.Combine(folderPath, "PersonalInfo.json");

            string jsonContent = File.ReadAllText(filePath);
            if (personType == EntityType.Client)
            {
                var deserializedClient = JsonConvert.DeserializeObject<UpdatedClient>(jsonContent);
                deserializedClient.Status = "Passive";
                string updatedClient = JsonConvert.SerializeObject(deserializedClient);
                File.WriteAllText(filePath, updatedClient);
                Console.WriteLine("\nA client has been successfully deleted.\n");

            }
            else if (personType == EntityType.Coach)
            {
                var deserializedCoach = JsonConvert.DeserializeObject<UpdatedCoach>(jsonContent);
                deserializedCoach.Status = "Passive";
                string updatedCoach = JsonConvert.SerializeObject(deserializedCoach);
                File.WriteAllText(filePath, updatedCoach);
                Console.WriteLine("\nA coach has been successfully deleted.\n");
            }
           
        }


        static public void ReallyDeletePerson(EntityType personType) // Directly deletes Client / Coach folder within all jsons. 
        {
            string id = IDCheck(personType);
            string entityFolder = personType == EntityType.Client ? "Client" : "Coach";
            string folderPath = Path.Combine(FileManager.mainFolderPath, entityFolder, @$"{id}");
            //string filePath = Path.Combine(folderPath, "PersonalInfo.json");

            while (!Directory.Exists(Path.Combine(FileManager.mainFolderPath, entityFolder, @$"{id}")))
            {
                Console.WriteLine("This client doesn't exist, Please reinput");
                id = Setters.SetNumericProperty("Personal Id", 9, 0, 9, 0).ToString().ToString();
            }

            try
            {
                Directory.Delete(folderPath, true);
                Console.WriteLine($"A {personType} has been successfully deleted.\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while deleting the folder: " + ex.Message);
            }
        }
   
    }
}
