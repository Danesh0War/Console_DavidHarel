using FinalPoj1.Interfaces;

namespace FinalPoj1.UI
{
    internal class DisplayConfig // Class responsible for every new display creation
    {
        public int _selectedOptionIndex; // current selected menu option
        public string[] _menuOptions; // all desired menu options for definition
        public string _title; // every upper title when printing a new menu
        public bool running = true; // running conditions (until one of the options is chosed )

        //Constructor. Force to enter the parameters by every menu creation
        public DisplayConfig(string[] menuOptions, string title)
        {
            _menuOptions = menuOptions;
            _title = title;
            _selectedOptionIndex = 0; // by default the selected option would be the upper one
        }

        public void NewDisplayConfig(int selectedOption = 0)
        {
            _selectedOptionIndex = selectedOption;

            while (running)
            {
                Console.Clear();
                StaticInterfaces.MainHeader(); // By every menu always print the Header 
                Console.WriteLine($"{_title}\n"); // Then print title
                Console.WriteLine("Menu:");

                for (int i = 0; i < _menuOptions.Length; i++)
                {
                    if (i == _selectedOptionIndex) // every selected option would be marked by separate color
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("-> " + _menuOptions[i]);
                        Console.ResetColor();
                    }
                    else // other menu options would be printed unmarked
                    {
                        Console.WriteLine("   " + _menuOptions[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key) // allow to move between menus using keyboard
                {
                    case ConsoleKey.UpArrow:
                        _selectedOptionIndex = Math.Max(0, _selectedOptionIndex - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        _selectedOptionIndex = Math.Min(_menuOptions.Length - 1, _selectedOptionIndex + 1);
                        break;

                    case ConsoleKey.Enter: // stop when one of the options is choosed
                        running = false;
                        break;
                }
            }
        }
    }
}
