using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HRLib
{
    public class Class1
    {
        public struct Employee
        {
            public string Name;
            public string HomePhone;
            public string MobilePhone;
            public DateTime Birthday;
            public DateTime HiringDate;

            public Employee(string Name, string HomePhone, string MobilePhone, DateTime Birthday, DateTime HiringDate)
            {
                this.Name = Name;
                this.HomePhone = HomePhone;
                this.MobilePhone = MobilePhone;
                this.Birthday = Birthday;
                this.HiringDate = HiringDate;
            }
        }

        // 1
        public bool validName(string Name)
        {
            bool valid = false;
            string pattern = "^[A-Za-z]+ [A-Za-z]+$";
            Regex rg = new Regex(pattern);

            if (rg.IsMatch(Name))
            {
                valid = true;
            }
            return valid;
        }

        // 2
        public bool ValidPassword(string Password)
        {
            bool valid = false;

            int upperCounter = 0;
            int lowerCounter = 0;
            int numCounter = 0;
            int symbCounter = 0;
            int unknownCounter = 0;

            if (Password.Length >= 12)
            {
                if (Char.IsUpper(Password[0]) && Char.IsNumber(Password[Password.Length - 1]))
                {
                    foreach (char c in Password)
                    {
                        if (c >= 'A' && c <= 'Z') // checks if char is uppercase AND latin
                        {
                            upperCounter++;
                        }
                        else if (c >= 'a' && c <= 'z') // checks if char is lowercase AND latin
                        {
                            lowerCounter++;
                        }
                        else if (Char.IsNumber(c))
                        {
                            numCounter++;
                        }
                        else if (Char.IsSymbol(c) || Char.IsPunctuation(c))
                        {
                            symbCounter++;
                        }
                        else
                        {
                            unknownCounter++;
                        }
                    }
                    if (unknownCounter == 0 && upperCounter > 0 && lowerCounter > 0 && numCounter > 0 && symbCounter > 0)
                    {
                        valid = true;
                    }
                }
            }
            return valid;
        }

        // 3
        public void EncryptPassword(string Password, ref string EncryptedPW)
        {
            EncryptedPW = "";
            if (Password != null)
            {
                foreach (char c in Password)
                {
                    char temp = c;
                    if ((int)c >= 122) // avoids overflow on ASCII table
                    {
                        temp = (char)(c - 94); // include only A-Z, a-z and symbols
                    }
                    EncryptedPW += (char)(temp + 5);
                }
            }
        }

        // 4
        public void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone)
        {
            if (Phone.StartsWith("210"))
            {
                TypePhone = 0;
                InfoPhone = "21";
            }
            else if (Phone.StartsWith("22"))
            {
                TypePhone = 0;
                InfoPhone = "22";
            }
            else if (Phone.StartsWith("23"))
            {
                TypePhone = 0;
                InfoPhone = "23";
            }
            else if (Phone.StartsWith("24"))
            {
                TypePhone = 0;
                InfoPhone = "24";
            }
            else if (Phone.StartsWith("25"))
            {
                TypePhone = 0;
                InfoPhone = "25";
            }
            else if (Phone.StartsWith("26"))
            {
                TypePhone = 0;
                InfoPhone = "26";
            }
            else if (Phone.StartsWith("27"))
            {
                TypePhone = 0;
                InfoPhone = "27";
            }
            else if (Phone.StartsWith("28"))
            {
                TypePhone = 0;
                InfoPhone = "28";
            }
            else if (Phone.StartsWith("690") || Phone.StartsWith("693") || Phone.StartsWith("699"))
            {
                TypePhone = 1;
                InfoPhone = "NOVA";
            }
            else if (Phone.StartsWith("694") || Phone.StartsWith("695"))
            {
                TypePhone = 1;
                InfoPhone = "VODAFONE";
            }
            else if (Phone.StartsWith("697") || Phone.StartsWith("698"))
            {
                TypePhone = 1;
                InfoPhone = "COSMOTE";
            }
            else
            {
                TypePhone = -1;
                InfoPhone = null;
            }
        }

        // 5
        public void InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience)
        {
            if ((DateTime.Now.Year - EmplX.Birthday.Year) >= 0)
                Age = DateTime.Now.Year - EmplX.Birthday.Year;
            else Age = -1;
            if ((DateTime.Now.Year - EmplX.HiringDate.Year) >= 0)
                YearsOfExperience = DateTime.Now.Year - EmplX.HiringDate.Year;
            else YearsOfExperience = -1;
        }

        // 6
        public int LiveInAthens(Employee[] Empls)
        {
            int counter = 0;
            int tempType = 0;
            string tempInfoPhone = "";
            foreach (Employee emp in Empls)
            {
                CheckPhone(emp.HomePhone, ref tempType, ref tempInfoPhone);
                if (tempInfoPhone != null)
                {
                    if (tempInfoPhone.Equals("21") && tempType == 0)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}
