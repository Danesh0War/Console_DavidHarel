using FinalPoj1.Models;
using FinalPoj1.Servises;
using FinalPoj1.UI;

namespace FinalPoj1.Interfaces
{
    internal class CoachesInterface : CommonInterfaces
    {
        //Coaches Interface (Building 2nd display opt 2)
        public static int CoachesInterf()
        {
            //Interface configuration
            string title = "You chosed to deal with the coaches. \nPlease choose which action to perform ";
            string[] menuOptions = new string[5] { "Add Coach", "Edit Coach", "Delete Coach", "Show all Coaches", "Back" };
            DisplayConfig subMenu = new DisplayConfig(menuOptions, title);
            subMenu.NewDisplayConfig();

            //Options implementation
            switch (subMenu._selectedOptionIndex)
            {
                case 0: // New Coach
                    {
                        Console.WriteLine("\nPlease fill the following fields in order to add a new client:\n");
                        Coach newCoach = new Coach();
                        FileManager.SerializeAndSavePersonalData(newCoach);
                        Console.WriteLine("Press any key to comeback to the main menu.");
                        Console.ReadKey(); // wait so user sees the write line message

                    }
                    break;

                case 1:  //Edit Coach

                    {
                        int selectedOption = 0;
                        bool ischoosed = false;
                        while (!ischoosed)
                        {
                            int output = EditPersonInterf(selectedOption); // subsub menu
                            switch (output)
                            {
                                case 0:
                                    FileManager.EditPerson(FileManager.EntityType.Coach);
                                    Console.WriteLine("Press any key to comeback to the main menu.");
                                    Console.ReadKey();
                                    break; // fall out to while loop - next step stop loop
                                case 1:
                                    break; // fall out to while loop - next step stop loop
                            }

                            ischoosed = true; // stop loop - case ended - next step will be break
                        }

                    }
                    break;

                case 2: // Delete Coach
                    {
                        int selectedOption = 0;
                        bool ischoosed = false;
                        while (!ischoosed)
                        {
                            int output = DeletePersonInterf(selectedOption); // subsub menu
                            switch (output)
                            {
                                case 0:
                                    FileManager.DeletePerson(FileManager.EntityType.Coach);
                                    Console.WriteLine("Press any key to comeback to the main menu.");
                                    Console.ReadKey();
                                    break; // fall out to while loop - next step stop loop

                                case 1:
                                    FileManager.ReallyDeletePerson(FileManager.EntityType.Coach);
                                    Console.WriteLine("Press any key to comeback to the main menu.");
                                    Console.ReadKey();
                                    break; // fall out to while loop - next step stop loop

                                case 2:
                                    break; // fall out to while loop - next step stop loo
                            }
                            ischoosed = true; // stop loop - case ended - next step will be break
                                              //Program.MaintInterf(0);
                        }
                    }
                    break; // fall out from switch to MaintInterf main switch

                case 3: // List all Coaches
                    {
                        List<ExistingCoaches> list = ExistingCoaches.LoadAllCoaches();
                        Console.WriteLine();
                        foreach (var coach in list)
                        {
                            Console.WriteLine(coach.ToString());
                            Console.WriteLine();
                        }

                        Console.WriteLine("Press any key to comeback to the main menu.");
                        Console.ReadKey();
                    }

                    break; // fall out from switch to MaintInterf main switch

                case 4:
                    break;
            }

            return 1;
        }


    }
}
