namespace HelloDi
{
    class PrinterWithAuth : IPrints
    {
        IPrints _printer;
        User _user;
        int _passwordGoal = 123;
        int _passwordLast;
        public PrinterWithAuth(IPrints printer, User usr)
        {
            _printer = printer;
            _user = usr;
        }

        public void Print()
        {
            if (_user.IsAuthenticated == false) // he adds new logic by composing a new class which has all the logic
            {   // this way u dont need to fuck with interface-implemented-methods, neither u need any new overloads
                // pretty cool huh
                Console.WriteLine("Access Denied!");
                return;
            }
            _printer.Print();
        }
    }
    class User
    {
        int _pass;
        public bool IsAuthenticated => _pass == 123;
        public User(int password)
        {
            _pass = password;
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