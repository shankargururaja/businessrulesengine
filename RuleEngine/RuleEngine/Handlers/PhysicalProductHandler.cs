using RuleEngine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Handlers
{
    class PhysicalProductHandler : BaseOrderHandler
    {
        public override void Process(Request request)
        {
            if (request != null && request.Data is IOrder order)
            {
                if (order.PurchaseMode == PurchaseMode.Physical)
                {
                    request.Actions?.Add(Actions.GEN_PACKING_SLIP_FOR_SHIPPING);
                    request.Actions?.Add(Actions.GEN_COMMISSION_PAYMENT_FOR_AGENT);
                }
            }
            if (_nextOrderHandler != null) {
                _nextOrderHandler.Process(request);
            }
        }
    }
}
