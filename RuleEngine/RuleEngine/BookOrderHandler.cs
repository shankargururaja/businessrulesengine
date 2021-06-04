using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    class BookOrderHandler : BaseOrderHandler
    {
        public override void Process(Request request)
        {
            if (request != null && request.Data is IOrder order)
            {
                if (order.Category == Category.Book)
                {
                    Console.WriteLine("create a duplicate packing slip for the royalty department.");
                    Console.WriteLine("generate a commission payment to the agent.");
                }
            }
            if (_nextOrderHandler != null)
            {
                _nextOrderHandler.Process(request);
            }
        }
    }
}
