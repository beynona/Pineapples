using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientTCP
{
    static class Server
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            // Создание енд поинта подключения к локальному компьютеру
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            // Сокет - соединение, через которое будут приходить данные
            // AddressFamily.InterNetwork - IP адрес 4 версии
            // SocketType.Stream - потоковая передача данных для TCP
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Введите сообщение: ");
            var message = Console.ReadLine();

            var data = Encoding.UTF8.GetBytes(message ?? "empty message");
            
            // Подключение сокета к ендпоинту
            tcpSocket.Connect(tcpEndPoint);

            // Отправка сообщения на сервер
            tcpSocket.Send(data);
            
            // Буфер. Место куда принимаются данные (сообщения)
            // Максимум сообщение из 256 байт
            var buffer = new byte[256];
            // Реальный объём байт полученного сообщения (если сообщение короче)
            // Собирает полученные данные из массива байт
            var answer = new StringBuilder();
            
            do
            {
                // Receive - возвращает полученное значение байт
                var size = tcpSocket.Receive(buffer);
                    
                // Раскодируем полученные данные
                var encodingData = Encoding.UTF8.GetString(buffer, 0, size);
                // Дописываем полученные данные
                answer.Append(encodingData);
            } 
            while (tcpSocket.Available > 0); // Считывание до тех пор, пока есть данные
            
            Console.WriteLine($"Ответ: {answer}");
            
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadLine();
        }
    }
}

