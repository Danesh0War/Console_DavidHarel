namespace FinalPoj1.Servises
{
    public class Subscription // Manage Subscription data
    {
        public static string SetSubscription() // returns chosen subscribtion in string
        {
            string[] subscriptionOptions = new string[] { "1.Daily", "2.Weekly (5% economy per visit)", "3.Mountly (15% economy per visit)", "4.Half a Year (50% economy per visit)", "5.Yearly (80% economy per visit)" };
            Console.WriteLine("Here is our possible subscription packages:");
            foreach (string option in subscriptionOptions) { Console.WriteLine(option); }
            Console.Write("\nPlease enter the number of the desired subscription: ");
            int validatedChoice = (int)Setters.SetNumericProperty("Subscription Number", 1, 0, 1, 0, 1, 5); // except 1-5
            string chosenSubscription = subscriptionOptions[validatedChoice - 1];
            return chosenSubscription;
        }

    }

}
