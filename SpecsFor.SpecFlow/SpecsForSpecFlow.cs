using SpecsFor;
using TechTalk.SpecFlow;

namespace SpecsFor.SpecFlow
{
	[Binding]
	public abstract class SpecsForSpecFlow<T> : SpecsForBase<T>, ISpecs<T> where T : class
	{
		[BeforeFeature]
		public virtual void SetupEachSpec()
		{
			base.BaseSetupEachSpec();
		}

		[AfterScenario]
		protected virtual void AfterEachTest()
		{
			base.BaseAfterEachTest();
		}

		[AfterFeature]
		public virtual void TearDown()
		{
			base.BaseTearDown();
		}
		
		// Hide the SpecsFor methods, as the
		// SpecFlow ones will be used instead
		protected override void Given() { }
		protected override void When() { }
	}
}