using RuleEngine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Interface
{
    public interface IOrderHandler
    {
        void SetNextHandler(IOrderHandler handler);
        void Process(Request request);
    }
}
