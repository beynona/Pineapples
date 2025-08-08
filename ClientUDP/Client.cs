using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientUDP;

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
            Console.WriteLine("Message: ");
            var message = Console.ReadLine();
            var buffer = new byte[256];
            var data = new StringBuilder();

            // Адрес подключения клиента
            EndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), 8081);

            udpSocket.SendTo(Encoding.UTF8.GetBytes(message ?? "Empty message"), serverEndPoint);

            do
            {
                udpSocket.ReceiveFrom(buffer, ref serverEndPoint);
                data.Append(Encoding.UTF8.GetString(buffer));
            } while (udpSocket.Available > 0);

            Console.WriteLine(data);
        }
    }
}