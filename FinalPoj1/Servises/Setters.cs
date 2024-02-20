using System.Data.Common;
using System.Text.RegularExpressions;



namespace FinalPoj1.Servises
{
    public class Setters // Validation class. Used widely for every input validation / limitation. 
    {

        public static string SetTextualProperty(string propertyName, byte length = 0) // Except only latin letters with optional length limitation
        {
            string textualValue = "";
            bool isInputOk = false;
            string validationPattern;

            if (length > 0)
                validationPattern = @$"^[a-zA-Z]{length}$";
            else
                validationPattern = @"^[a-zA-Z]+$";

            Regex validation = new Regex(validationPattern);

            do
            {
                Console.Write($"Please Enter {propertyName}: "); // modularity
                string inputValue = Console.ReadLine();

                if (string.IsNullOrEmpty(inputValue))
                {
                    isInputOk = true;
                    break;
                }


                if (validation.IsMatch(inputValue))
                {
                    textualValue = inputValue;
                    isInputOk = true;
                }
                else
                {
                    Console.WriteLine($"Invalid Format.Your input is limited to {length} characters.Reinput");
                }
            }
            while (!isInputOk);

            return textualValue;
       
        }


        public static double SetNumericProperty(string propertyName, byte minWholeDigits = 0, byte minDecimalDigits = 0, byte maxWholeDigits = 0, byte maxDecimalDigits = 0, double minValue = double.MinValue, double maxValue = double.MaxValue) // Except only numbers letters with full control for number of whole and decimal digits + value size
        {
            double numericValue = 0;
            bool isInputOk = false;
            string validationPattern;

            if (maxWholeDigits > 0 && maxDecimalDigits > 0)
            {
                validationPattern = $@"^(?=.*[1-9])\d{{{minWholeDigits},{maxWholeDigits}}}(\.\d{{{minDecimalDigits},{maxDecimalDigits}}})?$";
            }
            else if (maxWholeDigits > 0)
            {
                validationPattern = $@"^(?=.*[1-9])\d{{{minWholeDigits},{maxWholeDigits}}}$";
            }
            else if (maxDecimalDigits > 0)
            {
                validationPattern = $@"^(?=.*[1-9])\.\d{{{minDecimalDigits},{maxDecimalDigits}}}$";
            }
            else
            {
                validationPattern = @"^\d+$";
            }

            Regex validation = new Regex(validationPattern);

            do
            {
                Console.Write($"Plese Enter {propertyName}: ");
                string inputValue = Console.ReadLine();

                if (validation.IsMatch(inputValue) && double.TryParse(inputValue, out numericValue) && numericValue >= minValue && numericValue <= maxValue)
                {
                    isInputOk = true;
                }
                else
                {
                    Console.WriteLine($"Invalid format or value. Your input is limited to {minWholeDigits}-{maxWholeDigits} whole digits and {minDecimalDigits}-{maxDecimalDigits} decimal digits, with a value between {minValue} and {maxValue}. Please re-enter.");
                }
            } while (!isInputOk);

            return numericValue;
        }

       
        public static string setGender() // Except Male or Female or skip
        {
            string gender = "";
            bool isInputOK = false;
            Regex validation = new Regex(@"^(Male|Female)$");

            do
            {
                Console.Write("Add new gender (Male / Female). If you want to skip press Enter: ");
                string inpGender = Console.ReadLine();
                if (validation.IsMatch(inpGender) || string.IsNullOrEmpty(inpGender))
                {
                    gender = inpGender;
                    isInputOK = true;
                }
                else
                {
                    Console.WriteLine("Invalid Format. Reinput");
                }
            }
            while (!isInputOK);

            return gender;
        }


        public static string setDateofBirth() // Except a date string in the format "MM/DD/YYYY".
        {
            string DateofBirth = "";
            bool isInputOK = false;
            Regex validation = new Regex(@"^(0[1-9]|1[0-2])/(0[1-9]|1\d|2\d|3[01])/((19|20)\d{2})$"); // month ranges from 01 to 12, the day ranges from 01 to 31 depending on the month, and the year ranges from 1900 to 2099.
            do
            {
                Console.Write("Add new Date of Birth: ");
                string inpDateofBirth = Console.ReadLine();
                if (validation.IsMatch(inpDateofBirth))
                {
                    DateofBirth = inpDateofBirth; // defining the prop
                    isInputOK = true;
                }
                else
                { Console.WriteLine("Invalid Format: MM//DD/YY. Reinput"); }
            }
            while (!isInputOK);
            return DateofBirth;
        }

        public static string setPhone() // Except only Israli phone number
        {
            string phone = "";
            bool isInputOK = false;
            Regex validation = new Regex(@"^(?:\+972-?|0)(?:58|54|53|52|50)\d{7}$"); //Automatically +972  + Existing prefexis + rest of the number 7 digits. (+972585345169)
            do
            {
                Console.Write("Add new Phone Number: ");
                string inpPhone = Console.ReadLine();
                if (validation.IsMatch(inpPhone))
                {
                    phone = inpPhone; // defining the prop
                    isInputOK = true;
                }
                else
                { Console.WriteLine("Invalid Format. Reinput"); }
            }
            while (!isInputOK);
            return phone;
        }

        public static string setEmail() // Except only mails
        {
            string email = "";
            bool isInputOK = false;
            Regex validation = new Regex(@"^[A-Za-z0-9._]+@[A-Za-z0-9._]+\.[A-Za-z]{2,}$"); //XXXX@XXXX.XXX or XXXX@XXXX.XXX.XXX
            do
            {
                Console.Write("Add new Email: ");
                string inpEmail = Console.ReadLine();
                if (validation.IsMatch(inpEmail))
                {
                    email = inpEmail; // defining the prop
                    isInputOK = true;

                }
                else
                { Console.WriteLine("Invalid Format. Reinput"); }
            }
            while (!isInputOK);
            return email;
        }


      

        //*****************************************************************Validators for uniqe coach props

        public static string[] setBankDetails()
        {
            string[] BankDetails = new string[3]; // NAME, BRANCH NUMBER, ACC NUMBER

            BankDetails[0] = SetTextualProperty("Bank Name");
            BankDetails[1] = SetNumericProperty("Branch number", 1, 0, 3, 0).ToString();
            BankDetails[2] = SetNumericProperty("Account Number", 8, 0, 8, 0).ToString();         
            return BankDetails;
        }
    
        public static List<string> setSpecializ()
        {
            List<string> specializations = new List<string>();
            string specialization;
            bool IsAdding = true;

            do
            {
                specialization = SetTextualProperty("Specialization.(Left unfilled to stop the process)");

                if(!string.IsNullOrEmpty(specialization))
                {
                    specializations.Add(specialization);
                }

                else IsAdding = false;
            }

            while (IsAdding);
            return specializations;
        }
    }


}





