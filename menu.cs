using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Versioning;
using System.Text;

namespace Phone_Emulator
{
    public static class MenuManager
    {
        static public bool findingSwitch = false;

        static List<string> addedText = new List<string>();

        public static List<string> startMenu = new List<string>
        {
            "1. Find a number/contact",
            "2. Show all contacts",
            "3. Add Contact",
            "4. Remove Contact",
            "5. Turn Off"
        };

        public static List<string> findContactMenu = new List<string>
        {
            ">>> FINDING CONTACT <<<",
            "{Type exit to return}",
            "{Type switch to change searching mode}: <MODE/>",
            "Type name or number to find:"
        };

         public static List<string> contactsListMenu = new List<string>
        {
            ">>> CONTACTS LIST <<<",
            "{Press any key to return}"
        };

        public static List<string> addContactMenu = new List<string>
        {
            ">>> ADDING CONTACT <<<",
            "{Type exit to return}",
            "Type name or number to add:"
        };

        public static List<string> removeContactMenu = new List<string>
        {
            ">>> REMOVING CONTACT <<<",
            "{Press backspace to return}"
        };

        static void ShowResults(ContactClass findingNumber, out bool numberFound)
        {
            Console.WriteLine(findingNumber.name + ": " + findingNumber.number);
            numberFound = true;
        }

        public static void ProceedCommand(int commandType, string command)
        {
            if (command == "exit")
                return;

            addedText.Clear();
            PhoneScreen.Reload();

            switch (commandType)
            {
                case 1:
                    {
                        bool numberFound = false;
                        string isNumber = "";

                        if(command == "switch")
                        {
                            findingSwitch = !findingSwitch;

                            PhoneScreen.Reload();

                            break;
                        }

                        for (int i = 0; i < command.Length; i++)
                        {
                            if (command[i] != ' ')
                                isNumber += command[i];
                        }

                        if(findingSwitch)
                        {
                            if (long.TryParse(isNumber, out long buffer))
                            {
                                foreach (ContactClass findingNumber in PhoneDatabase.contacts)
                                {
                                    bool exceptionFound = false;

                                    if (isNumber.Length > findingNumber.number.Length)
                                        break;

                                    for (int i = 0; i < isNumber.Length; i++)
                                    { 
                                        if (findingNumber.BaseNumber[i] != isNumber[i])
                                        {
                                            exceptionFound = true;
                                            break;
                                        }
                                    }

                                    if(!exceptionFound)
                                    {
                                        ShowResults(findingNumber, out numberFound);
                                    }
                                }
                            }
                            else
                            {
                                foreach (ContactClass findingNumber in PhoneDatabase.contacts)
                                {
                                    bool exceptionFound = false;

                                    if (command.Length > findingNumber.name.Length)
                                        break;

                                    for (int i = 0; i < command.Length; i++)
                                    {
                                        if (findingNumber.name[i] != command[i])
                                        {
                                            exceptionFound = true;
                                            break;
                                        }
                                    }

                                    if (!exceptionFound)
                                    {
                                        ShowResults(findingNumber, out numberFound);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (long.TryParse(isNumber, out long buffer))
                            {
                                foreach (ContactClass findingNumber in PhoneDatabase.contacts)
                                {
                                    if (findingNumber.BaseNumber.Contains(isNumber))
                                    {
                                        ShowResults(findingNumber, out numberFound);
                                    }
                                }
                            }
                            else
                            {
                                foreach (ContactClass findingNumber in PhoneDatabase.contacts)
                                {
                                    if (findingNumber.name.Contains(command))
                                    {
                                        ShowResults(findingNumber, out numberFound);
                                    }
                                }
                            }
                        }

                        Console.WriteLine("");

                        if(!numberFound)
                        {
                            Console.WriteLine("Number not found!");
                            Console.WriteLine("");
                        }

                        break;
                    }
                case 2:
                    {
                        foreach (ContactClass contact in PhoneDatabase.contacts)
                        {
                            Console.WriteLine("{0}: {1}", contact.name, contact.number);
                        }

                        Console.ReadKey(true);
                        PhoneCore.ForceReturn();

                        break;
                    }
                case 3:
                    {
                        string recycledCommand = "";

                        for (int i = 0; i < command.Length; i++)
                        {
                            if (command[i] != ' ')
                                recycledCommand += command[i];
                        }

                        if(long.TryParse(recycledCommand, out long buffer))
                        {
                            ContactClass contact = new ContactClass();
                            contact.number = recycledCommand;

                            Console.Write("Phone name: ");
                            contact.name = Console.ReadLine();

                            AddContact(contact);
                        }
                        else
                        {
                            ContactClass contact = new ContactClass();
                            contact.name = command;

                            Console.Write("Phone number: ");
                            string number = Console.ReadLine();

                            if(number.Contains(' '))
                            {
                                number = contact.NumberConvertWithSpaces(number);
                            }

                            if(long.TryParse(number, out long secBuffer))
                            {
                                contact.number = number;

                                AddContact(contact);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong Number!!!!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("{Press any key to return}");
                                Console.ReadKey(true);
                                PhoneCore.ForceReturn();
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (string titleText in removeContactMenu)
                        {
                            addedText.Add(titleText);
                        }

                        foreach (ContactClass contact in PhoneDatabase.contacts)
                        {
                            string textLine = contact.name + ": " + contact.number;
                            addedText.Add(textLine);
                        }

                        PhoneScreen.LoadMenu(addedText);

                        while(true)
                        {
                            ConsoleKey response = Console.ReadKey(true).Key;

                            if(PhoneCore.CheckForSelectChange(response, out int value))
                            {
                                PhoneScreen.MoveSelection(value); 
                            }
                            else if(response == ConsoleKey.Backspace)
                            {
                                PhoneCore.ForceReturn();

                                break;
                            }
                            else if(response == ConsoleKey.Enter)
                            { 
                                PhoneDatabase.contacts.Remove(PhoneDatabase.contacts[PhoneScreen.SelectionValue - 2]);

                                PhoneCore.ForceReturn();

                                break;
                            }
                        }
                        
                        break;
                    }
            }
        }

        static void AddContact(ContactClass contact)
        {
            PhoneDatabase.contacts.Add(contact);
            Console.WriteLine("Contact added --> Name: {0}, Number: {1}", contact.name, contact.number);
            Console.ReadKey(true);
            PhoneCore.ForceReturn();
        }
    }
}
