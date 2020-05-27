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
        }