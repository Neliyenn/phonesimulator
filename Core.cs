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
                else if(typingMenu == 4)
                    MenuManager.ProceedCommand(4, "");
                else
                {
                    message = Console.ReadLine();

                    MenuManager.ProceedCommand(typingMenu, message);
                }

                if (CheckForSelectChange(response, out int value))
                { 
                    PhoneScreen.MoveSelection(value);
                }

                if(CheckForConfirm(response))
                {
                    switch(PhoneScreen.SelectionValue)
                    {
                        case 0:
                            {
                                PhoneScreen.LoadMenu(MenuManager.findContactMenu);
                                PhoneScreen.SetSelection(0);
                                PhoneScreen.LockSelection(true);
                                typingMenu = 1;
                                break;
                            }
                        case 1:
                            {
                                PhoneScreen.LoadMenu(MenuManager.contactsListMenu);
                                PhoneScreen.SetSelection(0);
                                PhoneScreen.LockSelection(true);
                                typingMenu = 2;
                                break;
                            }
                        case 2:
                            {
                                PhoneScreen.LoadMenu(MenuManager.contactsListMenu);
                                PhoneScreen.SetSelection(0);
                                PhoneScreen.LockSelection(true);
                                typingMenu = 3;
                                break;
                            }
                        case 3:
                            {
                                PhoneScreen.LoadMenu(MenuManager.contactsListMenu);
                                PhoneScreen.SetSelection(0);
                                PhoneScreen.LockSelection(true);
                                typingMenu = 4;
                                break;
                            }
                        case 4:
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                return;
                            }
                    }

                }

                if(CheckForReturn(message))
                {
                    ForceReturn();
                }
            }
        }
            
        public static bool CheckForSelectChange(ConsoleKey pressedButton, out int valueChange)
        {
            if (pressedButton == ConsoleKey.UpArrow)
            {
                valueChange = 1;
                return true;
            }

            if (pressedButton == ConsoleKey.DownArrow)
            {
                valueChange = -1;
                return true;
            }

            valueChange = 0;
            return false;
        }

        static bool CheckForConfirm(ConsoleKey pressedButton)
        {
            return pressedButton == ConsoleKey.Enter;
        }

        static bool CheckForReturn(string typedCommand)
        {
            return typedCommand == "exit";
        }

        public static void ForceReturn()
        {
            PhoneScreen.LockSelection(false);
            PhoneScreen.LoadMenu(MenuManager.startMenu);
            typingMenu = 0;
            PhoneScreen.SetSelection(PhoneScreen.SelectionValue);
        }
    }
}