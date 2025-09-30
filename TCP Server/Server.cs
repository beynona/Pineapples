using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerTcp
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

            // Bind - связывание сокета с ендпоинтом
            // Переводим сокет в режим ожидания, где он должен слушать
            tcpSocket.Bind(tcpEndPoint);

            // Запустить сокет на прослушивание
            // backlog - сколько клиентов может подключиться
            tcpSocket.Listen(4);

            // Процесс прослушивания
            while (true)
            {
                // Обработчик на приём сообщений
                // Обрабатывание конкретного клиента, под каждого клиента создаётся и потом уничтожается
                var listener = tcpSocket.Accept();

                // Буфер. Место куда принимаются данные (сообщения)
                // Максимум сообщение из 256 байт
                var buffer = new byte[256];
                
                // Собирает полученные данные из массива байт
                var data = new StringBuilder();
                    
                do
                {
                    // Receive - возвращает полученное значение байт
                   var size = listener.Receive(buffer);
                    
                    // Раскодируем полученные данные
                    var encodingData = Encoding.UTF8.GetString(buffer, 0, size);
                    // Дописываем полученные данные
                    data.Append(encodingData);
                } 
                while (listener.Available > 0); // Считывание до тех пор, пока есть данные
                
                Console.WriteLine($"Сообщение от клиента {data}");
                
                // Ответ клиенту
                listener.Send("Успешные ответ клиенту"u8.ToArray());
                
                // Отключить соединение listener у клиента и сервера
                listener.Shutdown(SocketShutdown.Both);
                // Закрыть соединение listener
                listener.Close();
            }
        }
    }
}

