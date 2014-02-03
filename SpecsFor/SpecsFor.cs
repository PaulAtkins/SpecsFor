using Moq;
using NUnit.Framework;
using SpecsFor.Configuration.Model;
using SpecsFor.Validation;
using StructureMap;
using StructureMap.AutoMocking;

namespace SpecsFor
{
	[TestFixture]
	public abstract class SpecsFor<T> : SpecsForBase<T>, ISpecs<T> where T : class
	{
		[TestFixtureSetUp]
		public virtual void SetupEachSpec()
		{
			base.BaseSetupEachSpec();
		}

		[TearDown]
		protected virtual void AfterEachTest()
		{
			base.BaseAfterEachTest();
		}

		[TestFixtureTearDown]
		public virtual void TearDown()
		{
			base.BaseTearDown();
		}
	}
}