using System;
using System.Collections.Generic;
using System.Text;

namespace Phone_Emulator
{
    public class ContactClass
    {
        string contactName;
        string contactNumber;

        public string number
        {
            get
            {
                return NumberConvertWithoutSpaces(contactNumber);
            }
            set
            {
                contactNumber = NumberConvertWithSpaces(value);
            }
        }

        public string name
        {
            get => contactName;
            set => contactName = value;
        }
