using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerUDP
{
    static class Server
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8081;

            // Создание енд поинта подключения к локальному компьютеру
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            // Сокет - соединение, через которое будут приходить данные
            // AddressFamily.InterNetwork - IP адрес 4 версии
            // SocketType.Dgram - потоковая передача данных для UDP
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // Bind - связывание сокета с ендпоинтом
            // Переводим сокет в режим ожидания, где он должен слушать
            udpSocket.Bind(udpEndPoint);

            while (true)
            {
                // Буфер. Место куда принимаются данные (сообщения)
                // Максимум сообщение из 256 байт
                var buffer = new byte[256];
                // Собирает полученные данные из массива байт
                var data = new StringBuilder();

                // Адрес подключения клиента
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
                do
                {
                    udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                } while (udpSocket.Available > 0);

                Console.WriteLine(data);

                udpSocket.SendTo(Encoding.UTF8.GetBytes("Success"), senderEndPoint);
            }
        }
    }
}

