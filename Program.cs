using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        // This is the main program
        static void Main(string[] args)
        {
            //it lists the students
            List<Student> list = new List<Student>();
            list.Add(new Student("Ela", "Alihodzic", "elaalihodzic@hotmail.com", "Sarajevo"));
            list.Add(new Student("Benjamin", "Kukuljac", "benjaminkukuljac@hotmail.com", "Tuzla"));
            list.Add(new Student("Semir", "Masic", "semirmasic@hotmail.com", "Zenica"));
            list.Add(new Student("Amir", "Kukuljac", "amirkukuljac@hotmail.com", "Mostar"));
            list.Sort();
            foreach (Student s in list)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }

    class Person
    {
        //on next lines the strings are represented
        protected string name;
        private string LastName;
        public static int count = 0;
        public string lastName
        {
            get { return LastName; }
            set
            {
                //on next lines it checks what is the lenght  
                if (value.Length < 2) throw new Exception("Last name has to be more than two characters long");
                foreach (Char c in value)
                {
                    //on next lines it checks if last name has only letters
                    if (!Char.IsLetter(c))
                    {
                        //on next line it throws exception if condition above is not satisfied
                        throw new Exception("Last name can contain letters only");
                    }
                }
                LastName = value;
            }
        }
        
        protected Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            count++;
        }

        public Person()
        {
            count++;
        }

        public string getPersonInfo() { return name + ", " + lastName; }

    };


    class Student : Person, IComparable
    {
        ~Student() //this is the empty destructor
        {

        }

        public string email { get; set; } //it Adds automatic property for email

        private string _location; //it Adds the property Location 

        public string Location
        {
            set
            {
                if (value == "SA" || value == "Sarajevo" || value == "SARAJEVO") this._location = "SA";
                else
                    if (value.ToLower() == "tuzla") this._location = "TZ";
                    else
                        this._location = "NA";
            }
            get
            {
                if (this._location == "SA") return "Sarajevo";
                if (this._location == "TZ") return "Tuzla";
                return "Other";
            }
        }

        public Student(string name, string lastName, string email)
            : base(name, lastName){//this is the parent class constructor, it takes 3 string arguments
            this.email = email;
        }

        public Student(string name, string lastName, string email, string location)
            : base(name,lastName){//in this line it takes 4 string arguments
            this.Location = location;
            this.email = email;
        }
        public bool setName(string input)
        {
            //it checks what is the name length, it can not be  more than 2 characters
            if (input.Length < 2)
            {
                Console.WriteLine("Name must be at least two characters long");
                return false;
            }
            if (input.All(Char.IsLetter))
            {
                //it checks if name contains only letters
                Console.WriteLine("Name can only have letters");
                return false;
            }
            if (Char.IsLower(input[0]))
            {
                //it checks if name starts with uppercase letter
                Console.WriteLine("Name must start with an uppercase letter");
                return false;
            }
            this.name = input;
            return true;
        }

        public Student() : base() // Parameter-less constructor for Student
        {

        }

        public string getStudentInfo() //getStudentInfo returns name, lastname, email and location
        {
            return getPersonInfo()+", "+email+", "+Location;
        }

        public int CompareTo(object other)
        {
            //Using CompareTo to sort Students by name
            return name.CompareTo(((Student)other).name);
        }

        public string ToString()
        {
            return getStudentInfo();
        }
    }
}
