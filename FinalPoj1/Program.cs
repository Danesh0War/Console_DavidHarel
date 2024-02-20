namespace FinalPoj1;

using FinalPoj1.Interfaces;
using FinalPoj1.Models;
using FinalPoj1.UI;


public class Program
{     
    public static void Main(string[] args)
    {
        StaticInterfaces.MainHeader();

        int selectedOption = 0; // by default the choses menu will be in index 0 (upper menu) - In our case Clients
        while (true)
        {
            int output = CommonInterfaces.MaintInterf(selectedOption); // breaking out from one of the subinterfaces switch returns number. This number enters MaintInterf and than functions prints with the chosen optiopn marked. 
            switch (output)
            {
                case 0: // Clears console and represents Client interface menu
                    Console.Clear();
                    ClientInterface.ClientsInterf();
                    break;

                case 1: // Clears console and represents Coach interface menu
                    Console.Clear();
                    CoachesInterface.CoachesInterf();
                    break;

                case 2: // Under the menu prints credentials
                    StaticInterfaces.Credentials();
                    Console.WriteLine("\nPress any key to go back to the main menu.");
                    Console.ReadKey();
                    //MaintInterf(3);
                    break;

                case 3: // EndPoint. Not simply fall out from switch, but close the console. 
                    Environment.Exit(0);
                    break;
              
            }
        }
    }


}




