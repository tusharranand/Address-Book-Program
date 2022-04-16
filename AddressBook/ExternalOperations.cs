using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace AddressBook
{
    public class ExternalOperations
    {
        public string FileName;
        public string Path;
        public Dictionary<string, string[]> Book;
        Contacts record;

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
        public void DeleteFile(string FilePath)
        {
            if (FileExists(FilePath))
            {
                File.Delete(FilePath);
                return;
            }
            Console.WriteLine("No such file exist already.");
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
                        DeleteFile(FilePath);
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
                DeleteFile(FilePath);

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
        public void CSVHandler()
        {
            int Option = 0;
            do
            {
                string FilePath = Path + FileName + ".csv";
                Console.WriteLine("\n1 to Write to a .csv file for {0} Address Book", FileName);
                Console.WriteLine("2 to Read from a .csv file of {0} Address Book", FileName);
                Console.WriteLine("3 to Delete the .csv file for {0} Address Book", FileName);
                Console.WriteLine("0 to EXIT");
                Console.Write("Choose an action: ");
                Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        WriteCSV(FilePath);
                        break;
                    case 2:
                        ReadCSV(FilePath);
                        break;
                    case 3:
                        DeleteFile(FilePath);
                        break;
                    default:
                        break;
                }
            } while (Option != 0);
        }
        public void WriteCSV(string FilePath)
        {
            DeleteFile(FilePath);

            StreamWriter sw = new(FilePath);
            foreach (string[] array in Book.Values)
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", 
                        array[0], array[1], 
                        array[2], array[3], 
                        array[4], array[5], 
                        array[6], array[7]);
                }
            sw.Close();
        }
        public void ReadCSV(string FilePath)
        {
            if (!FileExists(FilePath))
            {
                Console.WriteLine("This file does not exist.");
                return;
            }

            StreamReader sr = new(FilePath);
            string[] data = new string[8];
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                data = line.Split(',');
                record = new Contacts(
                    data[0], data[1], 
                    data[2], data[3], 
                    data[4], data[5], 
                    data[6], data[7]);
            }
            sr.Close();
        }
        public void JSONHandler()
        {
            int Option = 0;
            do
            {
                string FilePath = Path + FileName + ".json";
                Console.WriteLine("\n1 to Write to a .json file for {0} Address Book", FileName);
                Console.WriteLine("2 to Read from a .json file of {0} Address Book", FileName);
                Console.WriteLine("3 to Delete the .json file for {0} Address Book", FileName);
                Console.WriteLine("0 to EXIT");
                Console.Write("Choose an action: ");
                Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        WriteJSON(FilePath);
                        break;
                    case 2:
                        ReadJSON(FilePath);
                        break;
                    case 3:
                        DeleteFile(FilePath);
                        break;
                    default:
                        break;
                }
            } while (Option != 0);
        }
        public void WriteJSON(string FilePath)
        {
            DeleteFile(FilePath);

            StreamWriter sw = new(FilePath);
            sw.Flush();
            foreach (string[] array in Book.Values)
            {
                string jsonData = JsonConvert.SerializeObject(array);
                sw.WriteLine(jsonData);
                Console.WriteLine(jsonData);
            }
            sw.Close();
        }
        public void ReadJSON(string FilePath)
        {
            if (!FileExists(FilePath))
            {
                Console.WriteLine("This file does not exist.");
                return;
            }

            StreamReader sr = new(FilePath);
            string[] data = new string[8];
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                data = JsonConvert.DeserializeObject<string[]>(line);
                record = new Contacts(
                    data[0], data[1],
                    data[2], data[3],
                    data[4], data[5],
                    data[6], data[7]);
            }
            sr.Close();
        }
    }
}