using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalPoj1.UI;

namespace FinalPoj1.Interfaces
{
    internal class CommonInterfaces // Common subinterfaces used in Client and Coaches Interface 
    {

        public static int MaintInterf(int selectedOption)
        {
            string title = "Welcome to the retro application for gym clients and workers registration and management! \nPlease choose whether to register a new user or manage the existing one";
            string[] menuOptions = new string[4] { "Clients", "Coaches", "Credentias", "Exit" };
            DisplayConfig mainMenu = new DisplayConfig(menuOptions, title);
            mainMenu.NewDisplayConfig(selectedOption);
            return mainMenu._selectedOptionIndex;
        }

        public static int EditPersonInterf(int selectedOption)
        {
            string title = "You chosed to edit the existing personal info";
            string[] menuOptions = new string[2] { "Enter personal ID", "Back" };
            DisplayConfig submenu = new DisplayConfig(menuOptions, title);
            submenu.NewDisplayConfig(selectedOption);
            return submenu._selectedOptionIndex;
        }

        public static int DeletePersonInterf(int selectedOption)
        {
            string title = "You chosed to delete the existing personal info";
            string[] menuOptions = new string[3] { "Set to Inactive", "Really delete folder", "Back" };
            DisplayConfig submenu = new DisplayConfig(menuOptions, title);
            submenu.NewDisplayConfig(selectedOption);
            return submenu._selectedOptionIndex;
        }

        public static int AttendanceRegisterInterf(int selectedOption)
        {
            string title = "You chosed to add the attendance report";
            string[] menuOptions = new string[2] { "Enter personal ID", "Back" };
            DisplayConfig submenu = new DisplayConfig(menuOptions, title);
            submenu.NewDisplayConfig(selectedOption);
            return submenu._selectedOptionIndex;
        }

        public static int AttendanceReportInterf(int selectedOption)
        {
            string title = "You chosed to represent attendance reports for the specified person";
            string[] menuOptions = new string[2] { "Enter personal ID", "Back" };
            DisplayConfig submenu = new DisplayConfig(menuOptions, title);
            submenu.NewDisplayConfig(selectedOption);
            return submenu._selectedOptionIndex;
        }
    }
}
