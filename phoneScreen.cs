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

        public static void LoadMenu(List<string> loadMenu)
        {
            menus = loadMenu;

            Update(selectedOption);
        }

        static void Update(int selected)
        {
            if (isBlocked)
                return;

            Console.Clear();
         
            if (selected > menus.Count - 1)
                selected = menus.Count - 1;

            for (int displayElementIndex = 0; displayElementIndex < menus.Count; displayElementIndex++)
            {
                if (selected == displayElementIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(menus[displayElementIndex]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(menus[displayElementIndex]);
                }
            }
        }

        public static void SetSelection(int selection) => Update(selection);
        public static void LockSelection(bool block) => isBlocked = block;
        public static int SelectionValue { get => selectedOption; } 
        public static void MoveSelection(int moveHolder)
        {
            int minRange = 0;
            int maxRange = menus.Count - 1;

            if (isBlocked)
                return;

            switch (moveHolder)
            {
                case -1:
                    if(selectedOption < maxRange)
                    {
                        selectedOption++;
                    }
                    else
                    {
                        selectedOption = minRange;
                    }
                    break;
                case 1:
                    if (selectedOption > minRange)
                    {
                        selectedOption--;
                    }
                    else
                    {
                        selectedOption = maxRange;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}