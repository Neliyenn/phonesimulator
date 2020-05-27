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
            
        
    }
}