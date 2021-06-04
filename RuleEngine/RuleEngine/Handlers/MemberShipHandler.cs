using RuleEngine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Handlers
{
    class MemberShipHandler : BaseOrderHandler
    {
        public override void Process(Request request)
        {
            if (request != null && request.Data is IMemberShip membership)
            {
                switch (membership.MembershipType)
                {
                    case MembershipType.New:
                        Console.WriteLine("activate that membership.");
                        break;
                    case MembershipType.Upgrade:
                        Console.WriteLine("apply theupgrade.");
                        break;
                    default:
                        break;
                }

                Console.WriteLine("e-mail the owner and inform them of the activation/upgrade.");
            }
            if (_nextOrderHandler != null)
            {
                _nextOrderHandler.Process(request);
            }
        }
    }
}
