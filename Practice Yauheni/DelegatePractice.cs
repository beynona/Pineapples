namespace Yauheni
{
    public delegate void AccountMessageHandler(string message);
    public class DelegatePractice
    {
        // За реализацию вывода отвечает внешний код
        private AccountMessageHandler? _messageHandler;

        public void RegisterMessageHandler(AccountMessageHandler handler)
        {
            _messageHandler = handler;
        }

        public void PrintMessage()
        {
            if (_messageHandler != null)
            {
                _messageHandler("Hello delegate");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

    }
}