# Unit Testing with C\#

## Description

This simple project simulates an Information System of an HR department of a company.

It consists of two parts:

- **HRLib:** The library intended for testing, contains 6 methods - functions.
- **Unittests:** The project that tests the methods of HRLib.

>*This project was made during our software quality class.*

## A more in depth look at HRLib

Consists of the following methods and functions:

- **bool ValidName(string name):** Accepts an employee name. Returns true if the parameter is a valid name, else returns false.
- **bool ValidPassword(string password):** Accepts a password. Returns true if password is valid, else returns false.
- **EncryptPassword(string Password, ref string ΕncryptedPW):** Accepts a password, encrypts it and saves the encrypted password to the second parameter. The encryption is based on Caesar's Cypher (shift = 5).
- **CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone):** Accepts a number and checks if it's a valid phone number. Save the results to the ref parameters.
- **InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience):** Accepts data of an employee, and saves his age and years of experience in the ref parameters.
- **int LiveInAthens(Employee[] Empls):** Returns a sum of employees that live in Athens. This function calls 'CheckPhone()'.

A password is valid when it:

**a.** Has at least 12 characters\
**b.** Has a mix of uppercase and lowercase, numbers and symbols. (at least 1 character for each)\
**c.** Has only latin characters\
**d.** Starts with an uppercase character and ends with a number

## Technologies used

- Visual Studio 2022
