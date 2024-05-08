namespace HelloDi
{
    class PrinterWithAuth : IPrints
    {
        IPrints _printer;
        int _passwordGoal = 123;
        int _passwordLast;
        public PrinterWithAuth(IPrints printer)
        {
            _printer = printer;
        }

        public void EnterPassword(int pass)
        {
            _passwordLast = pass;
        }

        public void Print()
        {
            if (_passwordLast != _passwordGoal)
            {

                Console.WriteLine("Access Denied!");
                return;
            }
            _printer.Print();
        }
    }
    class Printer : IPrints
    {
        IMessage _message;
        public Printer(IMessage message)
        {
            _message = message;
        }

        public void Print()
        {
            Console.WriteLine(_message.GetMessage());
        }
    }

    class Message : IMessage
    {
        string _text;
        public Message(string text)
        {
            _text = text;
        }

        public string GetMessage()
        {
            return _text;
        }
    }
    
}