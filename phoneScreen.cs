using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phone_Emulator
{
    public static class PhoneScreen
    {
     static int selectedOption;
        static bool isBlocked;

        static List<string> menus = new List<string>();

        public static void Initialize(List<string> loadMenu)
        {
            selectedOption = 0;

            LoadMenu(loadMenu);
        }   
    
    }
}