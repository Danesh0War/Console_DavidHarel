using FinalPoj1.Models;

namespace FinalPoj1.Servises
{
    public class TrainingProgram
    {
        private static string[] Categorize(Client client) // Categorize client's bmi (don't tell him - used to fit the program)
        {
            int age = CalculateAge(client.DateOfBirth);
            double bmi = client.BMI;
            string[] category = new string[2];

            // Data taken from www.gov.il/en/service/body-mass-index-calculator

            if (age > 18 && age < 65)
            {
                category[0] = "18-65";
                if (bmi < 18.5)
                    category[1] = "Underweight";
                else if (bmi >= 18.5 && bmi < 24.9)
                    category[1] = "Healthy weight";
                else if (bmi >= 25 && bmi < 29.9)
                    category[1] = "Overweight";
                else if (bmi >= 30)
                    category[1] = "Obese";
            }
            else if (age > 65 && age < 74)
            {
                category[0] = "65-74";
                if (bmi < 22)
                    category[1] = "Underweight";
                else if (bmi >= 22 && bmi < 26.9)
                    category[1] = "Healthy weight";
                else if (bmi >= 27 && bmi < 29.9)
                    category[1] = "Overweight";
                else if (bmi >= 30)
                    category[1] = "Obese";
            }
            else if (age > 74)
            {
                category[0] = "74+";
                if (bmi < 23)
                    category[1] = "Underweight";
                else if (bmi >= 23.1 && bmi < 27.9)
                    category[1] = "Healthy weight";
                else if (bmi >= 28 && bmi < 29.9)
                    category[1] = "Overweight";
                else if (bmi >= 30)
                    category[1] = "Obese";
            }

            return category;
        }


        public static string SetTrainingProgram(Client client) // based on previous Categorize data
        {
            string[] category = Categorize(client);

            string ageCategory = category[0];
            string bmiCategory = category[1];

            string trainingProgram;

            byte ageIndex = 0;
            byte bmiIndex = 0;
            string generalSuggestion = "";


            if (ageCategory == "18-65")
            {
                ageIndex = 1;
            }

            else if (ageCategory == "65-74")
            {
                ageIndex = 2;

            }
            else if (ageCategory == "74+")
            {
                ageIndex = 3;
            }



            if (bmiCategory == "Underweight")
            {
                bmiIndex = 1;
                generalSuggestion = "To improve your weight, focus on strength training and consume a balanced diet with a slight calorie surplus.";

            }

            else if (bmiCategory == "Healthy weight")
            {
                bmiIndex = 2;
                generalSuggestion = "Maintain your current weight by incorporating a combination of cardiovascular exercises and strength training.";
            }

            else if (bmiCategory == "Overweight")
            {
                bmiIndex = 3;
                generalSuggestion = "To reduce your weight, focus on regular cardiovascular exercises, such as running or cycling, and follow a calorie-controlled diet.";
            }

            else if (bmiCategory == "Obese")
            {
                bmiIndex = 4;
                generalSuggestion = "For intence weight loss, engage in regular physical activity, including both cardiovascular exercises and strength training.";
            }


            trainingProgram = $"Based on your parametres we fitted you training program number {ageIndex}.{bmiIndex}. Approach the coach for further explanation. {generalSuggestion}.";
            Console.WriteLine(trainingProgram);
            return trainingProgram;
        }


        private static int CalculateAge(string dateOfBirth) //Age used in BMI categorizing
        {
            DateTime birthDate = DateTime.Parse(dateOfBirth);
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;
            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }

    }
}
