using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalPoj1.Models;
using FinalPoj1.Servises;
using FinalPoj1.UI;

namespace FinalPoj1.Interfaces
{
    //Clients Interface (Building 2nd display opt 1)
    internal class ClientInterface : CommonInterfaces // take Subinterfaces from CommonInterfaces

    {

        public static int ClientsInterf()
        {
            //Interface configuration
            string title = "You chosed to manage the clients. \nPlease choose which action to perform ";
            string[] menuOptions = new string[7] { "Add Client", "Edit Client", "Delete Client", "Show all Clients", "Attendance registration", "Attendance Report", "Back" };
            DisplayConfig subMenu = new DisplayConfig(menuOptions, title);
            subMenu.NewDisplayConfig();

            //Options implementation
            switch (subMenu._selectedOptionIndex)
            {
                case 0: // new client 
                    {
                        Console.WriteLine("\nPlease fill the following fields in order to add a new client:\n");
                        Client newClient = new Client();
                        FileManager.SerializeAndSaveClientData(newClient);
                        Console.WriteLine("Press any key to comeback to the main menu.");
                        Console.ReadKey(); // wait so user sees the write line message
                    }
                    break; // fall out from switch to MaintInterf main switch

                case 1: //edit client 
                    {
                        int selectedOption = 0;
                        bool ischoosed = false;
                        while (!ischoosed)
                        {
                            int output = EditPersonInterf(selectedOption); // subsub menu
                            switch (output)
                            {
                                case 0:
                                    FileManager.EditPerson(FileManager.EntityType.Client);
                                    Console.WriteLine("Press any key to comeback to the main menu.");
                                    Console.ReadKey();
                                    break; // fall out to while loop - next step stop loop
                                case 1:
                                    break; // fall out to while loop - next step stop loop
                            }

                            ischoosed = true; // stop loop - case ended - next step will be break
                                              //Program.MaintInterf(0);
                        }
                    }

                    break; // fall out from switch to MaintInterf main switch


                case 2: // delete client
                    {
                        int selectedOption = 0;
                        bool ischoosed = false;
                        while (!ischoosed)
                        {
                            int output = DeletePersonInterf(selectedOption); // subsub menu
                            switch (output)
                            {
                                case 0:
                                    FileManager.DeletePerson(FileManager.EntityType.Client);
                                    Console.WriteLine("Press any key to comeback to the main menu.");
                                    Console.ReadKey();

                                    break; // fall out to while loop - next step stop loop
                                case 1:
                                    FileManager.ReallyDeletePerson(FileManager.EntityType.Client);
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


                case 3: // List all Clients
                    {
                        List<ExistingClients> list = ExistingClients.LoadAllClients(); // create a new ExistingClients instancer to load data into
                        Console.WriteLine();
                        foreach (var client in list)
                        {
                            Console.WriteLine(client.ToString());
                            Console.WriteLine();
                        }

                        Console.WriteLine("Press any key to comeback to the main menu.");
                        Console.ReadKey();
                    }

                    break; // fall out from switch to MaintInterf main switch


                case 4: // Attendance Registration
                    {
                        int selectedOption = 0;
                        bool ischoosed = false;
                        while (!ischoosed)
                        {
                            int output = AttendanceRegisterInterf(selectedOption); // subsub menu
                            switch (output)
                            {
                                case 0:
                                    string ID = FileManager.IDCheck(FileManager.EntityType.Client);
                                    Attendance.SetAttendanceReport(ID);
                                    Console.WriteLine("Press any key to comeback to the main menu.");
                                    Console.ReadKey();
                                    break; // fall out to while loop - next step stop loop
                                case 1:
                                    break; // fall out to while loop - next step stop loop

                            }
                            ischoosed = true; // stop loop - case ended - next step will be break
                                              //Program.MaintInterf(0);
                        }
                    }

                    break; // fall out from switch to MaintInterf main switch


                case 5: // Attendance Report
                    {
                        int selectedOption = 0;
                        bool ischoosed = false;
                        while (!ischoosed)
                        {
                            int output = AttendanceReportInterf(selectedOption); // subsub menu
                            switch (output)
                            {
                                case 0:
                                    string ID = FileManager.IDCheck(FileManager.EntityType.Client);
                                    Console.WriteLine("List of Attendance reports for the selected user:\n");
                                    Attendance.GetAttendancyReport(ID);
                                    Console.WriteLine("Press any key to comeback to the main menu.");
                                    Console.ReadKey();
                                    break; // fall out to while loop - next step stop loop
                                case 1:
                                    break; // fall out to while loop - next step stop loop

                            }
                            ischoosed = true; // stop loop - case ended - next step will be break
                        }

                    }

                    break; // fall out from switch to MaintInterf main switch


                case 6:
                    break;
            }

            return 0; // value returns to MainInterfase and the upper option is selected in the main interface.
        }




    }
}
