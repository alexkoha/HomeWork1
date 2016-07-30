using System;
using System.Collections.Generic;

namespace CustomersApp
{
    public class Customer : IComparable<Customer> , IEquatable<Customer>
    {
        private string _name;
        private int _id;
        private string _address;

        public Customer(string name, int id, string address)
        {
            _name = name;
            _id = id;
            _address = address;
        }

        public int ID => _id;

        public void Display()
        {
            Console.WriteLine("Name : " + _name);
            Console.WriteLine("ID : " + _id);
            Console.WriteLine("Address : " + _address);
            Console.WriteLine();
        }

        //Implementation inconsistent with interface documentation
        public int CompareTo(Customer other)
        {
            if (other == null) return 1;//Consider throwing an exception

            return String.Compare(_name, other._name);
        }

        public bool Equals(Customer other)
        {
            if (other == null) return false;

            return (_name == other._name && _id == other._id);
        }

    }

    //Implementation inconsistent with interface documentation
    public class AnotherCustomerComparer : IComparer<Customer> 
    {
        public int Compare(Customer x, Customer y)
        {
            if (y == null && x == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            if (x.ID == y.ID) return 0;
            if (x.ID < y.ID) return -1;
            return 1;
        }
    }

    class Program
    {

        static void Main()
        {
            Customer[] arr = new Customer[3];

            arr[0] = new Customer("Alex",111111,"Haifa");
            arr[1] = new Customer("Moshe", 222222, "Karmel");
            arr[2] = new Customer("Avi", 333333, "Nesher");

            foreach (Customer obj in arr)
            {
                   obj.Display();
            }

            Console.WriteLine("\nSorted Array by Name:");
            Console.WriteLine("----------------");
            Array.Sort(arr);

            foreach (Customer obj in arr)
            {
                obj.Display();
            }

            Console.WriteLine("\nSorted Array by ID:");
            Console.WriteLine("----------------");
            Array.Sort(arr, new AnotherCustomerComparer());

            foreach (Customer obj in arr)
            {
                obj.Display();
            }

        }
    }
}
