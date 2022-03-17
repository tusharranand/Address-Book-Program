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
        public Contacts(string First, string Last)
        { 
            First_Name = First;
            Last_Name = Last;  
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
        public Dictionary<string, Contacts> Book = new Dictionary<string, Contacts>();
        public void AddAddress()
        {
            string First = "";
            string Last = "";
            Console.Write("Enter First Name: ");
            First = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            Last = Console.ReadLine();
            Contacts Details = new Contacts(First, Last);
            Book.Add(Details.Full_Name, Details);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBookMain Record = new AddressBookMain();
            Record.AddAddress();  
        }
    }
}