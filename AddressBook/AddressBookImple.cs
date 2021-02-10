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
        Dictionary<string, List<Person>> person = new Dictionary<string, List<Person>>();
        Dictionary<string, string> stateDictionary = new Dictionary<string, string>();
        Dictionary<string, string> cityDictionary = new Dictionary<string, string>();
        bool i = true;
        int checkForDuplicate = 0;


        /// <summary>
        /// Add the User in the Address Book
        /// </summary>
        public void AddPerson()
        {
            i = true;
            while (i)
            {
                try
                {

                    Console.WriteLine("Enter Firstname");
                    firstName = Console.ReadLine();
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
                    CheckForDuplicate(firstName);
                    Console.WriteLine("want to add more contacts then press 1 or press other than 1");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                        AddPerson();
                    else
                        i = false;

                }
                catch (System.FormatException)
                {

                    throw new AddressBookException("Please enter valid number");
                }

            }


        
    }
        /// <summary>
        /// Edit Contact of the Address book 
        /// </summary>
        public void EditPerson()
        {
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
            Display();
        }
        /// <summary>
        /// Delete The Person Detail
        /// </summary>
        public void DeletePerson() 
        {
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

        }
        /// <summary>
        /// Displays this list.
        /// </summary>
        public void Display()
        {
            foreach (Person person in personList)
                Console.WriteLine(person.toString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstname">The firstname.</param>
        public void CheckForDuplicate(string firstname)
        {
            if (person.ContainsKey(firstname))
            {

                Console.WriteLine("Contact already exists");
                checkForDuplicate = 1;
                AddPerson();
            }

        }
        public void SearchPerson()
        {
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
                        {
                            Console.WriteLine(person.toString());
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to search");
                        string searchState = Console.ReadLine();
                        foreach (Person person in personList.FindAll(s => s.state.Equals(searchState)).ToList())
                        {
                            Console.WriteLine(person.toString());
                        }
                        break;
                }
            }
            catch (System.FormatException)
            {
                throw new AddressBookException("Please enter correct input");
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
            catch (System.FormatException)
            {
                throw new AddressBookException("Please enter correct input");
            }
        }
    }
}
