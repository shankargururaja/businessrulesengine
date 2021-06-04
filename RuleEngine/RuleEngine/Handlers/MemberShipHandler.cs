using RuleEngine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Handlers
{
   public class MemberShipHandler : BaseOrderHandler
    {
        public override void Process(Request request)
        {
            if (request != null && request.Data is IMemberShip membership)
            {
                switch (membership.MembershipType)
                {
                    case MembershipType.New:
                        request.Actions?.Add(Actions.ACTIVATE_MEMBERSHIP);
                        break;
                    case MembershipType.Upgrade:
                        request.Actions?.Add(Actions.UPGRADE_MEMBERSHIP);
                        break;
                    default:
                        break;
                }
                request.Actions?.Add(Actions.EMAIL_OWNER_ABT_ACTIVATION);
            }
            if (_nextOrderHandler != null)
            {
                _nextOrderHandler.Process(request);
            }
        }
    }
}
