namespace Pineapple_Educate;

// Интерфейсы.
// Интерфейсы позволяют определить некий функционал свойств и методов, которые не имеют конкретной реализации
// Классы реализуют интерфейсы
// Название интерфейсов начинаются с I
public class TheoryInterface
{
    // Пример:
    interface IAccount
    {
        int CurrentSum { get; } // Свойство без реализации
        void Put(int sum); // Методы без реализации
        void Withdraw(int sum);
    }
    interface IClient
    {
        string Name { get; set; }
    }
    // Реализация свойств и методов из интерфейсов в классе
    class Client : IAccount, IClient
    {
        private int _sum;
        public string Name { get; set; }
        public int CurrentSum { get => _sum; }

        public Client(string name, int sum)
        {
            Name = name;
            _sum = sum;
        }

        public void Put(int sum)
        {
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            _sum -= sum;
        }
    }
    
}