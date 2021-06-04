using RuleEngine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Handlers
{
    class VideoOrderHandler : BaseOrderHandler
    {
        public override void Process(Request request)
        {
            if (request != null && request.Data is IOrder order)
            {
                if (order.Category == Category.Video && order.Title == "Learning to Ski")
                {
                    Console.WriteLine("add a free “First Aid” video to the packing slip");
                }

            }
            if (_nextOrderHandler != null)
            {
                _nextOrderHandler.Process(request);
            }
        }
    }
}
