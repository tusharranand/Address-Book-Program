using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AddressBook
{
    public class ExternalOperations
    {
        public string FileName;
        public string Path;
        public Dictionary<string, string[]> Book;
        public ExternalOperations(string FileName, Dictionary<string, string[]> Book)
        {
            this.FileName = FileName;
            this.Book = Book;
            Path = @"E:\c#\Address-Book-Program\AddressBook\";
        }
        public bool FileExists(string FilePath)
        {
            if (!File.Exists(FilePath))
                return false;
            return true;
        }
        public void TxtHandler()
        {
            int Option = 0;
            do
            {
                string FilePath = Path + FileName + ".txt";
                Console.WriteLine("\n1 to Write to a .txt file for {0} Address Book", FileName);
                Console.WriteLine("2 to Read from a .txt file of {0} Address Book", FileName);
                Console.WriteLine("3 to Delete the .txt file for {0} Address Book", FileName);
                Console.WriteLine("0 to EXIT");
                Console.Write("Choose an action: ");
                Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        WriteTxt(FilePath);
                        break;
                    case 2:
                        ReadTxt(FilePath);
                        break;
                    case 3:
                        DeleteTxt(FilePath);
                        break;
                    default:
                        break;
                }
            } while (Option != 0);

        }
        public string Output(string[] array)
        {
            string output = "\nThe details for " + array[0] + " " + array[1] + " are:\nAddress: " + 
                array[2] + "\nCity: " + array[3] + "\nState: " + array[4] + "\nZip Code: " + array[5] 
                + "\nPhone Number: " + array[6] + "\nEmail: " + array[7] + "\n";
            return output;
        }
        public void WriteTxt(string FilePath)
        {
            if (FileExists(FilePath))
                DeleteTxt(FilePath);

            StreamWriter sw = new(FilePath);
            foreach (string[] array in Book.Values)
                sw.WriteLine(Output(array));
            sw.Close();
        }
        public void ReadTxt(string FilePath)
        {
            if (!FileExists(FilePath))
            {
                Console.WriteLine("This file does not exist.");
                return;
            }

            StreamReader sr = new(FilePath);
            string line = "";
            while ((line = sr.ReadLine()) != null)
                Console.WriteLine(line);
            sr.Close();
        }
        public void DeleteTxt(string FilePath)
        {
            if (FileExists(FilePath))
            {
                File.Delete(FilePath);
                return;
            }
            Console.WriteLine("No such file exist already.");
        }
    }
}
