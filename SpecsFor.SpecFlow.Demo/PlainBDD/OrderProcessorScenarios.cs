using Moq;
using NUnit.Framework;
using Should;
using SpecsFor.SpecFlow;
using SpecsFor.SpecFlow.Demo.Domain;
using TechTalk.SpecFlow;

namespace SpecsFor.SpecFlow.Demo.PlainBDD
{
	public class OrderProcessorScenarios
	{
		public class InventoryIsAvailableToFufillAnOrder : SpecsForSpecFlow<OrderProcessor>
		{
			private OrderResult _result;

			[Given(@"that inventory is available")]
			public void GivenThatInventoryIsAvailable()
			{
				GetMockFor<IInventory>()
					.Setup(i => i.IsQuantityAvailable("TestPart", 10))
					.Returns(true)
					.Verifiable();
			}

			[When(@"an order is processed")]
			public void WhenAnOrderIsProcessed()
			{
				_result = SUT.Process(new Order { PartNumber = "TestPart", Quantity = 10 });
			}

	    	[Then(@"the order should be accepted")]
			public void ThenTheOrderShouldBeAccepted()
			{
				_result.WasAccepted.ShouldBeTrue();	
			}

	    	[Then(@"the inventory is checked")]
			public void ThenTheInventoryIsChecked()
			{
				GetMockFor<IInventory>().Verify();
			}

	    	[Then(@"an order submitted event is raised")]
			public void ThenAnOrderSubmittedEventIsRaised()
			{
				GetMockFor<IPublisher>()
					.Verify(p => p.Publish(It.Is<OrderSubmitted>(o => o.OrderNumber == _result.OrderNumber)));
			}
		}

		public class InventoryIsNotAvailableToFufillAnOrder : SpecsForSpecFlow<OrderProcessor>
		{
			private OrderResult _result;
			
			[Given(@"that inventory is not available")]
			public void GivenThatInventoryIsNotAvailable()
			{
				GetMockFor<IInventory>()
					.Setup(i => i.IsQuantityAvailable("TestPart", 10))
					.Returns(false)
					.Verifiable();
			}

			[When(@"an order is processed")]
			public void WhenAnOrderIsProcessed()
			{
				_result = SUT.Process(new Order { PartNumber = "TestPart", Quantity = 10 });
			}

	    	[Then(@"the order should be rejected")]
			public void ThenTheOrderShouldBeAccepted()
			{
				_result.WasAccepted.ShouldBeFalse();	
			}

	    	[Then(@"the inventory is checked")]
			public void ThenTheInventoryIsChecked()
			{
				GetMockFor<IInventory>().Verify();
			}

	    	[Then(@"an order submitted event is not raised")]
			public void ThenAnOrderSubmittedEventIsNotRaised()
			{
				GetMockFor<IPublisher>()
					.Verify(p => p.Publish(It.IsAny<OrderSubmitted>()), Times.Never());
			}
		}
	}
}