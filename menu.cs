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