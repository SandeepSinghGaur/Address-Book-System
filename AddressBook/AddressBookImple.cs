using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBookImple:IAddressBook
    {
        public string firstName;
        public string lastName;
        public string city;
        public string state;
        public string zip;
        public string mobileNumber;
        List<Person> personList = new List<Person>();


        /// <summary>
        /// Add the User in the Address Book
        /// </summary>
        public void AddPerson()
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
            personList.Add(new Person(firstName, lastName, city, state, zip, mobileNumber));
            foreach (Person addPerson in personList)
                Console.WriteLine(addPerson.toString());

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
            foreach (Person addPerson in personList)
                Console.WriteLine(addPerson.toString());
        }

    }
}
