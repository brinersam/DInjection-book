namespace HelloDi
{
    public class Main : IRunnable
    {
        public void Run()
        {
            IMessage msg = new Message("Hello world");
            string printerName = File.ReadLines("./01_HelloDi/BootFromText.txt").FirstOrDefault();
            
            IPrints printer = (IPrints)Activator.CreateInstance
                                            (Type.GetType(printerName),msg);
            printer.Print();

            printer = new PrinterWithAuth(printer); // Open closed expansion
            if (printer is PrinterWithAuth)
                (printer as PrinterWithAuth).EnterPassword(3);

            printer.Print();
        }
    }
}