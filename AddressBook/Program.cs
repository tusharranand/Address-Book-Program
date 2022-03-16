using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Contacts
    {
        public string First_Name = "";
        public string Last_Name = "";
        public string Full_Name = "";
        public string Address = "";
        public string City = "";
        public string State = "";
        public string Zip_Code = "";
        public string Phone_Number = "";
        public string Email = "";
        public Contacts()
        {
            Console.Write("Enter First Name: ");
            First_Name = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            Last_Name = Console.ReadLine();
            Full_Name = First_Name.ToLower() + Last_Name.ToLower();
            Console.Write("Enter Address: ");
            Address = Console.ReadLine();
            Console.Write("Enter City: ");
            City = Console.ReadLine();
            Console.Write("Enter State: ");
            State = Console.ReadLine();
            Console.Write("Enter Zip : ");
            Zip_Code = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            Phone_Number = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            Email = Console.ReadLine();
        }
    }
    class AddressBookMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            Contacts Details = new Contacts();
        }
    }
}