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
            while (true)
            {
                Console.WriteLine("1)Add Person in AddressBook\n" + "2)Edit Person in Address\n" + "3)Delete Person in AddressBook");
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBook.AddPerson();
                        break;
                    case 2:
                        addressBook.EditPerson();
                        break;
                    case 3:
                        addressBook.DeletePerson();
                        break;
                    default:
                        Console.Write("Please Enter correct option");
                        break;
                }
                Console.WriteLine("Do you want to continue(Y / N) ? ");
                var variable = Console.ReadLine();
                if (variable.Equals("Y"))
                {
                    continue;
                }
                else
                {
                    break;
                }

            }
            Console.ReadKey(); ;

        }
    }
}
