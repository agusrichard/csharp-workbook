using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Person
    {
        private string name;
        private int age;
        private static int numberOfPersons;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;

            Person.numberOfPersons++;
        }

        public Person()
        {
            this.name = "";
            this.age = 0;
            Person.numberOfPersons++;
        }

        public override string ToString()
        {
            return $"My name is {this.name} and I am {this.age} years old!";

        }

        public string Name
        {
            get { return this.name; }

            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public static int NumberOfPersons
        {
            get { return Person.numberOfPersons; }
        }
    }
}
