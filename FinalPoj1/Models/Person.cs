using FinalPoj1.Servises;

namespace FinalPoj1.Models
{
    public abstract class Person
    {
        // Common properties
        public string PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }



        // Setters (data field validation per every instance creation)
        // Setters in the Coach class will be common for every deriving class - this this func will be adjusted to the needs of every deriving class
        protected virtual void SetProperties()
        {
            PersonalId = Setters.SetNumericProperty("Personal Id", 9, 0, 9, 0).ToString();
            FirstName = Setters.SetTextualProperty("First Name");
            LastName = Setters.SetTextualProperty("Last Name");
            Gender = Setters.setGender();
            DateOfBirth = Setters.setDateofBirth();
            Phone = Setters.setPhone();
            Email = Setters.setEmail();
        }

        // Constructor - for every registration (instance creation) validatate that if user started filling - every fields will be filled (appropriately with a help of SetProperties())
        public Person(string personalId, string firstName, string lastName, string gender, string dateOfBirth, string phone, string email)
        {
            PersonalId = personalId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
        }
        protected Person()
        {
        }
     
    }
}
