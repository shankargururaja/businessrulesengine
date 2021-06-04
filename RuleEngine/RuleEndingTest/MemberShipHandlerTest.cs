using RuleEngine;
using System;
using Xunit;
using RuleEngine.Handlers;
using RuleEngine.Entity;

namespace RuleEndingTest
{
    public class MemberShipHandlerTest
    {
        [Fact]
        public void MemberShipHandlerTest_ShouldProcess_ACTIVATE_NEW_MEMBERSHIP()
        {
            //ARRANGE 
            var membershipHandler = new MemberShipHandler();
            var order = new NewMemberShip("110", MembershipType.New);
            var request = new Request() { Data = order };

            //ACT
            membershipHandler.Process(request);

            //ASSERT
            Assert.Contains(request.Actions, p => p == Actions.ACTIVATE_MEMBERSHIP);
            Assert.DoesNotContain(request.Actions, p => p == Actions.UPGRADE_MEMBERSHIP);
        }

        [Fact]
        public void MemberShipHandlerTest_ShouldProcess_UPGRADE_TO_MEMBERSHIP()
        {
            //ARRANGE 
            var membershipHandler = new MemberShipHandler();
            var order = new NewMemberShip("110", MembershipType.Upgrade);
            var request = new Request() { Data = order };

            //ACT
            membershipHandler.Process(request);

            //ASSERT
            Assert.Contains(request.Actions, p => p == Actions.UPGRADE_MEMBERSHIP);
            Assert.DoesNotContain(request.Actions, p => p == Actions.ACTIVATE_MEMBERSHIP);
        }


        [Fact]
        public void MemberShipHandlerTest_NOT_PROCESS_ANY_OTHER_TYPE()
        {
            //ARRANGE 
            var membershipHandler = new MemberShipHandler();
            var order = new Book("110", PurchaseMode.Physical);
            var request = new Request() { Data = order };

            //ACT
            membershipHandler.Process(request);

            //ASSERT
            Assert.DoesNotContain(request.Actions, p => p == Actions.UPGRADE_MEMBERSHIP);
            Assert.DoesNotContain(request.Actions, p => p == Actions.ACTIVATE_MEMBERSHIP);
        }
    }
}
