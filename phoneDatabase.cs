using System;
using System.Collections.Generic;
using System.Text;

namespace Phone_Emulator
{
    public static class PhoneDatabase
    {
        public static List<int> prefixes = new List<int>
            {12,13,14,15,16,17,18,22,23,24,25,
             29,32,33,34,41,42,43,44,46,47,52,
             54,55,56,58,59,61,62,63,65,67,68,
             71,74,75,76,77,81,82,83,84,85,86,
             87,89,91,94,95};

             public static List<int> alarmNumbers = new List<int>
        {
            112,984,985,986,987,991,992,993,994,997,998,999
        };

        public static List<ContactClass> contacts = new List<ContactClass>();
    }
}