using HRLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.Class1;

namespace Unittests
{
    [TestClass]
    public class UnitTest1
    {
        const string msg1 = "Invalid name";
        const string msg2 = "Invalid password";
        const string msg3 = "Encryption failed";
        const string msg4 = "Invalid Phone number";
        const string msg5 = "Invalid Employee Info";
        const string msg6 = "Invalid count";

        HRLib.Class1 b = new HRLib.Class1();
        Employee[] empList1 = new Employee[]
        {
                new Employee("PATATA NTOMATA", "666224466", "6968686868", new DateTime(2000, 11, 11), new DateTime(2001, 1, 1)), //Invalid Home number
                new Employee("TZATZIKI KOTOPOULO", "223111213", "7032452819", new DateTime(2001, 11, 12), new DateTime(2003, 5, 3)), //Invalid Mobile number
                new Employee("GIANNIS", "223123456", "6912345678", new DateTime(2005, 1, 7), new DateTime(2023, 2, 16)), //Invalid name
                new Employee("-$!3@", "210151617", "6981239458", new DateTime(2011, 5, 2), new DateTime(2023, 1, 3)) //Invalid name
        };

        Employee[] empList2 = new Employee[]
        {
                new Employee("-", "210191919", "6968686868", new DateTime(2000, 11, 11), new DateTime(2001, 1, 1)), 
                new Employee("-", "210181818", "7032452819", new DateTime(2001, 11, 12), new DateTime(2003, 5, 3)), 
                new Employee("-", "210171717", "6912345678", new DateTime(2005, 1, 7), new DateTime(2023, 2, 16)), 
                new Employee("-", "210161616", "6981239458", new DateTime(2011, 5, 2), new DateTime(2023, 1, 3))
        };

        Employee[] empList3 = new Employee[]
        {
                new Employee("-", "222202020", "6968686868", new DateTime(2000, 11, 11), new DateTime(2001, 1, 1)),
                new Employee("-", "222212121", "7032452819", new DateTime(2001, 11, 12), new DateTime(2003, 5, 3)),
                new Employee("-", "222222222", "6912345678", new DateTime(2005, 1, 7), new DateTime(2023, 2, 16)),
                new Employee("-", "222232323", "6981239458", new DateTime(2011, 5, 2), new DateTime(2023, 1, 3))
        };

        string[] passwordList =
        {
            "PasswordMPLAMPLA$1",
            "NutellaNutella+6",
            "password.Mpla5",
            "Password,mplaaa", // not valid password
            "QWERTYMPLA+5555" // not valid password
        };


        [TestMethod]
        public void TestValidName()
        {
            object[,] testcases =
            {
                { 1, empList1[0].Name, true, msg1 },
                { 2, empList1[1].Name, true, msg1 },
                { 3, empList1[2].Name, true, msg1 },
                { 4, empList1[3].Name, false, msg1 }
            };

            bool failed = false;

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual(testcases[i, 2], b.validName((string)testcases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 3], ex.Message);
                }
            }
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestValidPassword()
        {
            object[,] testcases =
            {
                { 1, passwordList[0], true, msg2 },
                { 2, passwordList[1], true, msg2 },
                { 3, passwordList[2], false, msg2 },
                { 4, passwordList[3], false, msg2 },
                { 5, passwordList[4], true, msg2 }
            };

            bool failed = false;

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual(testcases[i, 2], b.ValidPassword((string)testcases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 3], ex.Message);
                }
            }
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestEncryptPassword()
        {
            object[,] testcases =
            {
                { 1, passwordList[0], "Ufxx|twiRUQFRUQF)6", msg3 },
                { 2, passwordList[1], "SzyjqqfSzyjqqf0;", msg3 },
                { 3, passwordList[2], "ufxx|twi3Ruqf:", msg3 },
                { 4, passwordList[3], "Ufxx|twi1ruqfff", msg3 },
                { 5, passwordList[4], "V\\JWY^RUQF0::::", msg3 } // Double backslash '\\' to escape
            };

            bool failed = false;

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    string temp = "";
                    b.EncryptPassword(passwordList[i], ref temp);
                    Assert.AreEqual(testcases[i, 2], temp);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 3], ex.Message);
                }
            }
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestCheckPhone() 
        {
            object[,] testcases =
            {
                { 1, empList1[0].HomePhone, -1, null , msg4 },
                { 2, empList1[1].MobilePhone, -1, null , msg4 },
                { 3, empList1[2].HomePhone, 0, "23", msg4 },
                { 4, empList1[3].MobilePhone, 1, "COSMOTE", msg4 }
            };

            bool failed = false;

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    int tempType = -2;
                    string tempZone = "";
                    b.CheckPhone((string)testcases[i, 1], ref tempType, ref tempZone);
                    Assert.AreEqual(testcases[i, 2], tempType); //Checks type
                    Assert.AreEqual(testcases[i, 3], tempZone); //Checks zone
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 4], ex.Message);
                }
            }
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestInfoEmployee()
        {
            object[,] testcases =
            {
                { 1, empList1[0], 24, -15 , msg5 },
                { 2, empList1[1], 23, 21 , msg5 },
                { 3, empList1[2], 19, 1, msg5 },
                { 4, empList1[3], 13, 1, msg5 }
            };

            bool failed = false;

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    int tempAge = 0;
                    int tempExp = 0;
                    b.InfoEmployee((Employee)testcases[i, 1], ref tempAge, ref tempExp);
                    Assert.AreEqual(testcases[i, 2], tempAge); //Checks age
                    Assert.AreEqual(testcases[i, 3], tempExp); //Checks experience
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 4], ex.Message);
                }
            }
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestLiveInAthens()
        {
            object[,] testcases =
            {
                { 1, empList1, 1, msg6 },
                { 2, empList2, 4, msg6 },
                { 3, empList3, 2, msg6 },
            };

            bool failed = false;

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual(testcases[i, 2], b.LiveInAthens((Employee[])testcases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 3], ex.Message);
                }
            }
            if (failed) Assert.Fail();
        }
    }
}
