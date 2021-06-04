using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    interface IOrderHandler
    {
        void SetNextHandler(IOrderHandler handler);
        void Process(Request request);
    }
}
