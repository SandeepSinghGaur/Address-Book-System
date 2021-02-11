using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;

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
            string path = @"G:\Repos\Address-Book-System\AddressBook\AddressBook.txtAddressBook";
            using (StreamReader sr = File.OpenText(path))
            {
                string fileArray = " ";
                while ((fileArray = sr.ReadLine()) != null)
                {
                    Console.WriteLine(fileArray);
                }

            }

        }
        /// <summary>
        /// Writes the CSV.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="list">The list.</param>
        public void WriteCsv(string filename, List<Person> list)
        {
            string path = @"G:\Repos\Address-Book-System\AddressBook\EmptyAddress.csv" + filename;
            using (var writer = new StreamWriter(path))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteHeader<Person>();
                csvWriter.NextRecord();
                csvWriter.WriteRecords(list);
                writer.Flush();
                writer.Close();
            }

        }

        /// <summary>
        /// Reads the CSV.
        /// </summary>
        /// <param name="Filename">The filename.</param>
        /// <returns></returns>
        public List<Person> ReadCsv(string Filename)
        {
            List<Person> person = new List<Person>();
            string path = @"G:\Repos\Address-Book-System\AddressBook\AddressBook.txtAddress.csv";
            using (var reader=new StreamReader(path))
                using(var csv=new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                person = csv.GetRecords<Person>().ToList();
            }
            return person;
        }
        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="person">The person.</param>
        public void WriteJson(string filename, List<Person> person)
        {
            string path = @"G:\Repos\Address-Book-System\AddressBook\jsconAddress.json" + filename;
            string json = JsonConvert.SerializeObject(person.ToArray());
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Reads from json.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public List<Person> ReadFromJson(string filename)
        {
            string path = @"G:\Repos\Address-Book-System\AddressBook\jsconAddress.json" + filename;
            string jsonFile = File.ReadAllText(path);
            List<Person> person = JsonConvert.DeserializeObject<List<Person>>(jsonFile);
            return person;
        }
    }
}

