using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    class AddressBookImple : IAddressBook
    {
        public string firstName;
        public string lastName;
        public string city;
        public string state;
        public string zip;
        public string mobileNumber;
        List<Person> personList = new List<Person>();
        ReadWrite readWrite = new ReadWrite();
        Dictionary<string, List<Person>> person = new Dictionary<string, List<Person>>();
        Dictionary<string, string> stateDictionary = new Dictionary<string, string>();
        Dictionary<string, string> cityDictionary = new Dictionary<string, string>();
        List<Person> cityList = new List<Person>();
        bool i = true;
        int checkForDuplicate;


        /// <summary>
        /// Add the User in the Address Book
        /// </summary>
        public void AddPerson(string filename)
        {
            personList = readWrite.ReadCsv(filename);
            Console.WriteLine(personList.Count);
            i = true;
            while (i)
            {
                try
                {
                    Console.WriteLine("Enter Firstname");
                    firstName = Console.ReadLine();
                    if (CheckForDuplicate(firstName))
                    {
                        Console.WriteLine("Person already exists");
                        AddPerson(filename);
                    }
                    else
                    {
                        Console.WriteLine("Enter Lastname");
                        lastName = Console.ReadLine();
                        Console.WriteLine("Enter city");
                        city = Console.ReadLine();
                        Console.WriteLine("Enter state");
                        state = Console.ReadLine();
                        Console.WriteLine("Enter Zip");
                        zip = Console.ReadLine();
                        Console.WriteLine("Enter Mobile number");
                        mobileNumber = Console.ReadLine();
                        Console.WriteLine("want to add more contacts then press 1 or press other than 1");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                            AddPerson(filename);
                        else
                            i = false;
                    }
                }
                catch (System.FormatException formatException)
                {
                    throw formatException;
                }
                catch (AddressBookException)
                {
                    throw new AddressBookException("Please enter valid number");
                }
            }
            readWrite.WriteCsv(filename, personList);
        }
    
        /// <summary>
        /// Edit Contact of the Address book 
        /// </summary>
        public void EditPerson(string filename)
        {
            personList = readWrite.ReadTxt(filename);
            Console.WriteLine("Enter Edit Person details");
            String edit = Console.ReadLine();

            foreach (Person editPerson in personList)
            {
                if (edit.Equals(editPerson.firstName))
                {
                    Console.WriteLine("Enter Firstname");
                    editPerson.firstName = Console.ReadLine();
                    Console.WriteLine("Enter Lastname");
                    editPerson.lastName = Console.ReadLine();
                    Console.WriteLine("Enter city");
                    editPerson.city = Console.ReadLine();
                    Console.WriteLine("Enter state");
                    editPerson.state = Console.ReadLine();
                    Console.WriteLine("Enter Zip");
                    editPerson.zip = Console.ReadLine();
                    Console.WriteLine("Enter Mobile number");
                    editPerson.mobileNumber = Console.ReadLine();
                }
            }
            readWrite.WriteCsv(filename, personList);
            Display(filename);
           
        }
        /// <summary>
        /// Delete The Person Detail
        /// </summary>
        public void DeletePerson(string filename)
        {
            personList = readWrite.ReadCsv(filename);
            Console.WriteLine("Enter your Delete person details");
            string search = Console.ReadLine();
            int index = 0;
            Console.WriteLine("Size before deleting::" + personList.Count);
            foreach (Person delPerson in personList)
            {
                if (search.Equals(delPerson.firstName))
                {
                    index = personList.IndexOf(delPerson);
                    personList.RemoveAt(index);
                    Console.WriteLine("Size after deletion::" + personList.Count);
                    break;
                }
            }
            readWrite.WriteCsv(filename, personList);

        }
        /// <summary>
        /// Displays this list.
        /// </summary>
        public void Display(string filename)
        {
            personList = readWrite.ReadCsv(filename);
            if (personList.Count == 0)
                Console.WriteLine("No contact data to display ");
            foreach (Person person in personList)
                Console.WriteLine(person.toString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstname">The firstname.</param>
        public bool CheckForDuplicate(string firstname)
        {
            bool result = false;
            foreach (Person person in personList)
            {
                if (person.firstName.Equals(firstName))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        public void SearchPerson(string filename)
        {
            personList = readWrite.ReadTxt(filename);
            Console.WriteLine("Choose you want to search by city or state\n" + "Press 1 for city\n" + "Press 2 for state");
            try
            {
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Enter city name to search");
                        string searchCity = Console.ReadLine();
                        foreach (Person person in personList.FindAll(s => s.city.Equals(searchCity)).ToList())
                            Console.WriteLine(person.toString());
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to search");
                        string searchState = Console.ReadLine();
                        foreach (Person person in personList.FindAll(s => s.state.Equals(searchState)).ToList())
                            Console.WriteLine(person.toString());
                        break;
                }
            }
            catch (System.FormatException formatException)
            {
                throw formatException;
            }
            catch (AddressBookException)
            {
                throw new AddressBookException("Please enter valid number");
            }
        }
        /// <summary>
        /// view the persons in addressbook by using city or state
        /// </summary>
        public void ViewAddressBook()
        {
            Console.WriteLine("Choose how you want to view by city or state\n" + "Press 1 for city\n" + "Press 2 for state");
            try
            {
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Enter city name to view person");
                        string viewCity = Console.ReadLine();
                        var searchCity = cityDictionary.Where(x => x.Value.Equals(viewCity));
                        foreach (var result in searchCity)
                            Console.WriteLine("Firstname:{0} , City:{1}", result.Key, result.Value);
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to view person");
                        string viewState = Console.ReadLine();
                        var searchState = stateDictionary.Where(x => x.Value.Equals(viewState));
                        foreach (var result in searchState)
                            Console.WriteLine("Firstname:{0} , State:{1}", result.Key, result.Value);
                        break;
                }
            }
            catch (System.FormatException formatException)
            {
                throw formatException;
            }
            catch (AddressBookException)
            {
                throw new AddressBookException("Please enter valid number");
            }
        }
        public void CountPerson(string filename)
        {
            personList = readWrite.ReadTxt(filename);
            Console.WriteLine("Choose how you want to count by city or state\n" + "Press 1 for city\n" + "Press 2 for state");
            try
            {
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Enter city name to search");
                        string countCity = Console.ReadLine();
                        int countByCity = personList.FindAll(s => s.city.Equals(countCity)).Count;
                        Console.WriteLine("No of persons present in addressbook for " + countCity + " is::" + countByCity);
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to search");
                        string countState = Console.ReadLine();
                        int countByState = personList.FindAll(s => s.state.Equals(countState)).Count;
                        Console.WriteLine("No of persons present in addressbook for " + countState + " is::" + countByState);
                        break;
                }
            }
            catch (System.FormatException formatException)
            {
                throw formatException;
            }
            catch (AddressBookException)
            {
                throw new AddressBookException("Please enter valid number");
            }
        }
        /// <summary>
        /// Sorts the first name of the by.
        /// </summary>
        public void SortByFirstName(string filename)
        {

            personList = readWrite.ReadTxt(filename);
            var result = personList.OrderBy(x => x.firstName);
            foreach (var sortPerson in result)
            {
                Console.WriteLine(sortPerson.toString());
            }
        }
        /// <summary>
        /// Sorts the by others.
        /// </summary>
        public void SortByOthers(string filename)
        {
            personList = readWrite.ReadTxt(filename);
            Console.WriteLine("Choose how you want to sort");
            Console.WriteLine("1)SortByCity\n" + "2)SortByState\n" + "3)SortByZip");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    var result = personList.OrderBy(x => x.city);
                    foreach (var sortByCity in result)
                        Console.WriteLine(sortByCity.toString());
                    break;
                case 2:
                    var stateResult = personList.OrderBy(x => x.state);
                    foreach (var sortByState in stateResult)
                        Console.WriteLine(sortByState.toString());
                    break;
                case 3:
                    var zipResult = personList.OrderBy(x => x.zip);
                    foreach (var sortByZip in zipResult)
                        Console.WriteLine(sortByZip.toString());
                    break;
                default:
                    Console.WriteLine("Please enter correct option");
                    break;
            }
        }
    }
}


