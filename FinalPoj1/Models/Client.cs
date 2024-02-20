using FinalPoj1.Servises;
using FinalPoj1.Servises;
using Newtonsoft.Json;

namespace FinalPoj1.Models
{
    public class Client : Person 
    {
        // Unique properties
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI { get; set; }
        public string Status { get; set; }


        protected override void SetProperties() // ovveriding person's func in order to inherit common validated properties and add unique
        {
            base.SetProperties();

            Weight = Setters.SetNumericProperty("Weight in kg", 2, 0, 3, 3, 50, 220);
            Height = Setters.SetNumericProperty("Height in m", 1, 0, 1, 3, 1.5, 3);
            BMI = Weight / (Math.Pow(Height, 2));
            Status = "Active";
        }

        // Constructor - for every registration (instance creation) validatate that if user started filling - every fields will be filled (appropriately with a help of SetProperties())
        public Client(string personalId, string firstName, string lastName, string gender, string dateOfBirth, string phone, string email, double weight, double height)
            : base(personalId, firstName, lastName, gender, dateOfBirth, phone, email)
        {
            Weight = weight;
            Height = height;
        }
       
        public Client() // automathically force to fill all of the required fields for every registration (instance creation) - usefull in our case. 
        {
            SetProperties();
        }

    }
}
