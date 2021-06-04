using RuleEngine.Entity;
using RuleEngine.Handlers;
using System;

namespace RuleEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create Order Processing Handler Pipeline
            var bookOrderHandler = new BookOrderHandler();
            var memberShipHandler = new MemberShipHandler();
            var phyiscalProductHandler = new PhysicalProductHandler();
            var videoHandler = new VideoOrderHandler();

            //Chain Handlers
            bookOrderHandler.SetNextHandler(memberShipHandler);
            memberShipHandler.SetNextHandler(phyiscalProductHandler);
            phyiscalProductHandler.SetNextHandler(videoHandler);

            //Create an Order
            var order = new Book("BookName", PurchaseMode.Physical);
            var request = new Request() { Data = order };
            
            //Process Order
            bookOrderHandler.Process(request);

            //Process Action Items
            foreach (var action in request.Actions)
            {
                switch (action)
                {
                    case Actions.CREATE_DUPLI_PACK_SLIP_FOR_ROYALTY_DEPARTMENT:
                        Console.WriteLine("create a duplicate packing slip for the royalty department");
                        break;
                    case Actions.GEN_COMMISSION_PAYMENT_FOR_AGENT:
                        Console.WriteLine("generate a commission payment to the agent.");

                        break;
                    case Actions.GEN_PACKING_SLIP_FOR_SHIPPING:
                        Console.WriteLine("generate a packing slip for shipping.");

                        break;
                    case Actions.ACTIVATE_MEMBERSHIP:
                        Console.WriteLine("activate membership.");

                        break;
                    case Actions.UPGRADE_MEMBERSHIP:
                        Console.WriteLine("apply theupgrade to Membership.");

                        break;
                    case Actions.EMAIL_OWNER_ABT_ACTIVATION:
                        Console.WriteLine("e-mail the owner and inform them of the activation/upgrade.");

                        break;
                    case Actions.ADD_FIRST_AID_VIDEO_TO_PACKING_SLIP:
                        Console.WriteLine("add a free “First Aid” video to the packing slip");

                        break;
                    default:
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
