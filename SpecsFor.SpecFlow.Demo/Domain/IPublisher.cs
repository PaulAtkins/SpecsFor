namespace SpecsFor.SpecFlow.Demo.Domain
{
	public interface IPublisher
	{
		void Publish<TEvent>(TEvent @event);
	}
}