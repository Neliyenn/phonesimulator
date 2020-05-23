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

        public string FindingNumber() => contactNumber;

        public string NumberConvertWithSpaces(string convert)
        {
            string correctNumber = "";

            string[] buffer = convert.Split(' ');

            for (int i = 0; i < buffer.Length; i++)
            {
                correctNumber += buffer[i];
            }

            return correctNumber;
        }

        public string NumberConvertWithoutSpaces(string convert)
        {
            string correctNumber = "";

            if(convert.Length == 8)
            {
                if (PhoneDatabase.prefixes.Contains(int.Parse(convert[0] + "" + convert[1])))
                {
                    for (int first = 0; first < 2; first++)
                    {
                        correctNumber += convert[first];
                    }

                    correctNumber += " ";

                    for (int sec = 2; sec < 4; sec++)
                    {
                        correctNumber += convert[sec];
                    }

                    correctNumber += " ";

                    for (int third = 4; third < 8; third++)
                    {
                        correctNumber += convert[third];
                    }
                }
            }