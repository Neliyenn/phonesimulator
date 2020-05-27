using System;
using System.Collections.Generic;
using System.Text;

namespace Phone_Emulator
{
    public static class PhoneCore
    {
        static int typingMenu = 0;

        public static void Start()
        {
            PhoneScreen.Initialize(MenuManager.startMenu);
        while(true)
            {
                ConsoleKey response = new ConsoleKey();
                string message = "";

                if (typingMenu == 0)
                    response = Console.ReadKey(true).Key;
                else if(typingMenu == 2)
                    MenuManager.ProceedCommand(2, "");
                else
                {
                    message = Console.ReadLine();

                    MenuManager.ProceedCommand(typingMenu, message);
                }
            }
        }
    }
}