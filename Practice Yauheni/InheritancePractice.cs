namespace Yauheni;

public class InheritancePractice
{
    // Наследование
    
    public class Person
    {
        private string _firstName;
        private string _lastName;

        protected Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public Person()
        {
            
        }

        public string Name
        {
            get => _firstName;
            set => _firstName = value;
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Hi {_firstName} {_lastName}");
        }
    }
    // Поддерживается одиночное наследование
    public class Employee : Person
    {
        private string _company;

        public Employee(string name, string surname, string company) : base(name, surname)
        {
            _company = company;
        }

        public Employee()
        {
            
        }

        public string Company
        {
            get => _company;
            set => _company = value;
        }

        public override void Display()
        {
            Console.WriteLine($"Hi {Name} {LastName} in {Company}");
        }
    }
}