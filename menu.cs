using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Phone_Emulator
{
    public static class MenuManager
    {
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
            "{Type exit to return}",
            "Type name or number to remove:"
        };

        public static void ProceedCommand(int commandType, string command)
        {
            if (command == "exit")
                return;

            switch(commandType)
            {
                case 1:
                    {
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
                        if(long.TryParse(command, out long buffer))
                        {
                            ContactClass contact = new ContactClass();
                            contact.number = command;

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
                        break;
                    }
            }
        }