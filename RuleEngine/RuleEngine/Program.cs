using System;

namespace RuleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookOrderHandler = new BookOrderHandler();
            var memberShipHandler = new MemberShipHandler();
            var phyiscalProductHandler = new PhysicalProductHandler();
            var videoHandler = new VideoOrderHandler();

            bookOrderHandler.SetNextHandler(memberShipHandler);
            memberShipHandler.SetNextHandler(phyiscalProductHandler);
            phyiscalProductHandler.SetNextHandler(videoHandler);

            var order = new Book("BookName", PurchaseMode.Physical);

            bookOrderHandler.Process(new Request() { Data = order });

            Console.ReadLine();
        }
    }
}
