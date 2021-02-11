using System;
using System.Collections.Generic;
using System.IO;


namespace AddressBook
{
    class ReadWrite
    {
        /// <summary>
        /// Writes the text.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="addressbook">The addressbook.</param>
        public void WriteText(string filename, List<Person> addressbook)
        {
            string path = @"G:\Repos\Address-Book-System\AddressBook\AddressBook.txt" + filename;
            using (StreamWriter sw = File.AppendText(path))
            {
                for (int a = 0; a < addressbook.Count; a++)
                {
                    Person index = addressbook[a];
                    string[] line2 = { index.firstName, index.lastName, index.city, index.state, index.zip, index.mobileNumber };
                    string line22 = string.Join(",", line2);
                    sw.WriteLine(line22);
                }
                Console.WriteLine(File.ReadAllText(path));
            }
        }

       
        /// <summary>
        /// Reads the text.
        /// </summary>
        /// <param name="Filename">The filename.</param>
        /// <returns></returns>
        public List<Person> ReadTxt(string Filename)
        {
            string path = @"G:\Repos\Address-Book-System\AddressBook\AddressBook.txt";
            List<Person> person = new List<Person>();
            using (StreamReader sr = File.OpenText(path))
            {
                string fileArray = " ";
                while ((fileArray = sr.ReadLine()) != null)
                {
                    string[] value = fileArray.Split(",");
                    person.Add(new Person(value[0], value[1], value[2], value[3], value[4], value[5]));
                }

            }
            return person;
        }

        /// <summary>
        /// Shows the files.
        /// </summary>
        public void ShowFiles()
        {
            string path = @"G:\Repos\Address-Book-System\AddressBook\AddressBook.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string fileArray = " ";
                while ((fileArray = sr.ReadLine()) != null)
                {
                    Console.WriteLine(fileArray);
                }

            }

        }
    }
}

