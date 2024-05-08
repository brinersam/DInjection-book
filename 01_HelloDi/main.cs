namespace HelloDi
{
    public class Main : IRunnable
    {
        public void Run() //shut the fuck up roslyn
        {
            IMessage msg = new Message("Hello world");
            string printerName = File.ReadLines("./01_HelloDi/BootFromText.txt").FirstOrDefault();
            
            IPrints printer = (IPrints)Activator.CreateInstance // late binding
                                            (Type.GetType(printerName),msg);
            printer.Print();

            printer = new PrinterWithAuth(printer, new User(2)); // Open closed expansion
            printer.Print();
        }
    }
}