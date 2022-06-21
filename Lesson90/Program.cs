using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson90
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public Human (string lastName, string firstName)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
        }

        public Human(string firstName, string lastName, byte age) : this(firstName, lastName)
        {
            this.Age = age;
        }

        public void MyName()
        {
            Console.WriteLine("My name is " + LastName + " " + FirstName);
        }
        public void MyAge()
        {
            string message;
            message = (Age != 0) ? "I am " + Age + " years old" : "Age is not defined";
            Console.WriteLine(message);
        }
        public void WhoIAm ()
        {
            Console.WriteLine($"Hallo! My full name is {LastName} {FirstName}, my age is {Age} \n");
        }
    }
    public class Student : Human
    {
        public string Faculty { get; set; }
        public Student(string lastName, string firstName) : base(lastName, firstName)
        {
        }
        public Student(string firstName, string lastName, byte age) : base(lastName, firstName, age)
        {
        }
        public Student(string firstName, string lastName, byte age, string faculty) : this(lastName, firstName, age)
        {
            this.Faculty = (String.IsNullOrEmpty(faculty) ? "NA" : faculty);
        }
        public void AmLearning()
        {
            Console.WriteLine("I am studying at the faculty " + (Faculty ?? "NA"));
            Console.WriteLine();
        }
        public new void WhoIAm()
        {
            base.WhoIAm();
            //Console.WriteLine($"Hallo! My full name is {LastName} {FirstName}, my age is {Age}");
            string _message;
            if ((Faculty != null) && (Faculty != "NA"))
            {
                _message = "I am studying at the faculty " + Faculty;
            } else
            {
                _message = "I am an abiturient";
            }
            Console.WriteLine(_message + "\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student person1 = new Student ("Tolmachev", "Vitaliy", 22, "");
            person1.WhoIAm();

            Human person2 = new Human("Sivakov", "Vladimir", 26);
            person2.WhoIAm();

            Student person3 = new Student("Tsykunov", "Evgeniy", 20, "Software development");
            person3.WhoIAm();
            //person3.AmLearning();

            Student person4 = new Student("Tarasov", "Sergey", 21);
            person4.WhoIAm();
            //person4.AmLearning();

            Console.ReadLine();
        }
    }
}
