using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Sherlock Holmes", 25);
            Console.WriteLine(person1.ToString());
            Person person2 = new Person("John Watson", 21);
            Console.WriteLine(person2.ToString());
            Person person3 = new Person("Irene Adler", 20);
            Console.WriteLine(person3.ToString());
            Console.WriteLine(Person.NumberOfPersons);
            Console.WriteLine(Util.Add(10, 11));
        }
    }
}
