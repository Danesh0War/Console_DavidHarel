using FinalPoj1.Models;
using FinalPoj1.Servises;

namespace FinalPoj1.Interfaces
{
    internal class StaticInterfaces 
    {

        //func1
        static public void MainHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Center the header text
            int centerX = Console.WindowWidth / 2;
            Console.SetCursorPosition(centerX - 38, 0);
            Console.WriteLine(@"
                                  ------------------<Retro App>----------------                 
                                    _   __              ______             
                                   / | / /__  ____     / ____/_  ______ ___ 
                                  /  |/ / _ \/ __ \   / / __/ / / / __ `__ \
                                 / /|  /  __/ /_/ /  / /_/ / /_/ / / / / / /
                                /_/ |_/\___/\____/   \____/\__, /_/ /_/ /_/ 
                                                          /____/ 
                               ------------<For the Retro Gym>--------------                  
    ");

            Console.ResetColor();
        }

        //func2

        static public void Credentials()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Center the header text

            Console.WriteLine(@"
             .----------------------------------------------------------------------------.
             | This software was developed as part of the SELA College educational project.|
             | Thanks to my teacher and to all of the mentors. I love you!                 |
             | And may Uncle Bob bless Us All!                                             |
             |                                                 Yours, Daniel Riazanov      |
             '-----------------------------------------------------------------------------'
    ");



        }
    }
}
