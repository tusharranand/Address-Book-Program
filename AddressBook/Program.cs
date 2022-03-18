using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Contacts
    {
        public string[] Array_of_Details = new string[8];
        public Contacts(string First, string Last, string Add, string City, string State, string Zip, string Phone, string Email)
        {
            Array_of_Details[0] = First;
            Array_of_Details[1] = Last;
            Array_of_Details[2] = Add;
            Array_of_Details[3] = City;
            Array_of_Details[4] = State;
            Array_of_Details[5] = Zip;
            Array_of_Details[6] = Phone;
            Array_of_Details[7] = Email;
        }
        public void Check()
        {
            Console.WriteLine("\nThe details for {0} {1} are:\nAddress: {2}\nCity: {3}\nState: {4}\n" +
                "Zip Code: {5}\nPhone Number: {6}\nEmail: {7}\n", Array_of_Details[0], 
                Array_of_Details[1], Array_of_Details[2], Array_of_Details[3], 
                Array_of_Details[4], Array_of_Details[5], Array_of_Details[6], Array_of_Details[7]);
        }
    }
    class AddressBookMain
    {
        Dictionary<string, string[]> Page;
        
        public void AddAddress()
        {
            Console.Write("Enter First Name: ");
            string First_Name = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string Last_Name = Console.ReadLine();
            Console.Write("Enter Address: ");
            string Address = Console.ReadLine();
            Console.Write("Enter City: ");
            string City = Console.ReadLine();
            Console.Write("Enter State: ");
            string State = Console.ReadLine();
            Console.Write("Enter Zip : ");
            string Zip_Code = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string Phone_Number = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            string Email = Console.ReadLine();
            Contacts Record = new Contacts(First_Name, Last_Name, Address, City, State, Zip_Code, Phone_Number, Email);
            Page = new Dictionary<string, string[]>();
            Page.Add(First_Name, Record.Array_of_Details);
            Record.Check();
        }
        public void Edit()
        {
            Console.Write("Enter the first name for the contact: ");
            string First_Name = Console.ReadLine();
            Console.Write("Enter a number to edit first name(1), last name(2), address(3), city(4), state(5), zip code(6), \nphone number(7) or email(8): ");
            int Index = Convert.ToInt32(Console.ReadLine());
            if (!Page.ContainsKey(First_Name))
                throw new ArgumentNullException("No such person in the Addressbook");
            Page.TryGetValue(First_Name, out string[] Edit_Detail);
            Console.Write("Enter the new value: ");
            Edit_Detail[Index-1] = Console.ReadLine();
            Contacts Record = new Contacts(Edit_Detail[0], Edit_Detail[1], Edit_Detail[2], Edit_Detail[3], Edit_Detail[4], Edit_Detail[5], Edit_Detail[6], Edit_Detail[7]);
            Page.Remove(First_Name);
            Page.Add(Edit_Detail[0], Edit_Detail);
            Record.Check();
        }
        public void Delete()
        {
            Console.Write("Enter the first name for the contact: ");
            string First_Name = Console.ReadLine();
            if (!Page.ContainsKey(First_Name))
                throw new ArgumentNullException("No such person in the Addressbook");
            Page.TryGetValue(First_Name, out string[] Edit_Detail);
            Page.Remove(First_Name);
            Console.WriteLine("Address entry for {0} {1} was removed.", Edit_Detail[0], Edit_Detail[1]);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBookMain Book = new AddressBookMain();
            Console.Write("Enter the number of address you want to add: ");
            int Number = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Number; i++)
            {
                Book.AddAddress();
            }
            Console.Write("Do you want to edit a contact? (y/n): ");
            char Confirmation = Convert.ToChar(Console.ReadLine());
            while (Confirmation == 'y')
            {
                Book.Edit();
                Console.Write("\nEdit another? (y/n): ");
                Confirmation = Convert.ToChar(Console.ReadLine());
            }
            Console.Write("\nDo you want to delete a contact? (y/n): ");
            Confirmation = Convert.ToChar(Console.ReadLine());
            while (Confirmation == 'y')
            {
                Book.Delete();
                Console.Write("\nDelete another? (y/n): ");
                Confirmation = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}