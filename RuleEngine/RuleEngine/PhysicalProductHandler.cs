using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    class PhysicalProductHandler : BaseOrderHandler
    {
        public override void Process(Request request)
        {
            if (request != null && request.Data is IOrder order)
            {
                if (order.PurchaseMode == PurchaseMode.Physical)
                {
                    Console.WriteLine("generate a packing slip for shipping.");
                    Console.WriteLine("generate a commission payment to the agent.");
                }
            }
            if (_nextOrderHandler != null) {
                _nextOrderHandler.Process(request);
            }
        }
    }
}
