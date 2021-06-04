using RuleEngine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Handlers
{
   public class BookOrderHandler : BaseOrderHandler
    {
        public override void Process(Request request)
        {
            if (request != null && request.Data is IOrder order)
            {
                if (order.Category == Category.Book)
                {
                    request.Actions?.Add(Actions.CREATE_DUPLI_PACK_SLIP_FOR_ROYALTY_DEPARTMENT);
                    request.Actions?.Add(Actions.GEN_COMMISSION_PAYMENT_FOR_AGENT);
                }
            }
            if (_nextOrderHandler != null)
            {
                _nextOrderHandler.Process(request);
            }
        }
    }
}
