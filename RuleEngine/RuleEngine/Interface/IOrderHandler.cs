using RuleEngine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Interface
{
    /// <summary>
    /// Order Handler Interface
    /// </summary>
    public interface IOrderHandler
    {
        /// <summary>
        /// Chain next handler to pass the request processing
        /// </summary>
        /// <param name="handler"></param>
        void SetNextHandler(IOrderHandler handler);
        /// <summary>
        /// Process routine for current handler
        /// </summary>
        /// <param name="request"></param>
        void Process(Request request);
    }
}
