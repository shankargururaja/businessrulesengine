using RuleEngine;
using System;
using Xunit;
using System.Linq;

namespace RuleEndingTest
{
    public class BookOrderHandlerTest
    {
        [Fact]
        public void BookOrderHandler_ShouldProcessBook_HappyPath()
        {
            //ARRANGE 
            var bookOrderHandler = new BookOrderHandler();
            var order = new Book("BookName", PurchaseMode.Physical);
            var request = new Request() { Data = order };

            //ACT
            bookOrderHandler.Process(request);

            //ASSERT
            Assert.Contains(request.Actions, p => p == Actions.CREATE_DUPLI_PACK_SLIP_FOR_ROYALTY_DEPARTMENT);
            Assert.Contains(request.Actions, p => p == Actions.GEN_COMMISSION_PAYMENT_FOR_AGENT);
        }
    }
}
