using System;

namespace AddressBook
{
    class Program
    {
        /// <summary>
        /// This is Our Main Class 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to addressBook ");
            AddressBookImple addressBook = new AddressBookImple();
            addressBook.AddPerson();
            addressBook.EditPerson();
            Console.ReadKey();

        }
    }
}
