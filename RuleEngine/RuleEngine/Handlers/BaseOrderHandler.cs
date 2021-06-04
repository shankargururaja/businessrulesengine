using RuleEngine.Entity;
using RuleEngine.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Handlers
{
    /// <summary>
    /// Base class for Order Handler
    /// </summary>
    public class BaseOrderHandler : IOrderHandler
    {
        protected IOrderHandler _nextOrderHandler;

        public virtual void Process(Request request)
        {
            _nextOrderHandler = null;
        }

        public void SetNextHandler(IOrderHandler handler)
        {
            _nextOrderHandler = handler;
        }
    }
}
