using RuleEngine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Handlers
{
   public class VideoOrderHandler : BaseOrderHandler
    {
        public override void Process(Request request)
        {
            if (request != null && request.Data is IOrder order)
            {
                if (order.Category == Category.Video && order.Title == "Learning to Ski")
                {
                    request.Actions?.Add(Actions.ADD_FIRST_AID_VIDEO_TO_PACKING_SLIP);
                }

            }
            if (_nextOrderHandler != null)
            {
                _nextOrderHandler.Process(request);
            }
        }
    }
}
