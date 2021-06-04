using RuleEngine;
using System;
using Xunit;
using RuleEngine.Handlers;
using RuleEngine.Entity;

namespace RuleEndingTest
{
    public class PhysicalProductHandlerTest
    {
        [Fact]
        public void PhysicalProductHandlerTest_ShouldProcessBook_HappyPath()
        {
            //ARRANGE 
            var phyHandler = new PhysicalProductHandler();
            var order = new Video("Learning to Ski", PurchaseMode.Physical);
            var request = new Request() { Data = order };

            //ACT
            phyHandler.Process(request);

            //ASSERT
            Assert.Contains(request.Actions, p => p == Actions.GEN_PACKING_SLIP_FOR_SHIPPING);
            Assert.Contains(request.Actions, p => p == Actions.GEN_COMMISSION_PAYMENT_FOR_AGENT);
        }

      
        [Fact]
        public void PhysicalProductHandlerTest_Should_Process_If_Not_Physical_Product()
        {
            //ARRANGE 
            var phyHandler = new PhysicalProductHandler();
            var order = new Video("Some Other Video", PurchaseMode.Online);
            var request = new Request() { Data = order };

            //ACT
            phyHandler.Process(request);

            //ASSERT
            Assert.DoesNotContain(request.Actions, p => p == Actions.GEN_PACKING_SLIP_FOR_SHIPPING);
            Assert.DoesNotContain(request.Actions, p => p == Actions.GEN_COMMISSION_PAYMENT_FOR_AGENT);
        }
    }
}
