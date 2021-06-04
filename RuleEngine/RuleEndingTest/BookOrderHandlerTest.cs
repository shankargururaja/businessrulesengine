using RuleEngine;
using System;
using Xunit;
using RuleEngine.Handlers;
using RuleEngine.Entity;

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

        [Fact]
        public void BookOrderHandler_Book_Purchased_Online_Should_Not_GEN_PACKING_SLIP_FOR_SHIPPING()
        {
            //ARRANGE 
            var bookOrderHandler = new BookOrderHandler();
            var physicalProdHandler = new PhysicalProductHandler();
            bookOrderHandler.SetNextHandler(physicalProdHandler);
            var order = new Book("BookName", PurchaseMode.Online);
            var request = new Request() { Data = order };

            //ACT
            bookOrderHandler.Process(request);

            //ASSERT
            Assert.Contains(request.Actions, p => p == Actions.CREATE_DUPLI_PACK_SLIP_FOR_ROYALTY_DEPARTMENT);
            Assert.Contains(request.Actions, p => p == Actions.GEN_COMMISSION_PAYMENT_FOR_AGENT);
            Assert.DoesNotContain(request.Actions, p => p == Actions.GEN_PACKING_SLIP_FOR_SHIPPING);
        }

        [Fact]
        public void BookOrderHandler_Non_Book_Order_Should_Not_be_Processed()
        {
            //ARRANGE 
            var bookOrderHandler = new BookOrderHandler();
            var order = new Video("BookName", PurchaseMode.Physical);
            var request = new Request() { Data = order };

            //ACT
            bookOrderHandler.Process(request);

            //ASSERT
            Assert.DoesNotContain(request.Actions, p => p == Actions.CREATE_DUPLI_PACK_SLIP_FOR_ROYALTY_DEPARTMENT);
            Assert.DoesNotContain(request.Actions, p => p == Actions.GEN_COMMISSION_PAYMENT_FOR_AGENT);
        }
    }
}
