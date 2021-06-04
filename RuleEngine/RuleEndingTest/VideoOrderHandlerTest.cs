using RuleEngine;
using System;
using Xunit;
using RuleEngine.Handlers;
using RuleEngine.Entity;

namespace RuleEndingTest
{
    public class VideoOrderHandlerTest
    {
        [Fact]
        public void VideoOrderHandlerTest_ShouldProcessBook_HappyPath()
        {
            //ARRANGE 
            var videoOrderHandler = new VideoOrderHandler();
            var order = new Video("Learning to Ski", PurchaseMode.Physical);
            var request = new Request() { Data = order };

            //ACT
            videoOrderHandler.Process(request);

            //ASSERT
            Assert.Contains(request.Actions, p => p == Actions.ADD_FIRST_AID_VIDEO_TO_PACKING_SLIP);
        }

      
        [Fact]
        public void VideoOrderHandlerTest_Video_OtherThan_LearnToSki_Should_Not_Add_FreeAid_Vide()
        {
            //ARRANGE 
            var videoOrderHandler = new VideoOrderHandler();
            var order = new Video("Some Other Video", PurchaseMode.Physical);
            var request = new Request() { Data = order };

            //ACT
            videoOrderHandler.Process(request);

            //ASSERT
            Assert.DoesNotContain(request.Actions, p => p == Actions.ADD_FIRST_AID_VIDEO_TO_PACKING_SLIP);
        }
    }
}
