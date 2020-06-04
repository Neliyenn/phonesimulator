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
        static int minSelection;

        static List<string> actualUsingMenu = new List<string>();

        public static void Initialize(List<string> loadMenu)
        {
            selectedOption = 0;

            LoadMenu(loadMenu);
        }   

        public static void LoadMenu(List<string> loadMenu)
        {
            actualUsingMenu = loadMenu;

            Update(selectedOption);
        }

        public static void Reload()
        {
            bool lockState = isBlocked;

            LockSelection(false);
            Update(selectedOption);
            LockSelection(lockState);
        }

        static void Update(int selected)
        {
            if (isBlocked)
                return;

            Console.Clear();
         
            if (selected > actualUsingMenu.Count - 1)
                selected = actualUsingMenu.Count - 1;

            for (int displayElementIndex = 0; displayElementIndex < actualUsingMenu.Count; displayElementIndex++)
            {
                if (selected == displayElementIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(actualUsingMenu[displayElementIndex]);
                }
                else
                {
                    if (actualUsingMenu[displayElementIndex].Contains("<MODE/>"))
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write(actualUsingMenu[displayElementIndex].Split('<')[0]);

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine(MenuManager.findingSwitch ? "Only first letter counts" : "If contact contains");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine(actualUsingMenu[displayElementIndex]);
                    }
                }
            }
        }

        public static void SetSelection(int selection, int minValue = 0) 
        {
            minSelection = minValue;
            Update(selection);
            selectedOption = selection;
        }
        public static void LockSelection(bool block) => isBlocked = block;
        public static int SelectionValue { get => selectedOption; } 
        public static void MoveSelection(int moveHolder)
        {
            int minRange = minSelection;
            int maxRange = actualUsingMenu.Count - 1;

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

            Update(selectedOption);
        }
    }
}