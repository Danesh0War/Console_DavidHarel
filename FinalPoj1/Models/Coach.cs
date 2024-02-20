using FinalPoj1.Servises;

namespace FinalPoj1.Models
{
    internal class Coach : Person
    {
        // Unique properties
        public string[] BankDetails { get; set; }
        public List<string> Specialization { get; set; }
        public string Status { get; set; }

        protected override void SetProperties() // ovveriding person's func in order to inherit common validated properties and add unique

        {
            base.SetProperties();

            BankDetails = Setters.setBankDetails();
            Specialization = Setters.setSpecializ();
            Status = "Active";
        }

        // Constructor - for every registration (instance creation) validatate that if user started filling - every fields will be filled (appropriately with a help of SetProperties())
        public Coach(string personalId, string firstName, string lastName, string gender, string dateOfBirth, string phone, string email, string[] bankDetails, List<string> specialization)
        : base(personalId, firstName, lastName, gender, dateOfBirth, phone, email)
        {
            BankDetails = bankDetails;
            Specialization = specialization;
        }


        public Coach() // automathically force to fill all of the required fields for every registration (instance creation) - usefull in our case. 
        {
            SetProperties();
        }

       

    }



}
